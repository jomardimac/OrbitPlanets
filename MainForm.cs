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
            //create the image as a bitmap:
            picBox.Image = new Bitmap(1280,720);
            GravityButton.Checked = true;
            timeRender.Tick += timeRender_Tick;
            timeRender.Interval = 60;
            timeRender.Enabled = true;
            timeRender.Start();
        }


        public List<Planet> ListofPlanets = new List<Planet>();
        public List<Gravity> ListofGravity = new List<Gravity>();
               
        private void PictureBox_MouseClick (object sender, MouseEventArgs e) {
            //If the planet button is checked, create the planets and check to see if its in an orbit:
            if (PlanetButton.Checked == true) {
                Planet newPlanet = null;
                //go through each existed gravity and create the planet: now add the tick;
                if (ListofGravity.Count == 0) {
                    newPlanet = new Planet(e.Location, null);
                }
                else {
                    foreach (Gravity grav in ListofGravity) {
                        newPlanet = new Planet(e.Location, grav);
                    }
                }
                //add the planet in the list:
                ListofPlanets.Add(newPlanet);
            }
            //just create a gravity
            else {
                //create a new gravity and add it in the list
                Gravity newGrav = new Gravity(e.Location);
                ListofGravity.Add(newGrav);
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
            
            //go through each gravity added when the screen is clicked:
            foreach (Gravity grav in ListofGravity) {
                //used the using methods so no disposal of brush is needed.
                using (Brush myBrush = new SolidBrush(Color.FromArgb(32,0,0,0))) {
                    //however, i need the black brush to show the middle center of the gravity
                    Brush blackBrush = new SolidBrush(Color.Black);
                    //center wil lbe gravloc.x-radius,gravloc.y-radius, rad*2, rad*2
                    myGraphics.FillEllipse(myBrush, grav.X - grav.RangeofRad, grav.Y - grav.RangeofRad,
                        grav.RangeofRad * 2, grav.RangeofRad*2);
                    myGraphics.FillEllipse(blackBrush, grav.X - 5, grav.Y - 5, 5 * 2, 5 * 2);
                    blackBrush.Dispose();
                }
                
            }
            //Planets are then made and we have to draw them:
            foreach (var planets in ListofPlanets) {
                //I use the using method so we don't ahve to dispose the brush:
                using (Brush myBrush = new SolidBrush(Color.Red)) {
                    //check if planet has an orbit, if it does then move it:
                    if (!planets.IsInOrbit ) {
                        //radius of the small red planet is 10
                        myGraphics.FillEllipse(myBrush, planets.X - 5, planets.Y - 5, 5 * 2, 5 * 2);
                    }
                    else {
                        planets.MovePlanet();
                        //the X and Y axis are now changed and we move it
                        myGraphics.FillEllipse(myBrush, planets.X - 5, planets.Y - 5, 5 * 2, 5 * 2);
                    }
                }
            }
            
            //only move x and y when in an orbit:
            //picBox.Image = new Bitmap();
            myGraphics.Dispose();
            picBox.Invalidate();
        }

        /*To see if a circle in a gravity:
         * x = (radius * math.cos(angleindegrees * math.pi/180F)) + origin.x
         * y = ((radius * math.cos(angleindegrees * math.pi/180F)) + origin.Y
         */

        private static double CalcDistanceTwoPlanets (Planet planet, Gravity grav) {
            return Math.Sqrt((Math.Pow(planet.X - grav.X, 2) + Math.Pow(planet.Y - grav.Y, 2)));
        }

        public class Planet {
            public Gravity OrbitGravity = new Gravity(new Point());
            public float X, Y;
            public int Speed = 1;
            public double Angle, RadiusOrbit;
            public bool IsInOrbit ;
            //create's a planet and checks to see if tis in a orbit
            public Planet (Point cursor, Gravity grav) {
                //set the planet point to where it clicked.
                X = cursor.X;
                Y = cursor.Y;
                //nonexistant, just stay:
                if (grav != null) {
                    //set the gravity's x and y to the local gravity member and if
                    //the distance between the two is bigger than tis radius, it is in the orbit
                    OrbitGravity.X = grav.X;
                    OrbitGravity.Y = grav.Y;
                    var distancebetweentwo = CalcDistanceTwoPlanets(this, OrbitGravity);
                    if (distancebetweentwo < OrbitGravity.RangeofRad) {
                        IsInOrbit = true;
                        RadiusOrbit = distancebetweentwo;
                    }
                }
            }
            
            public void MovePlanet() {
                Angle = Math.Atan(this.Y / this.X);
                //FNDING HOW TO MOVE AROUND THE ORBIT:
                //It will be x = cos(angle)*(distancex-x)-sin(angle) * distance y - y + x
                //same with y but with sin and + y;

                double xAxis = Math.Cos(Angle);
                double yAxis = Math.Sin(Angle);
                double distX = X - OrbitGravity.X;
                double distY = Y - OrbitGravity.Y;
                int newX = (int) ((xAxis * distX) - (yAxis * distY) + OrbitGravity.X);
                int newY = (int) (yAxis * distX + xAxis * distY + OrbitGravity.Y);
                this.X = newX;
                this.Y = newY;
                Angle+= Speed;
            }

           
            
        }

        //gravity class, should just have a radius and its points:
        public class Gravity {
            public float X, Y, RangeofRad = 50;

            public Gravity(Point cursor) {
                X = cursor.X;
                Y = cursor.Y;
            }

        }
    }
}
