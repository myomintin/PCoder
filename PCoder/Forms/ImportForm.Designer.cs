using System.ComponentModel;

namespace PCoder.Forms
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button BrowseButton;
        private Label label2;
        private Label ImportFileLabel;
        private Button CloseButton;
        private Button ImportButton;
        private TextBox ResultTextBox;
        private Label ConnectionInfoLabel;

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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ImportFileLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionInfoLabel = new System.Windows.Forms.Label();
            base.SuspendLayout();
            this.BrowseButton.Location = new System.Drawing.Point(99, 21);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 25);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(BrowseButton_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "PCode File";
            this.ImportFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.ImportFileLabel.AutoEllipsis = true;
            this.ImportFileLabel.Location = new System.Drawing.Point(200, 26);
            this.ImportFileLabel.Name = "ImportFileLabel";
            this.ImportFileLabel.Size = new System.Drawing.Size(570, 15);
            this.ImportFileLabel.TabIndex = 6;
            this.CloseButton.Location = new System.Drawing.Point(200, 53);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 25);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(CloseButton_Click);
            this.ImportButton.Location = new System.Drawing.Point(99, 53);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 25);
            this.ImportButton.TabIndex = 8;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(ImportButton_Click);
            this.ResultTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.ResultTextBox.Location = new System.Drawing.Point(18, 93);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultTextBox.Size = new System.Drawing.Size(770, 345);
            this.ResultTextBox.TabIndex = 9;
            this.ConnectionInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.ConnectionInfoLabel.Location = new System.Drawing.Point(299, 58);
            this.ConnectionInfoLabel.Name = "ConnectionInfoLabel";
            this.ConnectionInfoLabel.Size = new System.Drawing.Size(471, 15);
            this.ConnectionInfoLabel.TabIndex = 10;
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(800, 450);
            base.Controls.Add(this.ConnectionInfoLabel);
            base.Controls.Add(this.ResultTextBox);
            base.Controls.Add(this.ImportButton);
            base.Controls.Add(this.CloseButton);
            base.Controls.Add(this.ImportFileLabel);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.BrowseButton);
            base.Name = "ImportForm";
            this.Text = "Upload Region";
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
            base.Load += new System.EventHandler(Form_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}