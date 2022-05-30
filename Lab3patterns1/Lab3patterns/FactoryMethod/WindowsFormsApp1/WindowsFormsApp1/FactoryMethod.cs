using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace WindowsFormsApp1
{
    abstract class App
    {
        public abstract Document CreateDocument();
        public abstract void OpenDocument();
    }

    public abstract class Document
    {
        public abstract void Open();
        public abstract void Close();
        public abstract void SaveAs();
    }

    class PngApplication : App
    {
        Action action;

        public PngApplication(Action action)
        {
            this.action = action;
        }

        public override Document CreateDocument()
        {
            return new PngDocument(action);
        }

        public override void OpenDocument()
        {
            CreateDocument().Open();
        }
    }

    class TextApplication : App
    {
        Action action;

        public TextApplication(Action action)
        {
            this.action = action;
        }

        public override Document CreateDocument()
        {
            return new TextDocument(action);
        }

        public override void OpenDocument()
        {
            CreateDocument().Open();
        }
    }

    public class PngDocument : Document
    {
        private Pen pen = new Pen(Color.Black); // Определяет объект, используемый для рисования прямых линий и кривых.
        private Point startPt;  
        private Point movePt;
        private Point nullPt = new Point(int.MaxValue, 0);
        private SolidBrush brush = new SolidBrush(Color.White);
        private Bitmap oldImage; // Объект Bitmap используется для работы с изображениями, определяемыми данными пикселей.
        private OpenFileDialog openFile; // диалог. окно, позволяющее пользователю открыть файл
        private SaveFileDialog saveFile; // диалог. окно, спрашивает у пользователя расположение для сохранения
        private PngDocForm paintingForm; // форма для png файла
        private ColorDialog colorDialog; // диалоговое окно палитры

        public PngDocument(Action action)
        {
            openFile = new OpenFileDialog();
            saveFile = new SaveFileDialog();
            colorDialog = new ColorDialog();
            openFile.Filter = saveFile.Filter = "Image files (*.bmp, *.jpg, *.png, *.gif)|*.bmp;*.jpg;*.png;*.gif";
            openFile.FileName = saveFile.FileName = "Image";

            paintingForm = new PngDocForm(this);

            oldImage = new Bitmap(paintingForm.PictureBox1.Image);

            if (action == Action.NewDoc)
                paintingForm.Show();

            paintingForm.PictureBox1.MouseDown += PictureBox1_MouseDown; 
            paintingForm.PictureBox1.MouseMove += PictureBox1_MouseMove;
        }

        public override void Open()
        {
            startPt = nullPt;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string s = openFile.FileName;

                try
                {
                    Image im = new Bitmap(s);
                    Graphics g = Graphics.FromImage(im); // поверхность для рисования
                    g.Dispose(); // освобождение неуправляемых ресурсов
                    if (paintingForm.PictureBox1.Image != null)
                        paintingForm.PictureBox1.Image.Dispose();

                    paintingForm.PictureBox1.Image = im;
                    paintingForm.Show();
                    UpdateImage();
                }
                catch
                {
                    MessageBox.Show("File " + s + " has a wrong format.", "Error");
                    return;
                }

                paintingForm.Text = "Image Editor - " + s;
                saveFile.FileName = Path.ChangeExtension(s, "png"); // Изменяет расширение строки пути.
                openFile.FileName = "";
            }
        }

        public override void Close()
        {
            var result = MessageBox.Show("Закрыть документ?", "Закрытие документа",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question,
                              MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                paintingForm.Close();
            }
        }

        public override void SaveAs()
        {
            string s0 = saveFile.FileName;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string s = saveFile.FileName;
                if (s.ToUpper() == s0.ToUpper()) //попытка сохранить файл с тем же именем и расширением
                {
                    s0 = Path.GetDirectoryName(s0) + "\\($$##$$).png";
                    paintingForm.PictureBox1.Image.Save(s0); //сохранение изображения во временном файле
                    paintingForm.PictureBox1.Image.Dispose();// объект Bitmap разрушается
                    File.Delete(s); //исходный файл с изображением удаляется 
                    File.Move(s0, s); // имя временного файла заменяется именем исходного
                    paintingForm.PictureBox1.Image = new Bitmap(s);
                }
                else
                    paintingForm.PictureBox1.Image.Save(s);
                paintingForm.Text = "Image Editor - " + s;
            }
        }

        private void UpdateImage()
        {
            oldImage.Dispose();
            oldImage = new Bitmap(paintingForm.PictureBox1.Image);
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            movePt = startPt = e.Location;
            UpdateImage();
           if (Control.ModifierKeys == Keys.Alt)
            {
                Color c = (paintingForm.PictureBox1.Image as Bitmap).GetPixel(e.X, e.Y);
                if (e.Button == MouseButtons.Left)
                    paintingForm.LabelColor.BackColor = c;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPt == nullPt)
                return;

            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(paintingForm.PictureBox1.Image);
                g.DrawLine(pen, startPt, e.Location);
                g.Dispose();
                startPt = e.Location;
                paintingForm.PictureBox1.Invalidate();
            }
        }

      public void ChooseColor()
        {
            colorDialog.Color = paintingForm.LabelColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pen.Color = paintingForm.LabelColor.BackColor = colorDialog.Color;
        }
    } 

    public class TextDocument : Document
    {
        TextDocForm childForm;
        OpenFileDialog openFile;
        RichTextBox inputText;
        SaveFileDialog saveFile;
        Action action;
        
        string fileName;

        public TextDocument(Action action)
        {
            this.action = action;
            openFile = new OpenFileDialog();
            saveFile = new SaveFileDialog();
            inputText = new RichTextBox();

            openFile.Filter = saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.FileName = saveFile.FileName = "Document";

            childForm = new TextDocForm(this);

            if (action == Action.NewDoc)
                childForm.Show();
        }

        public override void Open()
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                action = Action.OpenDoc;
                fileName = openFile.FileName;
                var docName = new FileInfo(fileName); // получение имени файла
                childForm.Text = docName.Name;
                inputText.Text = File.ReadAllText(fileName); // Открывает текстовый файл, считывает весь текст файла в строку
                childForm.Show();
                childForm.ShowText(inputText);
            }
        }

        public override void SaveAs()
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                action = Action.OpenDoc;
                fileName = saveFile.FileName;
                var save = new StreamWriter(fileName, false, Encoding.GetEncoding("utf-8")); //false - перезапись файла, true - новые данные в конец файла
                save.Write(childForm.richTextBox1.Text);
                save.Close();
            }
        }

        public override void Close()
        {
            var result = MessageBox.Show("Закрыть документ?", "Закрытие документа",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question,
                                          MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                childForm.Close();
            }
        }
    }

    public enum Action
    {
        NewDoc,
        OpenDoc
    }

    public enum DocType
    {
        TextDoc,
        PngDoc
    }
}
