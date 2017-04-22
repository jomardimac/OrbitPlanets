namespace HW13_Dimaculangan {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlanetButton = new System.Windows.Forms.RadioButton();
            this.GravityButton = new System.Windows.Forms.RadioButton();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.timeRender = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.PlanetButton);
            this.groupBox1.Controls.Add(this.GravityButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation Parameters";
            // 
            // PlanetButton
            // 
            this.PlanetButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlanetButton.AutoSize = true;
            this.PlanetButton.Location = new System.Drawing.Point(6, 44);
            this.PlanetButton.Name = "PlanetButton";
            this.PlanetButton.Size = new System.Drawing.Size(125, 17);
            this.PlanetButton.TabIndex = 1;
            this.PlanetButton.TabStop = true;
            this.PlanetButton.Text = "Click to create planet";
            this.PlanetButton.UseVisualStyleBackColor = true;
            // 
            // GravityButton
            // 
            this.GravityButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GravityButton.AutoSize = true;
            this.GravityButton.Location = new System.Drawing.Point(6, 21);
            this.GravityButton.Name = "GravityButton";
            this.GravityButton.Size = new System.Drawing.Size(172, 17);
            this.GravityButton.TabIndex = 0;
            this.GravityButton.TabStop = true;
            this.GravityButton.Text = "Click to create center of gravity";
            this.GravityButton.UseVisualStyleBackColor = true;
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BackColor = System.Drawing.SystemColors.Window;
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(13, 98);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(398, 253);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseClick);
            // 
            // timeRender
            // 
            this.timeRender.Interval = 60;
            this.timeRender.Tick += new System.EventHandler(this.timeRender_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 365);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.RadioButton PlanetButton;
        private System.Windows.Forms.RadioButton GravityButton;
        private System.Windows.Forms.Timer timeRender;
    }
}

