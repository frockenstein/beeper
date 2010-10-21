using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace beeper
{
    public class SongLoader
    {
        // loads a random *.song file
    	public static Song LoadRandom()
        {
            FileInfo[] files = new DirectoryInfo(Environment.CurrentDirectory).GetFiles("*.song");
            int index = new Random().Next(0, files.Length);
            Song song = Load(Path.GetFileNameWithoutExtension(files[index].Name));
            return song;
        }

        public static Song Load(string name)
        {
        	string filePath = Path.Combine(Environment.CurrentDirectory, name + ".song");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("We don't be knowin' this ditty: " + filePath, filePath);

			// lotta room for improvement here... the idea is to make a text file 
			// that's easy for humans to monkey with, even if the code to read it
			// is ugly - yaml might be another option
                        
			string[] lines = File.ReadAllLines(filePath);
            Song song = new Song();
            foreach (string line in lines)
            {
                string[] vals = line.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                // song meta stuff, ie: title: some song title
                if (vals.Length > 1)
                {
                    string key = vals[0].Trim().ToLower();
                    string val = vals[1].Trim();
                    if (key == "title")
                    {
                        song.Title = val;
                        continue;
                    }
                    if (key == "tempo")
                    {
                        song.DefaultDuration = int.Parse(val);
                        continue;
                    }
                }
                // notes
                if (line.StartsWith("\t"))
                {
                    string val = line.Trim();
                    // note has time info with it
                    if (val.Contains(":"))
                    {
                        string[] parts = val.Split(":".ToCharArray());
                        val = parts[0];
                        song.Add(val, parts[1]);
                        continue;
                    }
                    else
                    {
                        song.Add(val);
                        continue;
                    }
                }
            }

            return song;
        }
    }
}
