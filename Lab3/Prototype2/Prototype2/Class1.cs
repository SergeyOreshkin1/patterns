using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public abstract class Prototype
    {
        public int id;
        public int height;
        public int amountNotes;
        public string note;
        public int octave;
        public int relativeNotePosition;
        public int stavePosition;
        public int duration;

        public Prototype(int id)
        {
            this.id = id;
        }


        public virtual Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }


    public class Note : Prototype
    {
        public Note(int id, int height, int stavePosition, int duration) : base(id)
        {
            this.height = height;
            this.stavePosition = stavePosition;
            this.duration = duration;
            this.octave = verifyOctave();
            this.relativeNotePosition = verifyNote();
        }

        private int verifyOctave()
        {
            int relativePosition = stavePosition - height;
            if (relativePosition <= 32.5)
                return 0;
            else
                return 1;
        }

        private int verifyNote()
        {
            double relativePosition = stavePosition - height - 30 * octave;

            if (relativePosition >= 27.5)
            {
                this.note = "B" + (4 + 1 * octave);
                return 30 + 30 * octave;
            }
            else if (relativePosition >= 22.5)
            {
                this.note = "A" + (4 + 1 * octave);
                return 25 + 30 * octave;
            }
            else if (relativePosition >= 17.5)
            {
                this.note = "G" + (4 + 1 * octave);
                return 20 + 30 * octave;
            }
            else if (relativePosition >= 12.5)
            {
                this.note = "F" + (4 + 1 * octave);
                return 15 + 30 * octave;
            }
            else if (relativePosition >= 7.5)
            {
                this.note = "E" + (4 + 1 * octave);
                return 10 + 30 * octave;
            }
            else if (relativePosition >= 2.5)
            {
                this.note = "D" + (4 + 1 * octave);
                return 5 + 30 * octave;
            }
            else
            {
                this.note = "C" + (4 + 1 * octave);
                return 0 + 30 * octave;
            }
        }
    }

    public class Stave : Prototype
    {
        public Stave(int id, int height) : base(id)
        {
            this.height = height;
            this.amountNotes = 0;
        }

        public void decreaseAmountNotes()
        {
            this.amountNotes -= 1;
        }

        public void increaseAmountNotes()
        {
            this.amountNotes += 1;
        }
    }
}
