namespace DemoMossTest
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.FilesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.BaseFilesButton = new System.Windows.Forms.Button();
            this.SourceFilesButton = new System.Windows.Forms.Button();
            this.ClearFilesButton = new System.Windows.Forms.Button();
            this.SendRequestButton = new System.Windows.Forms.Button();
            this.MossLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Result : ";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(125, 381);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.ErrorLabel.TabIndex = 15;
            // 
            // FilesRichTextBox
            // 
            this.FilesRichTextBox.Location = new System.Drawing.Point(76, 78);
            this.FilesRichTextBox.Name = "FilesRichTextBox";
            this.FilesRichTextBox.Size = new System.Drawing.Size(641, 265);
            this.FilesRichTextBox.TabIndex = 14;
            this.FilesRichTextBox.Text = "";
            // 
            // BaseFilesButton
            // 
            this.BaseFilesButton.Location = new System.Drawing.Point(76, 24);
            this.BaseFilesButton.Name = "BaseFilesButton";
            this.BaseFilesButton.Size = new System.Drawing.Size(112, 23);
            this.BaseFilesButton.TabIndex = 13;
            this.BaseFilesButton.Text = "Choose base files";
            this.BaseFilesButton.UseVisualStyleBackColor = true;
            this.BaseFilesButton.Click += new System.EventHandler(this.BaseFilesButton_Click);
            // 
            // SourceFilesButton
            // 
            this.SourceFilesButton.Location = new System.Drawing.Point(269, 24);
            this.SourceFilesButton.Name = "SourceFilesButton";
            this.SourceFilesButton.Size = new System.Drawing.Size(123, 23);
            this.SourceFilesButton.TabIndex = 12;
            this.SourceFilesButton.Text = "Choose Source files";
            this.SourceFilesButton.UseVisualStyleBackColor = true;
            this.SourceFilesButton.Click += new System.EventHandler(this.SourceFilesButton_Click);
            // 
            // ClearFilesButton
            // 
            this.ClearFilesButton.Location = new System.Drawing.Point(463, 24);
            this.ClearFilesButton.Name = "ClearFilesButton";
            this.ClearFilesButton.Size = new System.Drawing.Size(97, 23);
            this.ClearFilesButton.TabIndex = 11;
            this.ClearFilesButton.Text = "Clear Files";
            this.ClearFilesButton.UseVisualStyleBackColor = true;
            this.ClearFilesButton.Click += new System.EventHandler(this.ClearFilesButton_Click);
            // 
            // SendRequestButton
            // 
            this.SendRequestButton.Location = new System.Drawing.Point(625, 24);
            this.SendRequestButton.Name = "SendRequestButton";
            this.SendRequestButton.Size = new System.Drawing.Size(92, 23);
            this.SendRequestButton.TabIndex = 10;
            this.SendRequestButton.Text = "Send Request";
            this.SendRequestButton.UseVisualStyleBackColor = true;
            this.SendRequestButton.Click += new System.EventHandler(this.SendRequestButton_Click);
            // 
            // MossLinkLabel
            // 
            this.MossLinkLabel.AutoSize = true;
            this.MossLinkLabel.Location = new System.Drawing.Point(125, 382);
            this.MossLinkLabel.Name = "MossLinkLabel";
            this.MossLinkLabel.Size = new System.Drawing.Size(0, 13);
            this.MossLinkLabel.TabIndex = 17;
            this.MossLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MossLinkLabel_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MossLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.FilesRichTextBox);
            this.Controls.Add(this.BaseFilesButton);
            this.Controls.Add(this.SourceFilesButton);
            this.Controls.Add(this.ClearFilesButton);
            this.Controls.Add(this.SendRequestButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.RichTextBox FilesRichTextBox;
        private System.Windows.Forms.Button BaseFilesButton;
        private System.Windows.Forms.Button SourceFilesButton;
        private System.Windows.Forms.Button ClearFilesButton;
        private System.Windows.Forms.Button SendRequestButton;
        private System.Windows.Forms.LinkLabel MossLinkLabel;
    }
}

