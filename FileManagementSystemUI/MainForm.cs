using System;
using System.IO;
using System.Windows.Forms;

namespace FileManagementSystemUI
{
    public class MainForm : Form
    {
        private TextBox directoryTextBox;
        private Button listButton;
        private ListBox filesListBox;

        private TextBox sourceTextBox;
        private TextBox destinationTextBox;
        private Button copyButton;
        private Button moveButton;

        private TextBox deleteTextBox;
        private Button deleteButton;

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "File Management System";
            this.Width = 600;
            this.Height = 500;

            var directoryLabel = new Label { Text = "Directory:", Top = 10, Left = 10, Width = 70 };
            directoryTextBox = new TextBox { Top = 10, Left = 90, Width = 400 };
            listButton = new Button { Text = "List", Top = 10, Left = 500 };
            listButton.Click += (s, e) => ListFiles();

            filesListBox = new ListBox { Top = 40, Left = 10, Width = 560, Height = 150 };

            var sourceLabel = new Label { Text = "Source:", Top = 200, Left = 10, Width = 70 };
            sourceTextBox = new TextBox { Top = 200, Left = 90, Width = 400 };

            var destinationLabel = new Label { Text = "Destination:", Top = 230, Left = 10, Width = 70 };
            destinationTextBox = new TextBox { Top = 230, Left = 90, Width = 400 };

            copyButton = new Button { Text = "Copy", Top = 260, Left = 90 };
            copyButton.Click += (s, e) => CopyFile();

            moveButton = new Button { Text = "Move", Top = 260, Left = 170 };
            moveButton.Click += (s, e) => MoveFile();

            var deleteLabel = new Label { Text = "Delete:", Top = 320, Left = 10, Width = 70 };
            deleteTextBox = new TextBox { Top = 320, Left = 90, Width = 400 };
            deleteButton = new Button { Text = "Delete", Top = 350, Left = 90 };
            deleteButton.Click += (s, e) => DeleteFile();

            this.Controls.AddRange(new Control[] {
                directoryLabel, directoryTextBox, listButton, filesListBox,
                sourceLabel, sourceTextBox, destinationLabel, destinationTextBox,
                copyButton, moveButton,
                deleteLabel, deleteTextBox, deleteButton
            });
        }

        private void ListFiles()
        {
            filesListBox.Items.Clear();
            var path = directoryTextBox.Text;
            if (Directory.Exists(path))
            {
                try
                {
                    var files = Directory.GetFiles(path);
                    filesListBox.Items.AddRange(files);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error listing files: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Directory not found.");
            }
        }

        private void CopyFile()
        {
            try
            {
                File.Copy(sourceTextBox.Text, destinationTextBox.Text, overwrite: true);
                MessageBox.Show("File copied.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying file: {ex.Message}");
            }
        }

        private void MoveFile()
        {
            try
            {
                File.Move(sourceTextBox.Text, destinationTextBox.Text);
                MessageBox.Show("File moved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error moving file: {ex.Message}");
            }
        }

        private void DeleteFile()
        {
            try
            {
                File.Delete(deleteTextBox.Text);
                MessageBox.Show("File deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting file: {ex.Message}");
            }
        }
    }
}
