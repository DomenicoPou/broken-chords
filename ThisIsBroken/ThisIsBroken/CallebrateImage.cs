﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Midi;
using System.IO.Ports;
using System.Windows.Forms;

namespace ThisIsBroken
{
    class CallebrateImage : System.Windows.Forms.Form
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

            //Open the arduino port
            SerialPort port = new SerialPort("COM4", 9600);
            port.Open();
            //port.WriteLine        
            CameraImaging captureInstance = new CameraImaging();
            while (captureInstance.returnCurrentBitmap() == null)
            {
                ; ;
            }
            // Run indefenity until stopped manually by pressing the visual studios square button
            while (true)
            {
                Bitmap usingBitmap = captureInstance.returnCurrentBitmap();
                // OK this instantiates the CameraImaging Class so look there now.

                // Checks the rbg value of the bottom left pixle captured
                Console.WriteLine("BOTTOM LEFT RBG VALUE");
                Console.WriteLine(usingBitmap.GetPixel(0,0));
                Console.WriteLine("");

                //Initialize height and width of the captured image.
                int Height = usingBitmap.Height;
                int Width = usingBitmap.Width;
                Console.WriteLine("DIMENTIONS");
                Console.WriteLine("Height : " + Height);    // Usually 480
                Console.WriteLine("Width : " + Width);      // Usually 640 if not its broken
                Console.WriteLine("");

                // These two for loops will go from TOP -> DOWN then LEFT -> RIGHT
                bool red = false;
                bool blue = false;
                bool green = false;
                bool black = false;

                    // Polar co-ord 
                    for (int i = Width - 1; i >= 0; i--)
                {
                    List<int> amount= new List<int>();
                    amount.Add(0);
                    amount.Add(0);
                    amount.Add(0);
                    amount.Add(0);
                    if (i % 10 == 0)
                    {
                        usingBitmap = captureInstance.returnCurrentBitmap();
                    }
                    if (i % 4 == 0)
                    {
                        for (int j = 0; j < Height; j++)
                        {
                            // USING Color we can obtain the bitmaps pixle R,B,G values
                            Color pixelcolour = usingBitmap.GetPixel(i, j);

                            
                            /* CALCS
                            Ok some calculations are in order, Due to the fact the pitch ranges to 0 - 127
                            and the height of the drawing is usually 0 - 479. we can ratio it down to devide
                            the height by 3.772 rounding it up by 1 to get the value of the pitch.
                            */
                            int value = (int)Math.Ceiling((479 - j)  / 23.95);
                            if (pixelcolour.R - pixelcolour.G > 20 && pixelcolour.R - pixelcolour.B > 20)
                            {
                                if (red == false)
                                {
                                    /*int redTotal = pixelcolour.R + pixelcolour.G + pixelcolour.B;
                                    Console.WriteLine("Red: " + pixelcolour.R + " , " + pixelcolour.G + " , " + pixelcolour.B);
                                    Console.WriteLine("Total: " + redTotal);*/
                                    amount[0]++;
                                    outputDeviceGuitar.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value+10), 80);
                                    red = true;
                                }
                            }
                            else
                            {
                                red = false;
                                outputDeviceGuitar.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value+10), 80);
                            }

                           

                            //Now calibrate if its Green
                            if (pixelcolour.G - pixelcolour.R > 5 && pixelcolour.G - pixelcolour.B > 5)
                            {
                                if (green == false)
                                {
                                    /*int greenTotal = pixelcolour.R + pixelcolour.G + pixelcolour.B;
                                    Console.WriteLine("Green: " + pixelcolour.R + " , " + pixelcolour.G + " , " + pixelcolour.B);
                                    Console.WriteLine("Total: " + greenTotal);*/
                                    amount[1]++;
                                    outputDeviceBass.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value+10), 80);
                                    green = true;
                                }
                            }
                            else
                            {
                                green = false;
                                outputDeviceBass.SendNoteOff(Channel.Channel1, captureInstance.returnPitch(value+10), 80);
                            }

                            //Now calibrate if its blue
                            if (pixelcolour.B - pixelcolour.R > 20 && pixelcolour.B - pixelcolour.G > 20)
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


                            //Now calibrate if its Black
                            if (pixelcolour.R < 80 && pixelcolour.G < 80 && pixelcolour.B < 80)
                            {
                                if (black == false)
                                {
                                    /*int blackTotal = pixelcolour.R + pixelcolour.G + pixelcolour.B;
                                    Console.WriteLine("Black: " + pixelcolour.R + " , " + pixelcolour.G + " , " + pixelcolour.B);
                                    Console.WriteLine("Total: " + blackTotal);*/
                                    amount[3]++;
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
                    
                        int LEDNum = 240;

                        int redValue = 0;
                        int greenValue = 0;
                        int blueValue = 0;
                        int LightBit = 0;
                        
                        int maxValue = amount.Max();
                        //Console.WriteLine(maxValue);
                        switch (amount.ToList().IndexOf(maxValue)) {
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
                        }

                        int totalAmount = amount[0] + amount[1] + amount[2] + amount[3];
                        if (totalAmount == 0)
                        {
                            redValue = 0;
                            greenValue = 0;
                            blueValue = 0;
                        }
                        
                        double LedNumber = Math.Ceiling(((Width - i) - 1) / 2.68);
                        int LedRoundNumber = (int)LedNumber;
                        byte[] buffer = new byte[4];
                        buffer[0] = Convert.ToByte(redValue);     // RED
                        buffer[1] = Convert.ToByte(greenValue);    // GREEN
                        buffer[2] = Convert.ToByte(blueValue);      // BLUE
                        buffer[3] = Convert.ToByte(LedRoundNumber);      // LIGHT BIT
                        /*Console.WriteLine(redValue);
                        Console.WriteLine(greenValue);
                        Console.WriteLine(blueValue);
                        Console.WriteLine(LedRoundNumber);*/
                        //port.Write
                        System.Threading.Thread.Sleep(40);
                        port.Write(buffer, 0,4);
                    }
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
