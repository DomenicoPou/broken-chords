namespace BrokenForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pointBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rTextBox = new System.Windows.Forms.TextBox();
            this.pointBox2 = new System.Windows.Forms.PictureBox();
            this.pointBoxCurrent = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.degreeBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.blueAmountText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.greenAmountText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.redAmountText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.radiusDelayBox = new System.Windows.Forms.TextBox();
            this.pictureBoxDelay = new System.Windows.Forms.PictureBox();
            this.pitchPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBoxCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(12, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pointBox
            // 
            this.pointBox.BackColor = System.Drawing.Color.Fuchsia;
            this.pointBox.Location = new System.Drawing.Point(326, 85);
            this.pointBox.Name = "pointBox";
            this.pointBox.Size = new System.Drawing.Size(3, 3);
            this.pointBox.TabIndex = 1;
            this.pointBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(626, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pause";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Camera 1";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(626, 557);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(730, 30);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 20);
            this.xTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "X Point:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(672, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Y Point:";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(730, 56);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 20);
            this.yTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(672, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Radius:";
            // 
            // rTextBox
            // 
            this.rTextBox.Location = new System.Drawing.Point(730, 82);
            this.rTextBox.Name = "rTextBox";
            this.rTextBox.Size = new System.Drawing.Size(100, 20);
            this.rTextBox.TabIndex = 13;
            // 
            // pointBox2
            // 
            this.pointBox2.BackColor = System.Drawing.Color.DarkViolet;
            this.pointBox2.Location = new System.Drawing.Point(680, 337);
            this.pointBox2.Name = "pointBox2";
            this.pointBox2.Size = new System.Drawing.Size(3, 3);
            this.pointBox2.TabIndex = 15;
            this.pointBox2.TabStop = false;
            // 
            // pointBoxCurrent
            // 
            this.pointBoxCurrent.BackColor = System.Drawing.Color.DeepPink;
            this.pointBoxCurrent.Location = new System.Drawing.Point(688, 345);
            this.pointBoxCurrent.Name = "pointBoxCurrent";
            this.pointBoxCurrent.Size = new System.Drawing.Size(3, 3);
            this.pointBoxCurrent.TabIndex = 16;
            this.pointBoxCurrent.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(866, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Height:";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(924, 56);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(100, 20);
            this.heightBox.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(866, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Width:";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(924, 30);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(100, 20);
            this.widthBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1053, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Degree:";
            // 
            // degreeBox
            // 
            this.degreeBox.Location = new System.Drawing.Point(1111, 30);
            this.degreeBox.Name = "degreeBox";
            this.degreeBox.Size = new System.Drawing.Size(100, 20);
            this.degreeBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(759, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(742, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Read Variables";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(930, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Camera Variables";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1128, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Live Variables";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1053, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Blue Am:";
            // 
            // blueAmountText
            // 
            this.blueAmountText.Location = new System.Drawing.Point(1111, 111);
            this.blueAmountText.Name = "blueAmountText";
            this.blueAmountText.Size = new System.Drawing.Size(100, 20);
            this.blueAmountText.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1044, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Green Am:";
            // 
            // greenAmountText
            // 
            this.greenAmountText.Location = new System.Drawing.Point(1111, 85);
            this.greenAmountText.Name = "greenAmountText";
            this.greenAmountText.Size = new System.Drawing.Size(100, 20);
            this.greenAmountText.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1053, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Red Am:";
            // 
            // redAmountText
            // 
            this.redAmountText.Location = new System.Drawing.Point(1111, 59);
            this.redAmountText.Name = "redAmountText";
            this.redAmountText.Size = new System.Drawing.Size(100, 20);
            this.redAmountText.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(656, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Radius Delay:";
            // 
            // radiusDelayBox
            // 
            this.radiusDelayBox.Location = new System.Drawing.Point(730, 107);
            this.radiusDelayBox.Name = "radiusDelayBox";
            this.radiusDelayBox.Size = new System.Drawing.Size(100, 20);
            this.radiusDelayBox.TabIndex = 33;
            // 
            // pictureBoxDelay
            // 
            this.pictureBoxDelay.BackColor = System.Drawing.Color.Yellow;
            this.pictureBoxDelay.Location = new System.Drawing.Point(696, 353);
            this.pictureBoxDelay.Name = "pictureBoxDelay";
            this.pictureBoxDelay.Size = new System.Drawing.Size(3, 3);
            this.pictureBoxDelay.TabIndex = 35;
            this.pictureBoxDelay.TabStop = false;
            // 
            // pitchPictureBox
            // 
            this.pitchPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pitchPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pitchPictureBox.Location = new System.Drawing.Point(675, 134);
            this.pitchPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pitchPictureBox.Name = "pitchPictureBox";
            this.pitchPictureBox.Size = new System.Drawing.Size(640, 376);
            this.pitchPictureBox.TabIndex = 36;
            this.pitchPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 677);
            this.Controls.Add(this.pitchPictureBox);
            this.Controls.Add(this.pictureBoxDelay);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.radiusDelayBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.blueAmountText);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.greenAmountText);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.redAmountText);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.degreeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.pointBoxCurrent);
            this.Controls.Add(this.pointBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pointBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBoxCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pointBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rTextBox;
        private System.Windows.Forms.PictureBox pointBox2;
        private System.Windows.Forms.PictureBox pointBoxCurrent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox degreeBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox blueAmountText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox greenAmountText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox redAmountText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox radiusDelayBox;
        private System.Windows.Forms.PictureBox pictureBoxDelay;
        private System.Windows.Forms.PictureBox pitchPictureBox;
    }
}

