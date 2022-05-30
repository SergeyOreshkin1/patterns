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
    public partial class TextDocForm : Form
    {
        private readonly TextDocument myDoc;

        public TextDocForm(TextDocument myDoc)
        {
            InitializeComponent();
            this.myDoc = myDoc;
        }

        public void ShowText(RichTextBox inputText)
        {
            richTextBox1.Text = inputText.Text;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            myDoc.Open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            myDoc.SaveAs();
        }

        private void saveAsToolStripButton_Click(object sender, EventArgs e)
        {
            myDoc.SaveAs();
        }

        private void closeToolStripButton_Click(object sender, EventArgs e)
        {
            myDoc.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
