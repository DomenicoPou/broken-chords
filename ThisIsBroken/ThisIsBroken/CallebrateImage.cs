﻿using System;
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
            // Obtain said input devices and open them
            OutputDevice outputDevice = OutputDevice.InstalledDevices[0];
            outputDevice.Open();

            // Run indefenity until stopped manually by pressing the visual studios square button
            while (true)
            {
                // OK this instantiates the CameraImaging Class so look there now.
                CameraImaging captureInstance = new CameraImaging();

                // Checks the rbg value of the bottom left pixle captured
                Console.WriteLine("BOTTOM LEFT RBG VALUE");
                Console.WriteLine(captureInstance.returnBitmap().GetPixel(0, 0));
                Console.WriteLine("");

                //Initialize height and width of the captured image.
                int Height = captureInstance.returnBitmap().Height;
                int Width = captureInstance.returnBitmap().Width;
                Console.WriteLine("DIMENTIONS");
                Console.WriteLine("Height : " + Height);    // Usually 480
                Console.WriteLine("Width : " + Width);      // Usually 640 if not its broken
                Console.WriteLine("");

                // Initialize a 2d array to store all the rbg strings ******** FIGURE OUT ACTUAL INT VALUES
                int[,,] array = new int[Height, Width, 3];

                // These two for loops will go from TOP -> DOWN then LEFT -> RIGHT
                for (int i = 0; i < Width; i++)
                {
                    for (int j = Height - 1; j >= 0; j--)
                    {
                        // USING Color we can obtain the bitmaps pixle R,B,G values
                        Color pixlecolor = captureInstance.returnBitmap().GetPixel(i, j);
                        
                        // Put the rbg values  to their respected spots
                        array[j, i, 0] = pixlecolor.R; // RED
                        array[j, i, 1] = pixlecolor.B; // BLUE
                        array[j, i, 2] = pixlecolor.G; // GREEN
                        //Pitch pitch = 2;
                        /* CALCS
                        Ok some calculations are in order, Due to the fact the pitch ranges to 0 - 127
                        and the height of the drawing is usually 0 - 479. we can ratio it down to devide
                        the height by 3.772 rounding it up by 1 to get the value of the pitch.
                        */
                        int value = (int)Math.Ceiling(i / 3.772);

                        // DOING 1 channel atm for testing until going to other channels.
                        // Note that all channels can handle more than one note.
                        // Velocity will stay at 80 for health purposes
                        // Using return pitch we are able to return a the corresponding values Pitch value.
                        outputDevice.SendNoteOn(Channel.Channel1, captureInstance.returnPitch(value), 80);
                        outputDevice.SendNoteOn(Channel.Channel1, Pitch.A4, 80);
                        System.Threading.Thread.Sleep(100);
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
