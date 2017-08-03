using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Midi;
using System.IO.Ports;
using System.Threading;
namespace BrokenForms
{

    class ThreadDebuggingForm
    {
        static public bool isPaused;
        static public int radius = 220;
        static public int xPoint = 332;
        static public int yPoint = 237;

        static public int currentXPoint = 0;
        static public int currentYPoint = 0;
        static public int currentDegree = 0;

        static public List<int> amount = new List<int>();
        
        static public int radiusStartPoint = 10;

        static public Point findPoint(int radius, int givenDegree)
        {
            //convert theata from degrees to radians
            double radian = givenDegree * (Math.PI / 180);
            double givenRadius = radius;
            //Console.WriteLine(radian);
            double x = givenRadius * Math.Cos(radian);
            x += xPoint;
            double y = givenRadius * Math.Sin(radian);
            y += yPoint;
            return new Point((int)x, (int)y);
        }

        static public void SystemThread(object mainCamera)
        {
            while (isPaused) ;

            amount.Add(0);
            amount.Add(0);
            amount.Add(0);
            amount.Add(0);

            Bitmap bitmap;
            // Start up the Camera Imaging funcions and wait for the bitmap to be null
            // this indicates when the camera is sending data        
            CameraImaging captureInstance = (CameraImaging)mainCamera;
            while (captureInstance.returnCurrentBitmapOne(out bitmap) == false) ;

            // Initialize thread for form debugging


            // Print out the midi loop channels
            Console.WriteLine("MIDI LOOP CHANNELS");
            foreach (OutputDevice device in OutputDevice.InstalledDevices)
            {
                Console.WriteLine("  {0}", device.Name);
            }
            Console.WriteLine("");

            // Obtain said input devices and open them for guitar
            OutputDevice outputDeviceGuitar = OutputDevice.InstalledDevices[1];
            outputDeviceGuitar.Open();

            // Obtain said input devices and open them for piano
            OutputDevice outputDevicePiano = OutputDevice.InstalledDevices[2];
            outputDevicePiano.Open();

            // Obtain said input devices and open them for bass
            OutputDevice outputDeviceBass = OutputDevice.InstalledDevices[3];
            outputDeviceBass.Open();

            // Obtain said input devices and open them for bass
            OutputDevice outputDeviceDrum = OutputDevice.InstalledDevices[4];
            outputDeviceDrum.Open();

            // Open the arduino port
            SerialPort port = new SerialPort("COM4", 9600);
            port.Open();

            //set the variable used to switch between cameras


            // Start up the Camera Imaging funcions and wait for the bitmap to be null
            // this indicates when the camera is sending data
            //while (captureInstance.returnCurrentBitmapOne(out bitmap) == false) ;
            Bitmap usingBitmap;
            //int cameraBeingPlayed = 0;
            // Run indefenity until stopped manually by pressing the visual studios square button
            // The Form is its seperate thread. So this code will still run if the thread closes
            while (true)
            {
                // Capture a bitmap for initial debugging ****** REPLACING THIS INTO THE DEBUGGING WINDOOW
                //if (captureInstance.returnCameraInUse() == 0)
                //{
                if (captureInstance.returnCurrentBitmapOne(out usingBitmap))
                {

                }
                else {
                    continue;
                }
                // Checks the rbg value of the bottom left pixle captured
                Console.WriteLine("BOTTOM LEFT RBG VALUE");
                Console.WriteLine(usingBitmap.GetPixel(0, 0).ToString());
                Console.WriteLine("");

                //Initialize height and width of the captured image.
                int Height = usingBitmap.Height;
                int Width = usingBitmap.Width;
                Console.WriteLine("DIMENTIONS");
                Console.WriteLine("Height : " + Height);    // Usually 480
                Console.WriteLine("Width : " + Width);      // Usually 640 if not its broken
                Console.WriteLine("");

                string[] coloursDetected = new string[640];
                for (int p = 0; p < 640; p++)
                {
                    coloursDetected[p] = "";
                }

                bool red = false;
                bool blue = false;
                bool green = false;
                //bool black = false;


                // FIGURE OUT: Polar co-ords for the loops when table is round 
                // These two for loops will go from Each DEGREE which (for now) is 360
                for (int d = 0; d < 360; d++)
                {
                    // Create a list of ints that will be used to check
                    // whats the most dominant colour being played at each width
    
                    // Every 10 pixles re-upload the current bitmap
                    //Console.WriteLine(captureInstance.returnCameraInUse());
                    if (captureInstance.returnCurrentBitmapOne(out usingBitmap))
                    {

                    }
                    else {
                        continue;
                    }

                    // Every four pixled will be checked for colour within their height
                    for (int r = radiusStartPoint; r < radius; r++)
                    {
                        while (isPaused) ;
                        // USING Color we can obtain the bitmaps pixle R,B,G values
                        Point ne = new Point(0, 0);
                        ne = findPoint(r, d);

                        Color pixelcolour = usingBitmap.GetPixel(ne.X, ne.Y);

                        currentDegree = d;
                        currentXPoint = ne.X;
                        currentYPoint = ne.Y;
                        /* CALCS
                        Ok because the width is counting down we need to swap its ratio to counting up
                        Then deviding it based on how many pitch values there are which gives the following
                        value.
                        */
                        int value = (int)Math.Ceiling((double)((radius - r) / (radius/20)));
                        // Now check if the colour at this pixle is red
                        if ((pixelcolour.R > pixelcolour.G) && (pixelcolour.R > pixelcolour.B) && (pixelcolour.G < 80 && pixelcolour.B < 80))
                        {
                            // To check if its one stroke  

                            if (red == false)
                            {
                                Console.WriteLine("Red");
                                // Commented out code for debuging purposes
                                // Incriment the ammount of red notes that are playing
                                amount[0]++;
                                // Send a midi note to the corresponding channel, its value repectivly
                                outputDeviceGuitar.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value + 10), 80);
                                // Switch to true, as its the start of a red stroke
                                red = true;
                            }
                        }
                        else
                        {
                            // if its no longer red, then stop and repeat until there is another colour
                            red = false;
                            // stop the note from playing
                        }



                        //Now calibrate if its Green
                        if (pixelcolour.G > pixelcolour.B && pixelcolour.R < 80  &&  (pixelcolour.G - pixelcolour.B < 20) && (pixelcolour.G - pixelcolour.B > -20))
                        {
                            if (green == false)
                            {
                                Console.WriteLine("Green");
                                amount[1]++;
                                outputDeviceBass.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value + 10), 80);
                                green = true;
                            }
                        }
                        else
                        {
                            green = false;
                        }

