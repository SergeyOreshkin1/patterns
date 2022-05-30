using Prototype;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PianoSoundLibrary.Library;
using Toub.Sound.Midi;

namespace Prototype2
{
    public partial class Form1 : Form
    {
        public Bitmap contour = new Bitmap(800, 423);
        public int height = 20;
        public int noteLine = 60;
        public int durarion = 1;
        public int count = 0;
        List<Stave> noteLines = new List<Stave>();
        List<Note> notes = new List<Note>();

        public Form1()
        {
            InitializeComponent();
            contour = new Bitmap(800, 423);
            noteLines.Add(new Stave(noteLines.Count + 1, height + 50));
            MidiPlayer.OpenMidi();
            paintNotation();
        }

        private int checkNoteLine(int y)
        {
            for (int i = 0; i < noteLines.Count; i++)
                if (noteLines[i].height > y)
                    return i;
            return -1;
        }

        private void paintNotes()
        {
            Graphics g = Graphics.FromImage(contour);
            g.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
            pictureBox1.Image = contour;

            for (int j = 0; j < noteLines.Count; j++)
            {
                Pen myPen = new Pen(Color.Black, 1);
                Bitmap clef = new Bitmap(Properties.Resources.скрипичный, new Size(50, 80));
                int anyHeight = noteLines[j].height - 50;
                g.DrawImage(clef, 10, anyHeight - 20);
                for (int i = 0; i < 5; i++)
                {
                    g.DrawLine(myPen, 20, anyHeight, 790, anyHeight);
                    anyHeight += 10;
                }
            }

            
            if(notes.Count != 0)
                for (int i = 0; i < noteLines.Count; i++)
                {
                    Bitmap note;
                    int count = 0;
                    for (int j = 0; j < noteLines[i].amountNotes; j++)
                    {
                        if (notes[j + 20 * i].duration == 1)
                            note = new Bitmap(Properties.Resources.целая, new Size(30, 30));
                        else if (notes[j + 20 * i].duration == 2)
                            note = new Bitmap(Properties.Resources.половинная, new Size(30, 30));
                        else if (notes[j + 20 * i].duration == 4)
                            note = new Bitmap(Properties.Resources.четыре, new Size(30, 30));
                        else if (notes[j + 20 * i].duration == 8)
                            note = new Bitmap(Properties.Resources.восьмая, new Size(30, 30));
                        else
                            note = new Bitmap(Properties.Resources.шесть, new Size(30, 30));

                        if(notes[j + 20 * i].octave == 1 && notes[j + 20 * i].duration != 0)
                            note.RotateFlip(RotateFlipType.Rotate180FlipX);

                        if (noteLines[i].amountNotes != 0)
                        g.DrawImage(note, 80 + 36 * count,
                                notes[j + 20 * i].stavePosition - notes[j + 20 * i].relativeNotePosition - 15);
                        count++;
                    }
                }

            pictureBox1.Image = contour;
        }

        private void paintNotation()
        {
            Pen myPen = new Pen(Color.Black, 1);
            Graphics g = Graphics.FromImage(contour);
            Bitmap clef = new Bitmap(Properties.Resources.скрипичный, new Size(50, 80));
            g.DrawImage(clef, 10, height - 20);

            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(myPen, 20, height, 790, height);
                height += 10;
            }
            height += 10;
            pictureBox1.Image = contour;
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(contour);
            if (checkNoteLine(e.Y) != -1 && e.Button == MouseButtons.Left && noteLines[checkNoteLine(e.Y)].amountNotes < 20)
            {
                if (checkNoteLine(e.Y) >= 0)
                    if (noteLines[checkNoteLine(e.Y)].amountNotes < 20)
                        noteLines[checkNoteLine(e.Y)].increaseAmountNotes();

                int stavePosition = noteLines[checkNoteLine(e.Y)].height;
                notes.Add(new Note(notes.Count, e.Y, stavePosition, durarion));
                    if(noteLines[checkNoteLine(e.Y)] == noteLines[noteLines.Count - 1] && noteLines[checkNoteLine(e.Y)].amountNotes == 20 && noteLines.Count < 4)
                        noteLines.Add(new Stave(noteLines.Count + 1, noteLines[noteLines.Count - 1].height + 80));
                paintNotes();
            }
            else if (e.Button == MouseButtons.Right && notes.Count != 0)
            {
                
                notes.Remove(notes[notes.Count - 1]);
                if(noteLines[noteLines.Count - 1].amountNotes == 0)
                    noteLines.Remove(noteLines[noteLines.Count - 1]);
                noteLines[noteLines.Count - 1].decreaseAmountNotes();
                paintNotes();
            }
        }


        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < notes.Count; i++)
            {
                MidiPlayer.Play(new NoteOn(0, 1, notes[i].note, 127));
                Thread.Sleep(1000 / notes[i].duration); // блокировка потока приложения
                MidiPlayer.Play(new NoteOff(0, 1, notes[i].note, 127));
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.BackColor = SystemColors.ActiveBorder;
            toolStripMenuItem4.BackColor = SystemColors.Control;
            toolStripMenuItem3.BackColor = SystemColors.Control;
            toolStripMenuItem2.BackColor = SystemColors.Control;
            toolStripMenuItem5.BackColor = SystemColors.Control;
            durarion = 1;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.BackColor = SystemColors.ActiveBorder;
            toolStripMenuItem4.BackColor = SystemColors.Control;
            toolStripMenuItem3.BackColor = SystemColors.Control;
            toolStripMenuItem1.BackColor = SystemColors.Control;
            toolStripMenuItem5.BackColor = SystemColors.Control;
            durarion = 2;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3.BackColor = SystemColors.ActiveBorder;
            toolStripMenuItem4.BackColor = SystemColors.Control;
            toolStripMenuItem2.BackColor = SystemColors.Control;
            toolStripMenuItem1.BackColor = SystemColors.Control;
            toolStripMenuItem5.BackColor = SystemColors.Control;
            durarion = 4;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4.BackColor = SystemColors.ActiveBorder;
            toolStripMenuItem3.BackColor = SystemColors.Control;
            toolStripMenuItem2.BackColor = SystemColors.Control;
            toolStripMenuItem1.BackColor = SystemColors.Control;
            toolStripMenuItem5.BackColor = SystemColors.Control;
            durarion = 8;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5.BackColor = SystemColors.ActiveBorder;
            toolStripMenuItem4.BackColor = SystemColors.Control;
            toolStripMenuItem3.BackColor = SystemColors.Control;
            toolStripMenuItem2.BackColor = SystemColors.Control;
            toolStripMenuItem1.BackColor = SystemColors.Control;
            durarion = 16;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
