using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.IO;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using Midi;

// I could simplify most of the includes, But hey, Wat ya gonna do

namespace BrokenForms
{

    public class CameraImaging
    {
        // Initiate all needed variables
        public Bitmap bitmapOne;
        //public Bitmap bitmapTwo;

        public int cameraInUse;

        // Bitmap to obtain all the rbg values of the webcam
        public FilterInfoCollection VideoCapturingDevices;  // All the video capturing devices
        public VideoCaptureDevice FileVideoSourceOne;          // The device we will be using
        //public VideoCaptureDevice FileVideoSourceTwo;
        // This is a very anoying hard coded Pitch array of pitches
        public Pitch[] pitches = { /*Pitch.CNeg1,
            Pitch.CSharpNeg1,
            Pitch.DNeg1,
            Pitch.DSharpNeg1,
            Pitch.ENeg1,
            Pitch.FNeg1,
            Pitch.FSharpNeg1,
            Pitch.GNeg1,
            Pitch.GSharpNeg1,
            Pitch.ANeg1,
            Pitch.ASharpNeg1,
            Pitch.BNeg1,
            Pitch.C0,
            Pitch.CSharp0,
            Pitch.D0,
            Pitch.DSharp0,
            */Pitch.E0,
            //Pitch.F0,
            //Pitch.FSharp0,
            //Pitch.G0,
            //
            //Pitch.GSharp0,
            //Pitch.A0,
            //
            //Pitch.ASharp0,
            //Pitch.B0,
            Pitch.C1,
            //
            Pitch.CSharp1,
            Pitch.D1,
            //
            Pitch.DSharp1,
            Pitch.E1,
            Pitch.F1,
            //
            Pitch.FSharp1,
            Pitch.G1,
            //
            Pitch.GSharp1,
            Pitch.A1,
            //
            Pitch.ASharp1,
            Pitch.B1,
            Pitch.C2,
            //
            Pitch.CSharp2,
            Pitch.D2,
            //
            Pitch.DSharp2,
            Pitch.E2,
            Pitch.F2,
            //
            Pitch.FSharp2,
            Pitch.G2,
            //
            Pitch.GSharp2,
            Pitch.A2,
            //
            Pitch.ASharp2,
            Pitch.B2,
            Pitch.C3,
            //
            Pitch.CSharp3,
            Pitch.D3,
            //
            Pitch.DSharp3,
            Pitch.E3,
            Pitch.F3,
            //
            Pitch.FSharp3,
            Pitch.G3,
            //
            Pitch.GSharp3,
            Pitch.A3,
            //
            Pitch.ASharp3,
            Pitch.B3,
            Pitch.C4,
            //
            Pitch.CSharp4,
            Pitch.D4,
            //
            Pitch.DSharp4,
            Pitch.F4,
            //
            Pitch.FSharp4,
            Pitch.G4,
            //
            Pitch.GSharp4,
            Pitch.A4,
            //
            Pitch.ASharp4,
            Pitch.B4,
            Pitch.C5,
            //
            Pitch.CSharp5,
            Pitch.D5,
            //
            Pitch.DSharp5,
            Pitch.E5,
            Pitch.F5,
            //
            Pitch.FSharp5,
            Pitch.G5,
            //
            Pitch.GSharp5,
            Pitch.A5,
            //
            Pitch.ASharp5,
            Pitch.B5,
            Pitch.C6,
            //Pitch.CSharp6,
            Pitch.D6,
            //Pitch.DSharp6,
            Pitch.E6,
            Pitch.F6,
            //Pitch.FSharp6,
            Pitch.G6,
            //Pitch.GSharp6,
            Pitch.A6,
            //Pitch.ASharp6,
            Pitch.B6,
            Pitch.C7,
            //Pitch.CSharp7,
            Pitch.D7,
            //Pitch.DSharp7,
            Pitch.E7,
            Pitch.F7,
            //Pitch.FSharp7,
            Pitch.G7,
            //Pitch.GSharp7,
            Pitch.A7,
            Pitch.ASharp7,
            Pitch.B7,
            Pitch.C8,
            Pitch.CSharp8,
            Pitch.D8,
            Pitch.DSharp8,
            Pitch.E8,
            Pitch.F8,
            Pitch.FSharp8,
            Pitch.G8,
            Pitch.GSharp8,
            Pitch.A8,
            Pitch.ASharp8,
            Pitch.B8,
            Pitch.C9,
            Pitch.CSharp9,
            Pitch.D9,
            Pitch.DSharp9,
            Pitch.E9,
            Pitch.F9,
            Pitch.FSharp9,
            Pitch.G9
        };
        /**
        Iitialize the camera capturing class
            */
        public CameraImaging()
        {
            // First obtain all the video captering devices
            VideoCapturingDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Go through and obtain all said devices
            Console.WriteLine("VIDEO CAPTURING DEVICES");
            foreach (FilterInfo VideoCapturingDevice in VideoCapturingDevices)
            {
                //Print them out
                Console.WriteLine(VideoCapturingDevice.Name.ToString());
            }
            Console.WriteLine("");

            // Try to see if you can enable the first camera
            try
            {
                VideoCaptureDevice FileVideoSource = new VideoCaptureDevice(VideoCapturingDevices[0].MonikerString);
            }
            catch
            {
                // If not print NO WEBCAMS :0
                System.Windows.Forms.MessageBox.Show("NO WEBCAMS ATTATCHED TO DEVICE :o");
                Environment.Exit(Environment.ExitCode);
            }
            bitmapOne = null;
            //bitmapTwo = null;

            // Set the first webcam to the main capturing device
            FileVideoSourceOne = new VideoCaptureDevice(VideoCapturingDevices[0].MonikerString);

            //Start the webcam up
            FileVideoSourceOne.Start();
            while(!FileVideoSourceOne.IsRunning);
            //Obtain a Frame GOTO video_NewFrame() FUNCTION
            FileVideoSourceOne.NewFrame += new NewFrameEventHandler(videoOne_NewFrame);

            //// Set the first webcam to the main capturing device
            //FileVideoSourceTwo = new VideoCaptureDevice(VideoCapturingDevices[1].MonikerString);

            ////Start the webcam up
            //FileVideoSourceTwo.Start();
            //while (!FileVideoSourceTwo.IsRunning) ;
            ////Obtain a Frame GOTO video_NewFrame() FUNCTION
            //FileVideoSourceTwo.NewFrame += new NewFrameEventHandler(videoTwo_NewFrame);

            ////Camera in use
            //cameraInUse = 0;

            //Due to the fact that the camera has a start up time, we have to wait until 
            //the frame has been captured then stop the camera. So first make sure the bitmap is null
            //Wait until the frame has been captured
            // THen stop the Camera
        }

