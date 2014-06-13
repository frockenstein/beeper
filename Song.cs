using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beeper
{
    public class Song
    {
        /// <summary>
        /// Default Note duration. Essentially tempo
        /// </summary>
        public int DefaultDuration { get; set; }

        public string Title { get; set; }

        public List<Note> Notes { get; set; }
        
        public Song() : this(200) { }

        public Song(int defaultDuration)
        {
            DefaultDuration = defaultDuration;
            Notes = new List<Note>();
        }

        /// <summary>
        /// Adds a note to the Song
        /// </summary>
        /// <param name="noteName"></param>
        /// <param name="duration"></param>
        public void Add(string noteName, int duration)
        {
            Notes.Add(new Note(noteName, duration));
        }

        public void Add(string noteName)
        {
            Add(noteName, DefaultDuration);
        }

        public void Add(string noteName, string noteLength)
        {
            int duration = GetNoteDuration(noteLength);
            Add(noteName, duration);
        }
        
        int GetNoteDuration(string noteLength)
        {
            // duration stuff is here 'cause it's really the song's
            // job, via tempo, to determine the duration of a note
            int duration = DefaultDuration;
            switch (noteLength.ToUpper())
            {
                // TODO: these case labels are magic strings and should be enums
                case "1/16": duration = (int)(duration * .25); break;
                case "1/8": duration = (int)(duration * .5); break;
                case "1/2": duration = duration * 2; break;
                case "3/4": duration = (int)(duration + (duration * .75)); break;
                case "1": duration = duration * 4; break;
            }
            return duration;
        }

        /// <summary>
        /// Adds an array of Notes to the Song and sets duration to DefaultDuration
        /// </summary>
        /// <param name="noteNames"></param>
        public void AddRange(string[] noteNames)
        {
            foreach (string noteName in noteNames)
                Notes.Add(new Note(noteName, DefaultDuration));
        }
    }
}
