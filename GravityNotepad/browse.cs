using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GravityNotepad
{
    public partial class browse : Form
    {
        string finalpath = "";
        public browse(string title)
        {
            InitializeComponent();

            this.Text = title;

            DriveInfo[] drives = DriveInfo.GetDrives();
            disel.Items.Clear();


            // Add drives to ComboBox
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady) // Only add drives that are ready (e.g., ignore uninserted CD/DVD drives)
                {
                    disel.Items.Add(drive.Name); // Adding the drive letter (e.g., "C:\")
                }
            }

            // Optionally, set the default selected item (e.g., the first available drive)
            if (disel.Items.Count > 0)
            {
                disel.SelectedIndex = 0;
            }
            folview.AfterSelect += treeView1_AfterSelect;
        }

        private void browse_Load(object sender, EventArgs e)
        {
            if (disel.Items.Count > 0)
            {
                disel.SelectedIndex = 0;
            }
        }

        private async void disel_SelectedIndexChanged(object sender, EventArgs e)
        {
            await PopulateTreeViewAsync(disel.SelectedItem.ToString());
        }

        private async Task PopulateTreeViewAsync(string path)
        {
            // Clear the previous contents in the TreeView
            folview.Nodes.Clear();

            // Ensure the TreeView control handle is created
            if (!folview.IsHandleCreated)
            {
                await Task.Delay(10); // Wait briefly before trying again
                if (!folview.IsHandleCreated) return; // Exit if handle is still not ready
            }

            // Create the root node based on the selected drive (e.g., "C:\")
            TreeNode rootNode = new TreeNode(path)
            {
                Tag = path // Store the directory path in the Tag property
            };

            // Add the root node to the TreeView on the UI thread
            Invoke(new Action(() => folview.Nodes.Add(rootNode)));

            // Recursively add directories on a background thread
            await Task.Run(() => PopulateDirectories(rootNode, path));
        }

        // Recursively populate the tree with directories
        private void PopulateDirectories(TreeNode parentNode, string path)
        {
            try
            {
                var directories = Directory.GetDirectories(path);
                foreach (var directory in directories)
                {
                    TreeNode newNode = new TreeNode(Path.GetFileName(directory))
                    {
                        Tag = directory
                    };

                    // Ensure the control handle is created before updating UI
                    if (this.IsHandleCreated)
                    {
                        Invoke(new Action(() => parentNode.Nodes.Add(newNode)));
                    }

                    // Recursively populate subdirectories
                    PopulateDirectories(newNode, directory);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Ignore directories where access is denied
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accessing {path}: {ex.Message}");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node
            TreeNode selectedNode = e.Node;

            if (selectedNode != null && selectedNode.Tag != null)
            {
                // Retrieve the path stored in the Tag property
                string selectedPath = selectedNode.Tag.ToString();

                // Display or use the path
                selfol.Text = "Your selected Folder: " + selectedPath;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            finalpath = Path.Combine(selfol.Text + fname.Text); //+ fex.SelectedItem.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