        /**
        Return the current Bitmap Variable of webcam One
        */
        public bool returnCurrentBitmapOne(out Bitmap bitmap)
        {
            if (bitmapOne != null)
            {
                bitmap = bitmapOne;
                //Console.WriteLine("Here one");
                return true;
            }
            bitmap = null;
            return false;
        }

        //public void switchCameraUse()
        //{
        //    if (cameraInUse == 0)
        //    {
        //        cameraInUse = 1;
        //    }
        //    else
        //    {
        //        cameraInUse = 0;
        //    }
        //    //Console.WriteLine(cameraInUse.ToString());
        //}

        //public int returnCameraInUse()
        //{
        //    return cameraInUse;
        //}

        public bool returnCurrentBitmapOneCamera(out Bitmap bitmapC)
        {
            if (bitmapOne != null)
            {
                bitmapC = bitmapOne;
                //Console.WriteLine("Here one");
                return true;
            }
            bitmapC = null;
            return false;
        }

        /**
        Return the current Bitmap Variable of webcam Two
        */
        //public bool returnCurrentBitmapTwo(out Bitmap bitmap)
        //{
        //    if (bitmapTwo != null)
        //    {
        //        bitmap = bitmapTwo;
        //        //Console.WriteLine("Here two");
        //        return true;
        //    }
        //    bitmap = null;
        //    return false;
        //}

        /**
        This function controls the frames, This loops infinitly until the camera stops
        */

        private void videoOne_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // copy the new frame onto the bitmap
            //bitmap = new Bitmap(eventArgs.Frame);

            // CODE IF NEEDED FOR OVERLOADED BITMAPS
            /*try {
                tempBitmap = (Bitmap)eventArgs.Frame.Clone();
                bitmap = tempBitmap;
                tempBitmap.Dispose();
            } catch
            {

            }*/

            //Bitmap tempBitmapOne = null;
            //tempBitmapOne = (Bitmap)eventArgs.Frame.Clone();
            bitmapOne = (Bitmap)eventArgs.Frame.Clone();
        }
       /* private void videoTwo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //Bitmap tempBitmapTwo = null;
            //tempBitmapTwo = (Bitmap)eventArgs.Frame.Clone();
            bitmapTwo = (Bitmap)eventArgs.Frame.Clone();

        }*/

        //This is what we use to return a pitch value with our height value
        public Pitch returnPitch(int val)
        {
            // No seriously why didn't the people who made the source code
            // make one of these
            return pitches[val];
        }
    }
}