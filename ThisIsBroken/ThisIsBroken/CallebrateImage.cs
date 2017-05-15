using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Midi;

namespace ThisIsBroken
{
    class CallebrateImage
    {
        
        // Main is whats called
        static void Main(string[] args)
        {
            // Output all the midi devices, usually 6 cause of loopMIDI
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

            // Run indefenity until stopped manually by pressing the visual studios square button
            while (true)
            {
                // OK this instantiates the CameraImaging Class so look there now.
                CameraImaging captureInstance = new CameraImaging();

                // Checks the rbg value of the bottom left pixle captured
                Console.WriteLine("BOTTOM LEFT RBG VALUE");
                Console.WriteLine(captureInstance.returnBitmap().GetPixel(0,0));
                Console.WriteLine("");

                //Initialize height and width of the captured image.
                int Height = captureInstance.returnBitmap().Height;
                int Width = captureInstance.returnBitmap().Width;
                Console.WriteLine("DIMENTIONS");
                Console.WriteLine("Height : " + Height);    // Usually 480
                Console.WriteLine("Width : " + Width);      // Usually 640 if not its broken
                Console.WriteLine("");

                // These two for loops will go from TOP -> DOWN then LEFT -> RIGHT
                bool red = false;
                bool blue = false;
                bool green = false;
                bool black = false;
                for (int i = 0; i < Width; i++)
                {
                    if (i % 4 == 0)
                    {
                        for (int j = Height - 1; j >= 0; j--)
                        {
                            // USING Color we can obtain the bitmaps pixle R,B,G values
                            Color pixlecolor = captureInstance.returnBitmap().GetPixel(i, j);

                            
                            /* CALCS
                            Ok some calculations are in order, Due to the fact the pitch ranges to 0 - 127
                            and the height of the drawing is usually 0 - 479. we can ratio it down to devide
                            the height by 3.772 rounding it up by 1 to get the value of the pitch.
                            */
                            int value = (int)Math.Ceiling(j / 26.55) + 50;

                            if (pixlecolor.R - pixlecolor.G > 20 && pixlecolor.R - pixlecolor.B > 20)
                            {
                                if (red == false)
                                {
                                    //Console.WriteLine("OMG TS RED = " + j.ToString());
                                    outputDeviceGuitar.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value), 80);
                                    red = true;
                                }
                            }
                            else
                            {
                                red = false;
                                outputDeviceGuitar.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value), 80);
                            }

                            //Now calibrate if its blue
                            if (pixlecolor.B - pixlecolor.R > 20 && pixlecolor.B - pixlecolor.G > 20)
                            {
                                if (blue == false)
                                {
                                    //Console.WriteLine("OMG TS RED = " + j.ToString());
                                    outputDevicePiano.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value), 80);
                                    blue = true;
                                }
                            }
                            else
                            {
                                blue = false;
                                outputDevicePiano.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value), 80);
                            }

                            //Now calibrate if its Green
                            if (pixlecolor.G - pixlecolor.R > 5 && pixlecolor.G - pixlecolor.B > 5)
                            {
                                if (green == false)
                                {
                                    //Console.WriteLine("OMG TS RED = " + j.ToString());
                                    outputDeviceBass.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value), 80);
                                    green = true;
                                }
                            }
                            else
                            {
                                green = false;
                                outputDeviceBass.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value), 80);
                            }

                            //Now calibrate if its Black
                            if (pixlecolor.R < 100 && pixlecolor.G < 100 && pixlecolor.B < 100)
                            {
                                if (black == false)
                                {
                                    //Console.WriteLine("OMG TS RED = " + j.ToString());
                                    outputDeviceDrum.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value), 80);
                                    black = true;
                                }
                            }
                            else
                            {
                                black = false;
                                outputDeviceDrum.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value), 80);
                            }

                            //Console.WriteLine(value);
                            //Console.WriteLine(captureInstance.returnPitch(value));
                            // DOING 1 channel atm for testing until going to other channels.
                            // Note that all channels can handle more than one note.
                            // Velocity will stay at 80 for health purposes
                            // Using return pitch we are able to return a the corresponding values Pitch value.
                            //Console.WriteLine(value.ToString());
                            //outputDevice.SendNoteOn(Channel.Channel2, captureInstance.returnPitch(value), 80);
                            //outputDevice.SendNoteOn(Channel.Channel2, Pitch.A5, 80);

                        }
                    }
                    System.Threading.Thread.Sleep(40);
                }
                
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
    }
}