                        //Now calibrate if its blue
                        if (pixelcolour.G < pixelcolour.B && pixelcolour.R < 10 && pixelcolour.G < 70 && pixelcolour.B - pixelcolour.G > 20)
                        {
                            if (blue == false)
                            {
                                Console.WriteLine("blue");
                                amount[2]++;
                                outputDevicePiano.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value + 10), 80);
                                blue = true;
                            }
                        }
                        else
                        {
                            blue = false;
                        }

                        // STRETCH GOAL MAKE BLACK A COLOUR, HOWEVER REALLY ANNOYING
                        //Now calibrate if its Black
                        /*if ((pixelcolour.R < 40 && pixelcolour.G < 40 && pixelcolour.B < 40))
                        {
                            if (black == false)
                            {
                                /*int blackTotal = pixelcolour.R + pixelcolour.G + pixelcolour.B;
                                Console.WriteLine("Black: " + pixelcolour.R + " , " + pixelcolour.G + " , " + pixelcolour.B);
                                Console.WriteLine("Total: " + blackTotal);
                                amount[3]++;
                                outputDeviceDrum.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value), 80);
                                black = true;
                            }
                        }
                        else
                        {
                            black = false;
                            outputDeviceDrum.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value), 80);
                        }*/
                    }
                    int redValue = (int)(amount[0] * (255 / (amount.Max() + 1)));
                    int greenValue = (int)(amount[1] * (255 / (amount.Max() + 1)));
                    int blueValue = (int)(amount[2] * (255 / (amount.Max() + 1)));
                    int totalAmount = amount[0] + amount[1] + amount[2];
                    if (totalAmount == 0)
                    {
                        redValue = 255;
                        greenValue = 255;
                        blueValue = 200;
                    }
                    // COLOUR BLACK, CODE IS USED TO MAKE BLANK LED STRETCH GOAL, ALTHOUGH LOOKS UGLY
                    // Some math used to determin what led should be lit up due to what width its at
                    // when table is built, hard code for 1:1 ratio

                    double LedNumber = Math.Ceiling(d / 1.58);
                    int LedRoundNumber = (int)LedNumber;
                    //Console.WriteLine(LedRoundNumber);
                    // Create a byte buffer used to send data to the Arduino
                    byte[] buffer = new byte[4];
                    buffer[0] = Convert.ToByte(redValue);     // RED
                    buffer[1] = Convert.ToByte(greenValue);    // GREEN
                    buffer[2] = Convert.ToByte(blueValue);      // BLUE
                    buffer[3] = Convert.ToByte(LedRoundNumber);      // LIGHT BIT

                    // Send bits to said arduino
                    port.Write(buffer, 0, 4);

                    redValue = 0;
                    greenValue = 0;
                    blueValue = 0;

                    amount[0] = 0;
                    amount[1] = 0;
                    amount[2] = 0;
                    amount[3] = 0;

                    buffer[0] = 0;
                    buffer[1] = 0;
                    buffer[2] = 0;
                    buffer[3] = 0;

                    System.Threading.Thread.Sleep(40);
                    System.GC.Collect();
                }
            }
        }
    }
}
