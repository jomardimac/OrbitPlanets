//Name: Jomar Dimaculangan
//ID:   11422439

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW13_Dimaculangan {
    public partial class MainForm : Form {
        
        public MainForm() {
            
            InitializeComponent();
            picBox.Image = new Bitmap(1280,720);
            GravityButton.Checked = true;
            timeRender.Tick += timeRender_Tick;
            timeRender.Interval = 16;
            timeRender.Enabled = true;
            timeRender.Start();
        }

        private const bool Renderpixels = true;
        public List<Planet> ListofPlanets = new List<Planet>();
        public List<Gravity> ListofGravity = new List<Gravity>();
        private int CalcDistanceTwoPlanets(Planet planet, Gravity grav) {
            return (int) Math.Sqrt((Math.Pow(planet.X+grav.X,2) + Math.Pow(planet.Y+ grav.Y,2)));
        }
        
        private void CreatPlanet(int x, int y) {
            //Planet newPlanet = new Planet(x-5, y-5, 10, 10);
            SolidBrush myBrush = new SolidBrush(Color.Red);
            Graphics myGraphics;
            myGraphics = picBox.CreateGraphics();
            //myGraphics.FillEllipse(myBrush, newPlanet.planet);

            myGraphics.Dispose();
            myBrush.Dispose();
        }
        
        private void PictureBox_MouseClick (object sender, MouseEventArgs e) {
            if (PlanetButton.Checked == true) {
                Planet newPlanet = null;
                //go through each existed gravity and create the planet: now add the tick;
                if (ListofGravity.Count == 0) {
                    newPlanet = new Planet(e.Location, null);
                }
                else {
                    foreach (Gravity grav in ListofGravity) {
                        newPlanet = new Planet(e.Location, grav);
                        //newPlanet.MovePlanet();
                    }
                }
                ListofPlanets.Add(newPlanet);
            }
            else {
                //create a new gravity and add it in the list
                Gravity newGrav = new Gravity(e.Location);
                ListofGravity.Add(newGrav);
                //timeRender.Tick += timeRender_Tick;
            }
            
        }
        

        private void timeRender_Tick (object sender, EventArgs e) {
            //fill the whole region with white.
            //draw all visible objects.
            //event happens:

            //clear the screen:
            Graphics myGraphics = Graphics.FromImage(picBox.Image);
            myGraphics.Clear(Color.White);

            //draw the visible objects:
            
            foreach (Gravity grav in ListofGravity) {
                using (Brush myBrush = new SolidBrush(Color.FromArgb(64,0,0,0))) {
                    Brush blackBrush = new SolidBrush(Color.Black);
                    //center wil lbe gravloc.x-radius,gravloc.y-radius, rad*2, rad*2
                    myGraphics.FillEllipse(myBrush, grav.X - grav.RangeofRad, grav.Y - grav.RangeofRad,
                        grav.RangeofRad*2, grav.RangeofRad*2);
                    myGraphics.FillEllipse(blackBrush, grav.X - 5, grav.Y - 5, 5 * 2, 5 * 2);
                    blackBrush.Dispose();
                }
            }
            //this is where it moves, for now just let it sit tho
            foreach (var planets in ListofPlanets) {
                using (Brush myBrush = new SolidBrush(Color.Red)) {
                    myGraphics.FillEllipse(myBrush,planets.X - 5, planets.Y - 5, 5 * 2, 5 * 2);
                }
            }
            //only move x and y when in an orbit:
            myGraphics.Dispose();
            picBox.Invalidate();
        }

        /*To see if a circle in a gravity:
         * x = (radius * math.cos(angleindegrees * math.pi/180F)) + origin.x
         * y = ((radius * math.cos(angleindegrees * math.pi/180F)) + origin.Y
         */

        public static PointF OnCircle(float rad, float angledeg, PointF orig) {
            float x = (float) (rad*Math.Cos(angledeg*Math.PI/180F)) + orig.X;
            float y = (float)((rad*Math.Cos(angledeg*Math.PI/180F)) + orig.Y;
            return new PointF(x, y);
        }

        public class Planet {
            public Gravity OrbitGravity = new Gravity(new Point());
            public float X, Y;
            public int Speed = 10;
            public bool IsInOrbit ;
            //create's a planet and checks to see if tis in a orbit
            public Planet (Point cursor, Gravity grav) {
                //set the planet point to where it clicked.
                X = cursor.X;
                Y = cursor.Y;
                //nonexistant, just stay:
                if (grav != null) {
                    OrbitGravity.X = grav.X;
                    OrbitGravity.Y = grav.Y;
                    IsInOrbit = true;
                }

            }

            public void MovePlanet() {
                //gonna move x and y depending on whether its on orbit or outside of orbit
                if (IsInOrbit) {
                    
                    //move x or why around that rad
                    //need the angle: return MATH.Atan2(big.y - a.y , big.x - x)
                    float angle = (float)Math.Atan2(OrbitGravity.Y - Y, OrbitGravity.X - X);
                    PointF orbitPoint = OnCircle(OrbitGravity.RangeofRad, angle,
                        new PointF(OrbitGravity.X, OrbitGravity.Y));
                    //X += ((OrbitGravity.RangeofRad) * (float) Math.Cos(angle * Math.PI/180F));
                    //Y += ((OrbitGravity.RangeofRad)*(float) Math.Cos(angle*Math.PI/180F));
                }
            }

            
        }

        public class Gravity {
            public float X, Y, RangeofRad = 50;

            public Gravity(Point cursor) {
                X = cursor.X;
                Y = cursor.Y;
            }

        }
    }
}
