using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public DigitalWatch digitalWatch = new DigitalWatch();
        public DigitalWatch analogWatch = new Adapter();
        public Graphics clock; 
        public bool flag = true;

        public Form1()
        {
            InitializeComponent();

            Time.Value = DateTime.Now;
            clock = pictureBox1.CreateGraphics();

            Thread timeThread = new Thread(GetCurrentTime); 
            timeThread.IsBackground = true; 
            timeThread.Priority = ThreadPriority.Lowest;
            timeThread.Start();

        }

        public void GetCurrentTime()
        {
            while (true)
            {
                Time.Value = Time.Value.AddSeconds(1); 
                DrawTime();
                Thread.Sleep(1000); 
            }
        }

        public void DrawTime()
        {
            if (flag)
            {
                DrawDigitalTime();
            }
            else
            {
                DrawAnalogTime();
            }
        }

        public void DrawDigitalTime()
        {
            string stringTime = digitalWatch.getTimeDigital(Time.Value);
            SolidBrush drawBrush = new SolidBrush(Color.LightGreen); 
            clock.FillRectangle(new SolidBrush(Color.Black), 0, 0, pictureBox1.Width, pictureBox1.Height);
            clock.DrawString(stringTime, new Font("Arial", 60), drawBrush, 90, 20);
        }

        public void DrawAnalogTime()
        {
            clock.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            clock.FillRectangle(new SolidBrush(Color.Black), 0, 0, pictureBox1.Width, pictureBox1.Height);
            DrawClock();

            string stringAngles = analogWatch.getTimeDigital(Time.Value);
            string[] angles = stringAngles.Split(':');

            DrawArrow(new Pen(Color.Black, 7), Convert.ToDouble(angles[0]), 130); //часы
            DrawArrow(new Pen(Color.Black, 4), Convert.ToDouble(angles[1]), 160); // минуты
            DrawArrow(new Pen(Color.Black, 2), Convert.ToDouble(angles[2]), 180); // секунды
        }

        public void DrawClock()
        {
            clock.FillEllipse(new SolidBrush(Color.LightGreen), 0, 0, pictureBox1.Width - 20, pictureBox1.Height - 20); 

            double angle = -Math.PI / 3;

            for (int i = 1; i <= 12; i++)
            {
                double x = 190 * Math.Cos(angle) + pictureBox1.Width / 2 - 20;
                double y = 190 * Math.Sin(angle) + pictureBox1.Width / 2 - 20;

                clock.DrawString(i.ToString(), new Font("Arial", 14), new SolidBrush(Color.Black), (float)x, (float)y);

                angle += Math.PI / 6;
            }
        }

        public void DrawArrow(Pen pen, double angle, int length)
        {
            double x = length * Math.Cos(angle - Math.PI / 2) + pictureBox1.Width / 2 - 10;
            double y = length * Math.Sin(angle - Math.PI / 2) + pictureBox1.Width / 2 - 10;

            clock.DrawLine(pen, pictureBox1.Width / 2 - 10, pictureBox1.Width / 2 - 10, (float)x, (float)y); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string stringTime = numericUpDown1.Text + ":" + numericUpDown2.Text + ":" + numericUpDown3.Text;
            Time.Value = Time.Value.Add(TimeSpan.Parse(stringTime)); 
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
