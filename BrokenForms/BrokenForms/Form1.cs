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
            ThreadDebuggingForm.isPaused = true;
            cameraInUse = CameraObject;
            mainThread.Start(cameraInUse);

            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);
            InitializeComponent();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bit_map = null;
            if (ThreadDebuggingForm.isPaused)
            {
                if (mainCamera.returnCurrentBitmapOne(out bit_map))
                {

                }
                else {
                }

                pointBox.Location = new Point(pictureBox1.Location.X + ThreadDebuggingForm.xPoint, pictureBox1.Location.Y + (pictureBox1.Height - ThreadDebuggingForm.yPoint));
                pointBox.Size = new Size(ThreadDebuggingForm.radius, 1);
                radiusDelayBox.Text = ThreadDebuggingForm.radiusStartPoint.ToString();
                pictureBoxDelay.Location = new Point(pictureBox1.Location.X + ThreadDebuggingForm.xPoint, pictureBox1.Location.Y + (pictureBox1.Height - ThreadDebuggingForm.yPoint + 1  ));
                pictureBoxDelay.Size = new Size(ThreadDebuggingForm.radiusStartPoint, 1);
                pointBox2.Location = new Point(pictureBox1.Location.X + ThreadDebuggingForm.xPoint, pictureBox1.Location.Y + (pictureBox1.Height - ThreadDebuggingForm.yPoint));
                this.pictureBox1.Image = bit_map;
                if (bit_map != null)
                {
                    widthBox.Text = bit_map.Width.ToString();
                    heightBox.Text = bit_map.Height.ToString();
                }
                
                //this.pictureBox1.BackColor = Color.Transparent;
            }
            else{
                pointBoxCurrent.Location = new Point(pictureBox1.Location.X + ThreadDebuggingForm.currentXPoint, pictureBox1.Location.Y + ThreadDebuggingForm.currentYPoint);
                //drawPoint();
                redAmountText.Text = ThreadDebuggingForm.amount[0].ToString();
                greenAmountText.Text = ThreadDebuggingForm.amount[1].ToString();
                blueAmountText.Text = ThreadDebuggingForm.amount[2].ToString();
            }
            
            xTextBox.Text = ThreadDebuggingForm.xPoint.ToString();
            yTextBox.Text = ThreadDebuggingForm.yPoint.ToString();
            rTextBox.Text = ThreadDebuggingForm.radius.ToString();
            degreeBox.Text = ThreadDebuggingForm.currentDegree.ToString();

            

            System.GC.Collect();
        }

        public void drawPoint(int x, int y)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush brush = new SolidBrush(Color.LimeGreen);
            Point dPoint = new Point(x, (pictureBox1.Height - y));
            dPoint.X = dPoint.X - 2;
            dPoint.Y = dPoint.Y - 2;
            Rectangle rect = new Rectangle(dPoint, new Size(4, 4));
            g.FillRectangle(brush, rect);
            g.Dispose();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //mainThread.Abort();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Environment.Exit(Environment.ExitCode);
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 119) // w
            {
                Console.WriteLine("w");
                if (ThreadDebuggingForm.yPoint < pictureBox1.Height - 1)
                {
                    ThreadDebuggingForm.yPoint++;
                }
            }

            if (e.KeyChar == 97) // a
            {
                Console.WriteLine("a");
                if (ThreadDebuggingForm.xPoint > 0)
                {
                    ThreadDebuggingForm.xPoint--;
                }
            }

            if (e.KeyChar == 115) // s
            {
                Console.WriteLine("s");
                if (ThreadDebuggingForm.yPoint > 0)
                {
                    ThreadDebuggingForm.yPoint--;
                }
            }

            if (e.KeyChar == 100) // d
            {
                Console.WriteLine("d");
                if (ThreadDebuggingForm.xPoint < pictureBox1.Width - 1)
                {
                    ThreadDebuggingForm.xPoint++;
                }
            }

            if (e.KeyChar == 101) // e
            {
                Console.WriteLine("E");
                ThreadDebuggingForm.radius++;
            }

            if (e.KeyChar == 113) // q
            {
                Console.WriteLine("Q");
                ThreadDebuggingForm.radius--;
            }


            /////////////////////////////////////////////////////////////////

            if (e.KeyChar == 87) // W
            {
                Console.WriteLine("W");
                if (ThreadDebuggingForm.yPoint < pictureBox1.Height - 10)
                {
                    ThreadDebuggingForm.yPoint += 10;
                }
            }

            if (e.KeyChar == 65) // A
            {
                Console.WriteLine("A");
                if (ThreadDebuggingForm.xPoint > 9)
                {
                    ThreadDebuggingForm.xPoint -= 10;
                }
            }

            if (e.KeyChar == 83) // S
            {
                Console.WriteLine("S");
                if (ThreadDebuggingForm.yPoint > 9)
                {
                    ThreadDebuggingForm.yPoint -= 10;
                }
            }

            if (e.KeyChar == 68) // D
            {
                if (ThreadDebuggingForm.xPoint < pictureBox1.Width - 10)
                {
                    ThreadDebuggingForm.xPoint += 10;
                }
            }

            if (e.KeyChar == 69) // E
            {
                Console.WriteLine("E");
                ThreadDebuggingForm.radius += 2;
            }

            if (e.KeyChar == 81) // Q
            {
                Console.WriteLine("Q");
                ThreadDebuggingForm.radius -= 2;
            }
            if (e.KeyChar == 17)
            {

                ThreadDebuggingForm.radiusStartPoint--;
                Console.WriteLine("^Q");
            }
            if (e.KeyChar == 5)
            {
                ThreadDebuggingForm.radiusStartPoint++;
                Console.WriteLine("^E");
            }
        }
    }
}
