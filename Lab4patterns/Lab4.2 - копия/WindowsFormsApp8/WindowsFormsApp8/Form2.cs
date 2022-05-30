using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public Form1 main;
        public Form2()
        {
            InitializeComponent();
            numericUpDown1.Text = Time.Value.ToString("HH");
            numericUpDown2.Text = Time.Value.ToString("mm");
            numericUpDown3.Text = Time.Value.ToString("ss");
        }

        public string GetChangedTime()
        {
            string stringTime = numericUpDown1.Text + ":" + numericUpDown2.Text + ":" + numericUpDown3.Text;
            return stringTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Time.Value = Convert.ToDateTime(GetChangedTime()); // конвертирует строку в формат даты
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
