using System.IO;
using System.Media;
using System;

namespace PROG6221_Part_1
{
    public class sound
    {
        //constructor
        public sound()
        {
            //getting the app full location
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //replace bin\Debug\
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //combine the paths
            string full_path = Path.Combine(new_path, "CYBERREC.wav");

            //try and catch to play the audio
            try
            {
                //making use of using functions
                using (SoundPlayer play = new SoundPlayer(full_path))
                {
                    //play the file
                    play.PlaySync();

                }//end of using

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);

            }//end of catch

        }//end of constructor
    }
}