namespace GravityNotepad
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            strip1 = new MenuStrip();
            Filestrip = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            pageSetupToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            Editstrip = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            dateAndTimeToolStripMenuItem = new ToolStripMenuItem();
            Viewstrip = new ToolStripMenuItem();
            statusBarToolStripMenuItem = new ToolStripMenuItem();
            wordWrapToolStripMenuItem = new ToolStripMenuItem();
            zoomInToolStripMenuItem = new ToolStripMenuItem();
            zoomOutToolStripMenuItem = new ToolStripMenuItem();
            strip1.SuspendLayout();
            SuspendLayout();
            // 
            // strip1
            // 
            strip1.BackColor = SystemColors.Menu;
            strip1.Items.AddRange(new ToolStripItem[] { Filestrip, Editstrip, Viewstrip });
            strip1.Location = new Point(0, 0);
            strip1.Name = "strip1";
            strip1.Size = new Size(800, 24);
            strip1.TabIndex = 0;
            strip1.Text = "menuStrip1";
            // 
            // Filestrip
            // 
            Filestrip.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, printToolStripMenuItem, pageSetupToolStripMenuItem, exitToolStripMenuItem });
            Filestrip.Name = "Filestrip";
            Filestrip.Size = new Size(37, 20);
            Filestrip.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new Size(180, 22);
            printToolStripMenuItem.Text = "Print";
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            // 
            // pageSetupToolStripMenuItem
            // 
            pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            pageSetupToolStripMenuItem.Size = new Size(180, 22);
            pageSetupToolStripMenuItem.Text = "Page Setup";
            pageSetupToolStripMenuItem.Click += pageSetupToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Editstrip
            // 
            Editstrip.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, selectAllToolStripMenuItem, deleteToolStripMenuItem, fontToolStripMenuItem, dateAndTimeToolStripMenuItem });
            Editstrip.Name = "Editstrip";
            Editstrip.Size = new Size(39, 20);
            Editstrip.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(129, 22);
            undoToolStripMenuItem.Text = "Undo";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(129, 22);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(129, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(129, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(129, 22);
            selectAllToolStripMenuItem.Text = "Select All";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(129, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // fontToolStripMenuItem
            // 
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Size = new Size(129, 22);
            fontToolStripMenuItem.Text = "Font";
            fontToolStripMenuItem.Click += fontToolStripMenuItem_Click;
            // 
            // dateAndTimeToolStripMenuItem
            // 
            dateAndTimeToolStripMenuItem.Name = "dateAndTimeToolStripMenuItem";
            dateAndTimeToolStripMenuItem.Size = new Size(129, 22);
            dateAndTimeToolStripMenuItem.Text = "Date/Time";
            // 
            // Viewstrip
            // 
            Viewstrip.DropDownItems.AddRange(new ToolStripItem[] { statusBarToolStripMenuItem, wordWrapToolStripMenuItem, zoomInToolStripMenuItem, zoomOutToolStripMenuItem });
            Viewstrip.Name = "Viewstrip";
            Viewstrip.Size = new Size(44, 20);
            Viewstrip.Text = "View";
            // 
            // statusBarToolStripMenuItem
            // 
            statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            statusBarToolStripMenuItem.Size = new Size(134, 22);
            statusBarToolStripMenuItem.Text = "Status Bar";
            // 
            // wordWrapToolStripMenuItem
            // 
            wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            wordWrapToolStripMenuItem.Size = new Size(134, 22);
            wordWrapToolStripMenuItem.Text = "Word Wrap";
            // 
            // zoomInToolStripMenuItem
            // 
            zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            zoomInToolStripMenuItem.Size = new Size(134, 22);
            zoomInToolStripMenuItem.Text = "Zoom in";
            // 
            // zoomOutToolStripMenuItem
            // 
            zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            zoomOutToolStripMenuItem.Size = new Size(134, 22);
            zoomOutToolStripMenuItem.Text = "Zoom out";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(strip1);
            MainMenuStrip = strip1;
            Name = "Form1";
            Text = "Gravity Notepad";
            MouseClick += MouseClickk;
            strip1.ResumeLayout(false);
            strip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip strip1;
        private ToolStripMenuItem Filestrip;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem pageSetupToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem Editstrip;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem Viewstrip;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem fontToolStripMenuItem;
        private ToolStripMenuItem dateAndTimeToolStripMenuItem;
        private ToolStripMenuItem statusBarToolStripMenuItem;
        private ToolStripMenuItem wordWrapToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem zoomOutToolStripMenuItem;
    }
}
