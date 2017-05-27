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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBoxCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(680, 420);
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
            this.pointBox.Click += new System.EventHandler(this.pictureBox2_Click);
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
            this.label5.Location = new System.Drawing.Point(672, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Height:";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(730, 134);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(100, 20);
            this.heightBox.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Width:";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(730, 108);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(100, 20);
            this.widthBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(672, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Degree:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // degreeBox
            // 
            this.degreeBox.Location = new System.Drawing.Point(730, 160);
            this.degreeBox.Name = "degreeBox";
            this.degreeBox.Size = new System.Drawing.Size(100, 20);
            this.degreeBox.TabIndex = 21;
            this.degreeBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 677);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBoxCurrent)).EndInit();
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
    }
}

