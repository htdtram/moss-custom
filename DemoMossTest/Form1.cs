using DemoMossTest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoMossTest
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// All files command
        /// </summary>
        private const string AllFiles = "*.*";

        /// <summary>
        /// The dialog box used to find base and source files. 
        /// </summary>
        private FolderBrowserDialog dialog;


        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the base file list.
        /// </summary>
        /// <value>
        /// The base file list.
        /// </value>
        private List<string> BaseFileList { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the source file list.
        /// </summary>
        /// <value>
        /// The base file list.
        /// </value>
        private List<string> SourceFileList { get; set; } = new List<string>();

        /// <summary>
        /// Gets the restricted file types as a list.
        /// </summary>
        /// <returns>
        /// A list of files types to accept.
        /// </returns>
        private List<string> GetRestrictedFileTypes()
        {
            var files = ".cs";
            return files.Length > 0 ? files.Split(',').ToList() : new List<string>();
        }

        /// <summary>
        /// Updates the file list.
        /// </summary>
        private void UpdateFileList()
        {
            var builder = new StringBuilder();
            if (this.BaseFileList.Count > 0)
            {
                builder.AppendLine(Resources.FileList_BaseFiles);
                builder.AppendLine("----------------------------------------------");
                foreach (var file in this.BaseFileList)
                {
                    builder.AppendLine(file);
                }
            }

            builder.AppendLine(string.Empty);
            if (this.SourceFileList.Count > 0)
            {
                builder.AppendLine(Resources.FileList_SourceFile);
                builder.AppendLine("----------------------------------------------");
                foreach (var file in this.SourceFileList)
                {
                    builder.AppendLine(file);
                }
            }

            this.FilesRichTextBox.Text = builder.ToString();
        }

        private void BaseFilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dialog.Description = Resources.BaseFile_Dialog_Description;
                var result = this.dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var folderName = this.dialog.SelectedPath;
                    var extensions = this.GetRestrictedFileTypes();
                    this.BaseFileList = Directory.GetFiles(folderName, AllFiles, SearchOption.AllDirectories)
                        .Where(ext => extensions.Contains(Path.GetExtension(ext))).ToList();

                } // else, user did not click ok DoNothing();
                this.UpdateFileList();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    Resources.Unauthorized_Access_Error,
                    Resources.Unauthorized_Access_Error_Caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set up dialog box. 
            this.dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                RootFolder = Environment.SpecialFolder.Desktop
            };
        }

        private void SourceFilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dialog.Description = Resources.SourceFile_Dialog_Description;
                var result = this.dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var folderName = this.dialog.SelectedPath;
                    var extensions = this.GetRestrictedFileTypes();
                    this.SourceFileList = Directory.GetFiles(folderName, AllFiles, SearchOption.AllDirectories)
                        .Where(ext => extensions.Contains(Path.GetExtension(ext))).ToList();
                } // else, user did not click ok DoNothing();

                this.UpdateFileList();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    Resources.Unauthorized_Access_Error,
                    Resources.Unauthorized_Access_Error_Caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearFilesButton_Click(object sender, EventArgs e)
        {
            this.SourceFileList.Clear();
            this.BaseFileList.Clear();
            this.FilesRichTextBox.Clear();
        }

        private void SendRequestButton_Click(object sender, EventArgs e)
        {
            if (this.IsValidForm())
            {
                this.ErrorLabel.Text = string.Empty;
                var request = new MossRequest
                {
                    UserId = 1,
                    IsDirectoryMode = false,
                    IsBetaRequest = false,
                    Comments = "",
                    Language = "csharp",
                    NumberOfResultsToShow = 250,
                    MaxMatches = 10
                };

                request.BaseFile.AddRange(this.BaseFileList);
                request.Files.AddRange(this.SourceFileList);

                if (request.SendRequest(out var response))
                {
                    this.MossLinkLabel.Text = response;
                    var sources = await CrawResult.StartCrawTable(response);
                    //this.WebBrowser.Navigate(new Uri(response));
                    var a = 1;
                }
                else
                {
                    MessageBox.Show(
                        response,
                        Resources.Request_Error_Caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the MossLinkLabel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void MossLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(this.MossLinkLabel.Text);
            Process.Start(this.MossLinkLabel.Text);
        }

        private bool IsValidForm()
        {
            
            if (this.SourceFileList.Count == 0)
            {
                this.ErrorLabel.Text = Resources.File_List_Empty_Error;
                this.ErrorLabel.ForeColor = Color.Red;
                return false;
            }

            return true;
        }
    }
}
