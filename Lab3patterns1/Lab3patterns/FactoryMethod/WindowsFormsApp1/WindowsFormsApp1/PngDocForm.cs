using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PngDocForm : Form
    {
        private readonly PngDocument png;

        public PictureBox PictureBox1
        {
            get { return pictureBox1; }
            set { pictureBox1 = value; }
        }

        public Label LabelColor
        {
            get { return lblColor; }
            set { lblColor = value; }
        }

        public PngDocForm(PngDocument png)
        {
            InitializeComponent();
            this.png = png;
            panel1.Left = 65;
            InitializePictureBox();
        }

        private void InitializePictureBox()
        {
            pictureBox1.Height = panel1.Height = PngDocForm.ActiveForm.Height - 100;
            pictureBox1.Width = panel1.Width = PngDocForm.ActiveForm.Width - 90;

            Image im = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();

            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();

            pictureBox1.Image = im;
        }

        private void openToolStripButton1_Click(object sender, EventArgs e)
        {
            png.Open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            png.SaveAs();
        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            png.ChooseColor();
        }

        private void closeToolStripButton_Click(object sender, EventArgs e)
        {
            png.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
