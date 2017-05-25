using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrokenForms
{
    class BrokenMath
    {
        static public int returnPolar(Bitmap bitmap)
        {
            
            int xStart = 0;
            int xMax = 0;
            int xFinnish = 0;

            int maxStartXCoord = 0;
            int maxFinnishXCoord = 0;

            int xyCoord = 0;

            bool isWhite = false;
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (bitmap.GetPixel(x, y).R > 200 && bitmap.GetPixel(x, y).G > 200 && bitmap.GetPixel(x, y).B > 200)
                    {
                        xStart = x;
                        Console.WriteLine("Current X " + x);
                        isWhite = true;
                    }
                    else
                    {
                        if (isWhite == true)
                        {
                            xFinnish = x;
                            Console.WriteLine("Finnish X " + x);
                            if ((xFinnish - xStart) > xMax)
                            {
                                xMax = (xFinnish - xStart);
                                maxStartXCoord = xStart;
                                maxFinnishXCoord = xFinnish;
                                xyCoord = y;
                            }
                        }
                        isWhite = false;
                    }
                }




                

            }

            int yStart = 0;
            int yMax = 0;
            int yFinnish = 0;

            int maxStartYCoord = 0;
            int maxFinnishYCoord = 0;

            int yxCoord = 0;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).R > 200 && bitmap.GetPixel(x, y).G > 200 && bitmap.GetPixel(x, y).B > 200)
                    {
                        yStart = y;
                        isWhite = true;
                    }
                    else
                    {
                        if (isWhite == true)
                        {
                            yFinnish = y;
                            if ((yFinnish - yStart) > yMax)
                            {
                                yMax = (yFinnish - yStart);
                                maxStartYCoord = yStart;
                                maxFinnishYCoord = yFinnish;
                                yxCoord = x;
                            }
                        }
                        isWhite = false;
                    }
                }
            }
            // CALCS Radius
            double xRadius = xMax / 2;
            double yRadius = yMax / 2;
            Console.WriteLine("OMG THE CALCS FOR THE WHITE BOARD");
            Console.WriteLine("Radius using XandYMax:");
            Console.WriteLine("X Radius = " + xRadius);
            Console.WriteLine("Y Radius = " + yRadius);
            Console.WriteLine("");


            // CALCS CENTRE POINT
            double xPoint = maxFinnishXCoord - maxStartYCoord;
            double yPoint = maxFinnishYCoord - maxStartXCoord;

            Console.WriteLine("Centre point using x and y start and finnish coords");
            Console.WriteLine("X = " + xPoint);
            Console.WriteLine("Y = " + yPoint);

            Console.WriteLine("Centre point using y and x of XandYMAX:");
            Console.WriteLine("X = " + xyCoord);
            Console.WriteLine("Y = " + yxCoord);
            return 1;

        }


    }
}
