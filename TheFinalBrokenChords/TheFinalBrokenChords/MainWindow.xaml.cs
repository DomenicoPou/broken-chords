using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Midi;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace TheFinalBrokenChords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            // Initialize thread for form debugging
            Thread threadForUI = new Thread(UIThread);
            threadForUI.SetApartmentState(ApartmentState.STA);
            threadForUI.Start();

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

            // Start up the Camera Imaging funcions and wait for the bitmap to be null
            // this indicates when the camera is sending data        
            CameraImaging captureInstance = new CameraImaging();
            while (captureInstance.returnCurrentBitmap() == null) ;


            Bitmap usingBitmap;

            // Run indefenity until stopped manually by pressing the visual studios square button
            // The Form is its seperate thread. So this code will still run if the thread closes
            while (true)
            {
                // Capture a bitmap for initial debugging ****** REPLACING THIS INTO THE DEBUGGING WINDOOW
                usingBitmap = captureInstance.returnCurrentBitmap();

                // Checks the rbg value of the bottom left pixle captured
                Console.WriteLine("BOTTOM LEFT RBG VALUE");
                Console.WriteLine(usingBitmap.GetPixel(0, 0));
                Console.WriteLine("");

                //Initialize height and width of the captured image.
                int Height = usingBitmap.Height;
                int Width = usingBitmap.Width;
                Console.WriteLine("DIMENTIONS");
                Console.WriteLine("Height : " + Height);    // Usually 480
                Console.WriteLine("Width : " + Width);      // Usually 640 if not its broken
                Console.WriteLine("");


                bool red = false;
                bool blue = false;
                bool green = false;
                //bool black = false;

                // FIGURE OUT: Polar co-ords for the loops when table is round 
                // These two for loops will go from DOWN -> TOP then RIGHT -> LEFT
                for (int i = Width - 1; i >= 0; i--)
                {
                    // Create a list of ints that will be used to check
                    // whats the most dominant colour being played at each width
                    List<int> amount = new List<int>();
                    amount.Add(0);
                    amount.Add(0);
                    amount.Add(0);
                    amount.Add(0);

                    // Every 10 pixles re-upload the current bitmap
                    if (i % 10 == 0)
                    {
                        usingBitmap = captureInstance.returnCurrentBitmap();
                    }

                    // Every four pixled will be checked for colour within their height
                    if (i % 4 == 0)
                    {
                        for (int j = 0; j < Height; j++)
                        {
                            // USING Color we can obtain the bitmaps pixle R,B,G values
                            System.Drawing.Color pixelcolour = usingBitmap.GetPixel(i, j);


                            /* CALCS
                            Ok because the width is counting down we need to swap its ratio to counting up
                            Then deviding it based on how many pitch values there are which gives the following
                            value.
                            */
                            int value = (int)Math.Ceiling((479 - j) / 23.95);
                            // Now check if the colour at this pixle is red
                            if (pixelcolour.R - pixelcolour.G > 80 && pixelcolour.R - pixelcolour.B > 80)
                            {
                                // To check if its one stroke
                                if (red == false)
                                {
                                    // Commented out code for debuging purposes
                                    /*int redTotal = pixelcolour.R + pixelcolour.G + pixelcolour.B;
                                    Console.WriteLine("Red: " + pixelcolour.R + " , " + pixelcolour.G + " , " + pixelcolour.B);
                                    Console.WriteLine("Total: " + redTotal);*/
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
                                outputDeviceGuitar.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value + 10), 80);
                            }



                            //Now calibrate if its Green
                            if (pixelcolour.G - pixelcolour.R > 40 && pixelcolour.G - pixelcolour.B > 10)
                            {
                                if (green == false)
                                {
                                    /*int greenTotal = pixelcolour.R + pixelcolour.G + pixelcolour.B;
                                    Console.WriteLine("Green: " + pixelcolour.R + " , " + pixelcolour.G + " , " + pixelcolour.B);
                                    Console.WriteLine("Contrast G-R: " + (pixelcolour.G - pixelcolour.R) + " Contrast G-R:" + (pixelcolour.G - pixelcolour.B));*/
                                    amount[1]++;
                                    outputDeviceBass.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value + 10), 80);
                                    green = true;
                                }
                            }
                            else
                            {
                                green = false;
                                outputDeviceBass.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value + 10), 80);
                            }

                            //Now calibrate if its blue
                            if (pixelcolour.B - pixelcolour.R > 80 && pixelcolour.B - pixelcolour.G > 80)
                            {
                                if (blue == false)
                                {
                                    /*int blueTotal = pixelcolour.R + pixelcolour.G + pixelcolour.B;
                                    Console.WriteLine("Blue: " + pixelcolour.R + " , " + pixelcolour.G + " , " + pixelcolour.B);
                                    Console.WriteLine("Total: " + blueTotal);*/
                                    amount[2]++;
                                    outputDevicePiano.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value + 10), 80);
                                    blue = true;
                                }
                            }
                            else
                            {
                                blue = false;
                                outputDevicePiano.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value + 10), 80);
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

                        // INDIVIDUAL COLOUR LED LIGHTS, HOWEVER THE COMBINATION LOOKS COOLER
                        // NOTE: testing would be nice on this
                        //int LightBit = 0;
                        /*int maxValue = amount.Max();
                        //Console.WriteLine(maxValue);
                        switch (amount.ToList().IndexOf(maxValue))
                        {
                            case 0:
                                redValue = 255;
                                break;

                            case 1:
                                greenValue = 255;
                                break;

                            case 2:
                                blueValue = 255;
                                break;

                            case 3:
                                redValue = 255;
                                greenValue = 255;
                                blueValue = 255;
                                break;

                            default:
                                redValue = 0;
                                greenValue = 0;
                                blueValue = 0;
                                break;
                        }*/
                        //Console.WriteLine((amount[0] + amount[1] + amount[2]) + ": RBG       " + amount[3] + " :Black");
                        // If there are no colours present, it must be a blank space, make the LED white
                        int totalAmount = amount[0] + amount[1] + amount[2];
                        if (totalAmount == 0)
                        {
                            redValue = 255;
                            greenValue = 255;
                            blueValue = 255;
                        }
                        // COLOUR BLACK, CODE IS USED TO MAKE BLANK LED STRETCH GOAL, ALTHOUGH LOOKS UGLY
                        /*else if (amount[3] == amount.Max())
                            {
                                redValue = 0;
                                greenValue = 0;
                                blueValue = 0;
                            }*/

                        // Some math used to determin what led should be lit up due to what width its at
                        // when table is built, hard code for 1:1 ratio
                        double LedNumber = Math.Ceiling(((Width - i) - 1) / 2.68);
                        int LedRoundNumber = (int)LedNumber;

                        // Create a byte buffer used to send data to the Arduino
                        byte[] buffer = new byte[4];
                        buffer[0] = Convert.ToByte(redValue);     // RED
                        buffer[1] = Convert.ToByte(greenValue);    // GREEN
                        buffer[2] = Convert.ToByte(blueValue);      // BLUE
                        buffer[3] = Convert.ToByte(LedRoundNumber);      // LIGHT BIT

                        // Send bits to said arduino
                        port.Write(buffer, 0, 4);

                        System.Threading.Thread.Sleep(40);
                        
                    }
                }
                // TESTING CODE TO SEE THE ARRAYS RGB COLOURS
                // This is testing to make sure that the array is created
                /*for (int i = 0; i < Width; i++)
                {
                    for (int j = Height - 1; j >= 0; j--)
                    {
                        Console.WriteLine(array[j, i]);
                    }
                }*/
            }
        }

        // OH HEY ITS A NEW THREAD FOR THE DEBUG WINDOW
        private void UIThread(object arg)
        {
            using (Form UIForm = new Form())
                UIForm.ShowDialog();
        }
    }
}
