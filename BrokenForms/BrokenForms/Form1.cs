using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BrokenForms
{
    public partial class Form1 : Form
    {
        public bool isPaused;
        public CameraImaging mainCamera;
        Thread mainThread;
        CameraImaging cameraInUse;
        public Form1(CameraImaging CameraObject, Thread trd)
        {
            mainThread = trd;
            mainCamera = CameraObject;
            isPaused = false;
            cameraInUse = CameraObject;
            mainThread.Start(cameraInUse);

            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bit_map;
            if (ThreadDebuggingForm.isPaused)
            {
                if (mainCamera.returnCurrentBitmapOne(out bit_map))
                {

                }
                else {
                }
                this.pictureBox1.Image = bit_map;
                //if (mainCamera.returnCurrentBitmapTwo(out bit_map))
                //{

                //}
                //else {
                //}
                this.pictureBox2.Image = bit_map;
            }
            System.GC.Collect();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ThreadDebuggingForm.isPaused == false)
            {
                ThreadDebuggingForm.isPaused = true;
                this.button1.BackColor = Color.Black;
            }
            else
            {
                ThreadDebuggingForm.isPaused = false;
                this.button1.BackColor = Color.White;
            }
            //Console.WriteLine(isPaused.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //mainThread.Abort();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Environment.Exit(Environment.ExitCode);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 119) // w
            {
                Console.WriteLine("W");
            }

            if (e.KeyChar == 97) // a
            {
                Console.WriteLine("A");
            }

            if (e.KeyChar == 115) // s
            {
                Console.WriteLine("S");
            }

            if (e.KeyChar == 100) // w
            {
                Console.WriteLine("D");
            }
        }
    }
}
