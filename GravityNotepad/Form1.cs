using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Security.Cryptography.Xml;
using static System.Windows.Forms.DataFormats;


namespace GravityNotepad
{
    public partial class Form1 : Form
    {
        private static int openWindows = 0;
        private Point selectionStart = Point.Empty;
        private Point selectionEnd = Point.Empty;
        private List<Label> selectedChars = new List<Label>();


        private Panel cursorPanel;
        private System.Windows.Forms.Timer blinkTimer;
        private System.Windows.Forms.Timer timer;
        private bool isCursorVisible = true;

        public List<Label> chars = new List<Label>();
        public List<float> velocities = new List<float>();

        public int cursorX = 5;
        public int cursorY = 25;
        public Point ScreenStart = new Point(5, 25);

        private int lineHeight = 20; // Height of a "line" for vertical movement
        private int charWidth = 10;
        private float gravity = 0.5f; // Gravity force
        private int groundLevel;

        Font USRFONT = new Font("Consolas", 10, FontStyle.Regular);
        public Form1()
        {
            InitializeComponent();
            openWindows++;
            // Create cursor panel
            cursorPanel = new Panel
            {
                BackColor = Color.Black,
                Width = 2,
                Height = 20,
                Location = ScreenStart // Position where you want the cursor
            };
            this.Controls.Add(cursorPanel);

            // Set up the blink timer
            blinkTimer = new System.Windows.Forms.Timer { Interval = 500 };
            blinkTimer.Tick += BlinkTimer_Tick;
            blinkTimer.Start();

            // Set up the gravity timer
            timer = new System.Windows.Forms.Timer { Interval = 16 };
            timer.Tick += Timer_Tick;
            timer.Start();

            this.KeyDown += KEYDOWN;
            this.KeyPreview = true; // Ensures the form captures key presses
            this.KeyPress += KEYPRESS;
            groundLevel = this.ClientSize.Height - lineHeight;

            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.FormClosing += Form1_close;

        }

        private void Form1_close(object? sender, FormClosingEventArgs e)
        {
            //  openWindows--;

            //   if (openWindows == 0)
            //{
            //     Application.Exit();
            // }
            // else
            // {
            //  e.Cancel = true;
            // //    this.Hide();
            // }

        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            isCursorVisible = !isCursorVisible;
            cursorPanel.Visible = isCursorVisible;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            for (int i = 0; i < chars.Count; i++)
            {
                var character = chars[i];
                ApplyGravity(character, i);
            }
        }

        private void ApplyGravity(Label character, int index)
        {
            // Get the velocity for this character
            float vel = velocities[index];

            // Apply gravity if there are no characters below this one
            if (!IsTextBelow(character))
            {
                vel += gravity; // Apply gravity if there's no obstruction
            }
            else
            {
                vel = 0; // Stop the fall if there is text below it
            }

            // Calculate the new Y position
            int newY = character.Top + (int)vel;

            // Prevent falling below the ground level
            if (newY > groundLevel)
            {
                newY = groundLevel;
                vel = 0; // Stop velocity at the ground level
            }

            // Update character's position
            character.Top = newY;

            // Save the updated velocity
            velocities[index] = vel;
        }

        private bool IsTextBelow(Label character)
        {
            // Check all other characters to see if there's any beneath the current one
            foreach (var otherLabel in chars)
            {
                // Skip the current character
                if (character == otherLabel)
                    continue;

                // Check if another character is below this one by comparing Y positions
                if (otherLabel.Location.X == character.Location.X &&
                    otherLabel.Location.Y > character.Location.Y &&
                    otherLabel.Location.Y < character.Location.Y + (lineHeight + 6))
                {
                    return true; // There is text below, so gravity shouldn't apply
                }
            }
            return false; // No text below this character
        }


