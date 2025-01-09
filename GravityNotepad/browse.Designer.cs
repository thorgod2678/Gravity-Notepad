namespace GravityNotepad
{
    partial class browse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("Node1");
            TreeNode treeNode2 = new TreeNode("Node2");
            TreeNode treeNode3 = new TreeNode("Node4");
            TreeNode treeNode4 = new TreeNode("Node3", new TreeNode[] { treeNode3 });
            TreeNode treeNode5 = new TreeNode("Node0", new TreeNode[] { treeNode1, treeNode2, treeNode4 });
            disel = new ComboBox();
            folview = new TreeView();
            label1 = new Label();
            label2 = new Label();
            selfol = new Label();
            fname = new TextBox();
            label4 = new Label();
            label5 = new Label();
            fex = new ComboBox();
            OK = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // disel
            // 
            disel.FormattingEnabled = true;
            disel.Items.AddRange(new object[] { "C:", "D:" });
            disel.Location = new Point(19, 29);
            disel.Name = "disel";
            disel.Size = new Size(363, 23);
            disel.TabIndex = 0;
            disel.SelectedIndexChanged += disel_SelectedIndexChanged;
            // 
            // folview
            // 
            folview.Location = new Point(19, 80);
            folview.Name = "folview";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Node2";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Node4";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Node3";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Node0";
            folview.Nodes.AddRange(new TreeNode[] { treeNode5 });
            folview.Size = new Size(363, 173);
            folview.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 9);
            label1.Name = "label1";
            label1.Size = new Size(223, 15);
            label1.TabIndex = 2;
            label1.Text = "Select the disk you want to save your file:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 59);
            label2.Name = "label2";
            label2.Size = new Size(285, 15);
            label2.TabIndex = 3;
            label2.Text = "Select The Folder In which you want to save your file:";
            // 
            // selfol
            // 
            selfol.AutoSize = true;
            selfol.Location = new Point(19, 265);
            selfol.Name = "selfol";
            selfol.Size = new Size(119, 15);
            selfol.TabIndex = 4;
            selfol.Text = "Your selected Folder: ";
            // 
            // fname
            // 
            fname.Location = new Point(19, 311);
            fname.Name = "fname";
            fname.Size = new Size(268, 23);
            fname.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 293);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 6;
            label4.Text = "Enter FileName:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(303, 293);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 7;
            label5.Text = "File Extension";
            // 
            // fex
            // 
            fex.FormattingEnabled = true;
            fex.Items.AddRange(new object[] { ".gtxt", ".txt" });
            fex.Location = new Point(303, 311);
            fex.Name = "fex";
            fex.Size = new Size(79, 23);
            fex.TabIndex = 8;
            // 
            // OK
            // 
            OK.Location = new Point(332, 355);
            OK.Name = "OK";
            OK.Size = new Size(100, 23);
            OK.TabIndex = 9;
            OK.Text = "Okay";
            OK.UseVisualStyleBackColor = true;
            OK.Click += OK_Click;
            // 
            // button2
            // 
            button2.Location = new Point(438, 355);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 10;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // browse
            // 
            AcceptButton = OK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(562, 389);
            Controls.Add(button2);
            Controls.Add(OK);
            Controls.Add(fex);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(fname);
            Controls.Add(selfol);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(folview);
            Controls.Add(disel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "browse";
            Text = "Save As";
            Load += browse_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox disel;
        private TreeView folview;
        private Label label1;
        private Label label2;
        private Label selfol;
        private TextBox fname;
        private Label label4;
        private Label label5;
        private ComboBox fex;
        private Button OK;
        private Button button2;
    }
}