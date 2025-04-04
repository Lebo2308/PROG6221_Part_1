using System.IO;
using System;
using System.Drawing;

namespace PROG6221_Part_1
{
    public class logo
    {
        //constructor
        public logo()
        {
            //getting the full location of the project
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //replace bin\Debug\
            string new_location = full_location.Replace("bin\\Debug\\", "");//trying to access the folder Debuug

            //then combine the paths
            string full_path = Path.Combine(new_location, "logo2.PNG");

            //then time to use ascii

            //creating the BitMap class
            Bitmap image = new Bitmap(full_path);
            //then set the size
            image = new Bitmap(image, new Size(70, 45));

            //outer and inner loop
            //outer for loop
            for (int height = 0; height < image.Height; height++)
            {
                //inner for loop
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = gray > 200 ? '.' : gray > 150 ? '*' : gray > 50 ? '#' : '@';
                    Console.Write(asciiChar);

                }//end of inner for loop

                Console.WriteLine();

            }//end of outer for loop

        }//end of constructor
    }//end of class
}//end of namespace