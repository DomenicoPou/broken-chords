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

// I could simplify most of the includes, But hey, Wat ya gonna do

namespace ThisIsBroken
{

    public class CameraImaging
    {
        // Initiate all needed variables
        public Bitmap bitmap;                               // Bitmap to obtain all the rbg values of the webcam
        public FilterInfoCollection VideoCapturingDevices;  // All the video capturing devices
        public VideoCaptureDevice FileVideoSource;          // The device we will be using

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
                Console.WriteLine("NO WEBCAMS :0");
                return;
            }

            // Set the first webcam to the main capturing device
            FileVideoSource = new VideoCaptureDevice(VideoCapturingDevices[0].MonikerString);

            //Start the webcam up
            FileVideoSource.Start();

            //Obtain a Frame GOTO video_NewFrame() FUNCTION
            FileVideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

            //Due to the fact that the camera has a start up time, we have to wait until 
            //the frame has been captured then stop the camera. So first make sure the bitmap is null
            bitmap = null;
            //Wait until the frame has been captured
            while (bitmap == null)
            {
            }
            // THen stop the Camera
            FileVideoSource.Stop();
        }

        /**
        Return the Bitmap Variable
        */
        public Bitmap returnBitmap()
        {
            // Just to make sure we dont obtain a bitmap when returning
            if (bitmap != null)
            {
                return bitmap;
            }
            else {
                return null;
            }
        }

        /**
        This function controls the frames, This loops infinitly until the camera stops
        */
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // copy the new frame onto the bitmap
            bitmap = new Bitmap(eventArgs.Frame);
        }
    }
}