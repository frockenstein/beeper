using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beeper
{
    /// <summary>
    /// Class for playing Songs
    /// </summary>
    public class SongPlayer
    {
        /// <summary>
        /// Duh...
        /// </summary>
        /// <param name="song"></param>
        public void Play(Song song)
        {
        	// TODO: can you multithread and harmonize?
            foreach (Note note in song.Notes)
                Console.Beep(note.Frequency, note.Duration);
        }
    }
}
