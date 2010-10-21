using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace beeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Turn yo speakers up!. Enter a song name or just hit Enter to play a random song");
            string input = Console.ReadLine();

            try
            {
                Song song;
                if (input == "")
                    song = SongLoader.LoadRandom();
                else
                    song = SongLoader.Load(input);
                
                Console.WriteLine("Playing {0}...", song.Title);
                SongPlayer player = new SongPlayer();
                player.Play(song);
                
                Console.WriteLine("Goodnight Cleveland!");
                Console.ReadLine();
            }
            catch (FileNotFoundException fileExc)
            {
                Console.WriteLine(fileExc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Now I'm all cornfabulated: " + exc.Message);
            }
        }
    }
}
