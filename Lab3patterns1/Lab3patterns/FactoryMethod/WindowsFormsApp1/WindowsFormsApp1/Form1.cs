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
    public partial class BaseForm : Form
    {
        App application;
        Document document;

        public BaseForm()
        {
            InitializeComponent();
        }

        private void MakeDocument(DocType docType, Action action)
        {
            if (docType == DocType.TextDoc)
                application = new TextApplication(action);
            else
                application = new PngApplication(action);

            if (action == Action.NewDoc)
                document = application.CreateDocument();
            else
                application.OpenDocument();
        }

        private void TxtDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeDocument(DocType.TextDoc, Action.NewDoc);
        }

        private void PngDocumentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MakeDocument(DocType.PngDoc, Action.NewDoc);
        }

        private void TxtDocumentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MakeDocument(DocType.TextDoc, Action.OpenDoc);
        }

        private void PngDocumentToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            MakeDocument(DocType.PngDoc, Action.OpenDoc);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