        private void KEYDOWN(object sender, KeyEventArgs e)
        {
            // Handle cursor movement
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (cursorX > 5) cursorX -= charWidth;
                    else if (cursorY > 25) { cursorX = this.ClientSize.Width - charWidth; cursorY -= lineHeight; }
                    break;
                case Keys.Right:
                    if (cursorX < this.ClientSize.Width - charWidth) cursorX += charWidth;
                    else if (cursorY < this.ClientSize.Height - (lineHeight * 2)) { cursorX = 5; cursorY += lineHeight; }
                    break;
                case Keys.Up:
                    if (cursorY > 25) cursorY -= lineHeight;
                    break;
                case Keys.Down:
                    if (cursorY < this.ClientSize.Height - (lineHeight * 2)) cursorY += lineHeight;
                    break;
                case Keys.Return: // Handle 'Enter' key
                    cursorX = 5;
                    if (cursorY < this.ClientSize.Height - (lineHeight * 2)) cursorY += lineHeight;
                    break;
                case Keys.Back: // Handle Backspace key
                    HandleBackspace();
                    DeleteSelectedText();
                    break;




            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveToolStripMenuItem.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                openToolStripMenuItem.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedText();


            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                ClearSelection();

            }
            if (e.Control && e.KeyCode == Keys.N)
            {
                var f = new Form1();
                f.Show(this);
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteData();
            }
            if (e.Control && e.KeyCode == Keys.X)
            {
                CopySelectedText();
                DeleteSelectedText();
            }
           // if (e.Control && e.KeyCode == Keys.T)
            //{
               // string x = chars[0].Location.ToString();
              //  string y = "Cursor: " + cursorX.ToString() + " " + cursorY.ToString();
             //   MessageBox.Show(x, y);
           // }
            if (e.Control && e.KeyCode == Keys.W)
            {
                Label label = new Label
                {
                    Text = "⠀",
                    Location = new Point(cursorX, cursorY),
                    Font = USRFONT,
                    Size = new Size(charWidth, lineHeight),
                    Margin = new Padding(0),
                    Padding = new Padding(0)
                };

                this.Controls.Add(label);
                chars.Add(label);
                velocities.Add(0);

                // Move cursor
                cursorX += charWidth;
                if (cursorX >= this.ClientSize.Width - charWidth)
                {
                    cursorX = 5;
                    cursorY += lineHeight;
                }

                cursorPanel.Location = new Point(cursorX, cursorY);
            }

            cursorPanel.Location = new Point(cursorX, cursorY);
        }

        private void KEYPRESS(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            // Create a new label for the character
            Label label = new Label
            {
                Text = e.KeyChar.ToString(),
                Location = new Point(cursorX, cursorY),
                Font = USRFONT,
                Size = new Size(charWidth, lineHeight),
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            this.Controls.Add(label);
            chars.Add(label);
            velocities.Add(0);

            // Move cursor
            cursorX += charWidth;
            if (cursorX >= this.ClientSize.Width - charWidth)
            {
                cursorX = 5;
                cursorY += lineHeight;
            }

            cursorPanel.Location = new Point(cursorX, cursorY);
        }

        private void HandleBackspace()
        {
            Label labelToRemove = null;

            if (cursorY == this.ClientSize.Height - (lineHeight) - 5)
            {
                foreach (Label label in chars)
                {
                    if (label.Location.X == cursorX - charWidth && label.Location.Y == cursorY + 5)
                    {
                        labelToRemove = label;
                        break;
                    }

                }
            }
            else
            {
                foreach (Label label in chars)
                {
                    if (label.Location.X == cursorX - charWidth && label.Location.Y == cursorY)
                    {
                        labelToRemove = label;
                        break;
                    }

                }
                // / //int x = this.ClientSize.Height - (lineHeight);
                //  MessageBox.Show("dd",x.ToString());
            }
            if (labelToRemove != null)
            {
                int index = chars.IndexOf(labelToRemove);
                chars.RemoveAt(index);
                velocities.RemoveAt(index);
                this.Controls.Remove(labelToRemove);

                // Move the cursor back
                cursorX -= charWidth;

                // If we've deleted the last character of a line, we handle the previous line
                if (cursorX < 5 && cursorY > 25)
                {
                    cursorY -= lineHeight;
                    cursorX = this.ClientSize.Width - charWidth;
                }

                // Reapply gravity for the remaining characters to adjust positions
                for (int i = 0; i < chars.Count; i++)
                {
                    ApplyGravity(chars[i], i);
                }
            }
            else if (cursorX == 5 && cursorY > 25) // Handle empty line backspace
            {
                cursorY -= lineHeight;
                cursorX = this.ClientSize.Width - charWidth;
            }

            cursorPanel.Location = new Point(cursorX, cursorY);
        }




        private void MouseClickk(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = (int)(ScreenStart.X + charWidth * MathF.Round((e.X - ScreenStart.X) / charWidth));
                int y = (int)(ScreenStart.Y + lineHeight * MathF.Round((e.Y - ScreenStart.Y) / lineHeight));


                cursorX = x;
                cursorY = y;
                //MessageBox.Show("Mouse: "+e.X+" "+e.Y+";Cursor: "+x+" "+y);
                cursorPanel.Location = new Point(cursorX, cursorY);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectionStart = e.Location; // Record where the selection starts
                selectionEnd = Point.Empty; // Clear the end point
                ClearSelection(); // Clear any previous selection
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectionEnd = e.Location; // Update the selection endpoint
                UpdateSelection(); // Update which characters are selected
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateSelection(); // Finalize selection
            }
        }

