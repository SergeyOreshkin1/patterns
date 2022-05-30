namespace WindowsFormsApp1
{
    partial class BaseForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pngDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDocumentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pngDocumentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtDocumentToolStripMenuItem,
            this.pngDocumentToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // txtDocumentToolStripMenuItem
            // 
            this.txtDocumentToolStripMenuItem.Name = "txtDocumentToolStripMenuItem";
            this.txtDocumentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.txtDocumentToolStripMenuItem.Text = "Txt Document";
            this.txtDocumentToolStripMenuItem.Click += new System.EventHandler(this.TxtDocumentToolStripMenuItem_Click);
            // 
            // pngDocumentToolStripMenuItem
            // 
            this.pngDocumentToolStripMenuItem.Name = "pngDocumentToolStripMenuItem";
            this.pngDocumentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pngDocumentToolStripMenuItem.Text = "Png Document";
            this.pngDocumentToolStripMenuItem.Click += new System.EventHandler(this.PngDocumentToolStripMenuItem_Click_1);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtDocumentToolStripMenuItem1,
            this.pngDocumentToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // txtDocumentToolStripMenuItem1
            // 
            this.txtDocumentToolStripMenuItem1.Name = "txtDocumentToolStripMenuItem1";
            this.txtDocumentToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.txtDocumentToolStripMenuItem1.Text = "Txt Document";
            this.txtDocumentToolStripMenuItem1.Click += new System.EventHandler(this.TxtDocumentToolStripMenuItem1_Click);
            // 
            // pngDocumentToolStripMenuItem1
            // 
            this.pngDocumentToolStripMenuItem1.Name = "pngDocumentToolStripMenuItem1";
            this.pngDocumentToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.pngDocumentToolStripMenuItem1.Text = "Png Document";
            this.pngDocumentToolStripMenuItem1.Click += new System.EventHandler(this.PngDocumentToolStripMenuItem1_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pngDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtDocumentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pngDocumentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

