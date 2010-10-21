using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beeper
{
    public class Note
    {
        /// <summary>
        /// Frequency of the note
        /// </summary>
        public int Frequency { get; private set; }
        
        /// <summary>
        /// Milliseconds for note to play
        /// </summary>
        public int Duration { get; set; }

        public Note(string noteName, int duration)
        {
            this.Frequency = lookupFrequency(noteName);
            this.Duration = duration;
        }

        int lookupFrequency(string noteName)
        {
            switch (noteName.ToUpper())
            {
                case "C4": return 261;
                case "C4SHARP": return 277;
                case "D4": return 293;
                case "D4SHARP": return 311;
                case "E4": return 329;
                case "F4": return 349;
                case "F4SHARP": return 370;
                case "G4": return 390;
                case "G4SHARP": return 415;
                case "A4": return 440;
                case "A4SHARP": return 466;
                case "B4": return 493;
                case "C5": return 523;
                case "C5SHARP": return 554;
                case "D5": return 587;
                case "D5SHARP": return 622;
                case "E5": return 659;
                case "F5": return 698;
                case "F5SHARP": return 740;
                case "G5": return 784;
                // TODO: add all notes
                // C through B...
                //3: 130.8	138.6	146.8	155.6	164.8	174.6	185.0	196.0	207.7	220.0	233.1	246.9
                //4: 261.6	277.2	293.7	311.1	329.6	349.2	370.0	392.0	415.3	440.0	466.2	493.9
                //5: 523.3	554.4	587.3	622.3	659.3	698.5	740.0	784.0	830.6	880.0	932.3	987.8
                //6: 1047	1109	1175	1245	1319	1397	1480	1568	1661	1760	1865	1976
            }

            return 37; // lowest note that a console will do
        }
    }
}