        private void UpdateSelection()
        {
            // Clear previous selection
            ClearSelection();

            // Determine the selection rectangle
            int left = Math.Min(selectionStart.X, selectionEnd.X);
            int right = Math.Max(selectionStart.X, selectionEnd.X);
            int top = Math.Min(selectionStart.Y, selectionEnd.Y);
            int bottom = Math.Max(selectionStart.Y, selectionEnd.Y);
            Rectangle selectionRect = new Rectangle(left, top, right - left, bottom - top);

            // Find characters within the selection rectangle
            foreach (Label label in chars)
            {
                if (selectionRect.IntersectsWith(label.Bounds))
                {
                    selectedChars.Add(label);
                    HighlightLabel(label, true); // Highlight the label
                }
            }
        }

        private void HighlightLabel(Label label, bool highlight)
        {
            label.BackColor = highlight ? Color.LightBlue : this.BackColor; // Highlight or reset
        }

        private void ClearSelection()
        {
            foreach (Label label in selectedChars)
            {
                HighlightLabel(label, false); // Remove highlight
            }
            selectedChars.Clear();
        }

        private void CopySelectedText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Label label in selectedChars)
            {
                sb.Append(label.Text);
            }
            Clipboard.SetText(sb.ToString()); // Copy to clipboard
        }

        private void DeleteSelectedText()
        {
            foreach (Label label in selectedChars)
            {
                int index = chars.IndexOf(label);
                this.Controls.Remove(label); // Remove the label from the form
                chars.RemoveAt(index);
                velocities.RemoveAt(index);
            }
            ClearSelection(); // Clear the selection
        }

        private void PasteData()
        {
            string x = Clipboard.GetText();

            foreach (char c in x)
            {
                Label label = new Label
                {
                    Text = c.ToString(),
                    Location = new Point(cursorX, cursorY),
                    Font = USRFONT,
                    Size = new Size(charWidth, lineHeight),
                    Margin = new Padding(0),
                    Padding = new Padding(0)
                };

                this.Controls.Add(label);
                chars.Add(label);
                velocities.Add(0);

                // Move cursor
                cursorX += charWidth;
                if (cursorX >= this.ClientSize.Width - charWidth)
                {
                    cursorX = 5;
                    cursorY += lineHeight;
                }

                cursorPanel.Location = new Point(cursorX, cursorY);


            }

        }

        #region ToolStripFuncs

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save save = new Save(chars.Count, chars.Count, velocities.Count);

            for (int i = 0; i < chars.Count; i++)
            {
                save.Increment(chars[i].Location, chars[i].Text[0], velocities[i]);
            }

            // MessageBox.Show(save.ToString());

            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                FileName = "YourFilename",
                Title = "Choose Save Location",
                AddExtension = true,
                Filter = "Text File(with gravity retained)|*.TXT|Text File(Standard)|*.txt|All Files|*.*"
            };
            fileDialog.ShowDialog();

            Serializer ss = new Serializer(save, null);
            if (fileDialog.FilterIndex == 1)
            {


                if (ss.Serialize() == true)
                {
                    if (ss.WriteToFile(fileDialog.FileName) == true)
                    {
                        //MessageBox.Show("Successfully Written Data");
                    }
                    else
                    {
                        MessageBox.Show(ss.LastEx.Message);
                    }
                }
            }
            else if (fileDialog.FilterIndex == 2 || fileDialog.FilterIndex == 3)
            {
                // MessageBox.Show("Will save as standard text");
                if (ss.StandardSerialize() == true)
                {
                    if(ss.WriteToFile(fileDialog.FileName) == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show(ss.LastEx.Message);
                    }

                }
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.Show();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectedText();
            DeleteSelectedText();

        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectedText();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedText();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog(this);
            USRFONT = fd.Font;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog psd = new PageSetupDialog();
            psd.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog(this);

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Select File",
                FileName = "YourFileName",
                AddExtension = true,
                Filter = "Text File(with gravity retained)|*.TXT|Text File(Standard)|*.txt|All Files|*.*"
            };
            fileDialog.ShowDialog();
            
            Serializer ss = new Serializer(null, null);
            if (fileDialog.FilterIndex == 1)
            {

                if (ss.ReadFromFile(fileDialog.FileName) == true)
                {
                    //  MessageBox.Show(ss.data.ToString());
                }
                else
                {
                    MessageBox.Show(ss.LastEx.Message);
                }

                if (ss.Deserialize() == true)
                {
                    //MessageBox.Show(ss.input.ToString());
                }
                else
                {
                    MessageBox.Show(ss.LastEx.Message);
                }
            }
            else if (fileDialog.FilterIndex == 2 || fileDialog.FilterIndex == 3)
            {
                // MessageBox.Show("will open standard text file");
                if (ss.ReadFromFile(fileDialog.FileName) == true)
                {
                    if (ss.StandardDeSerialize() == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show(ss.LastEx.Message);
                    }
                }
                else
                {
                    MessageBox.Show(ss.LastEx.Message);
                }
            }
            DisplayOnScreen(ss.input);
        }

        #endregion



        public void Print_Deprecated()
        {
            cursorPanel.BackColor = Color.White;
            Rectangle x = ClientRectangle;
            x.Location = PointToScreen(x.Location);
            Bitmap result = Utility.GetScreenImage(x, strip1.Height);


            // Save as PNG (or change format as needed)
            result.Save(@"C:\Users\PULAK\Desktop\dd.png", System.Drawing.Imaging.ImageFormat.Png);


            MessageBox.Show($"Screenshot saved: {@"C:\Users\PULAK\Desktop\dd.png"}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cursorPanel.BackColor = Color.Black;
        }
        public void Print()
        {

        }
        public void DisplayOnScreen(Save save)
        {
            int x = 1;
            List<Label> labels = new List<Label>();

            for (int i = 0; i < save.positions.Length; i++)
            {
                Label label = new Label
                {
                    Text = save.letters[i].ToString(),
                    Location = save.positions[i],
                    Font = USRFONT,
                    Size = new Size(charWidth, lineHeight),
                    Margin = new Padding(0),
                    Padding = new Padding(0)
                };
                labels.Add(label);
            }
            if (x == 1)
            {
                foreach (Control ctrl in this.Controls.OfType<Label>().ToList())
                {
                    this.Controls.Remove(ctrl);
                }
                this.Text = save.filename;

                foreach (Label label in labels)
                {
                    this.Controls.Add(label);
                }
            }
            else
            {


                Form1 form1 = new Form1();
                form1 = new Form1();
                form1.Text = save.filename;
                form1.Show();
                foreach (Label label in labels)
                {
                    form1.Controls.Add(label);
                }
            }
        }
       
    }


}
