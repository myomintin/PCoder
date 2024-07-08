namespace PCoder.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private MenuStrip MainMenu;
        private ToolStripMenuItem FileMenuItem;
        private ToolStripMenuItem ExitMenuItem;
        private ToolStripMenuItem PCodesMenuItem;
        private ToolStripMenuItem ImportMenuItem;
        private Panel MainPanel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainMenu = new MenuStrip();
            FileMenuItem = new ToolStripMenuItem();
            ExitMenuItem = new ToolStripMenuItem();
            PCodesMenuItem = new ToolStripMenuItem();
            ImportMenuItem = new ToolStripMenuItem();
            MainPanel = new Panel();
            MainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.ImageScalingSize = new Size(20, 20);
            MainMenu.Items.AddRange(new ToolStripItem[] { FileMenuItem, PCodesMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Padding = new Padding(7, 3, 0, 3);
            MainMenu.Size = new Size(914, 30);
            MainMenu.TabIndex = 0;
            MainMenu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            FileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExitMenuItem });
            FileMenuItem.Name = "FileMenuItem";
            FileMenuItem.Size = new Size(46, 24);
            FileMenuItem.Text = "&File";
            // 
            // ExitMenuItem
            // 
            ExitMenuItem.Name = "ExitMenuItem";
            ExitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            ExitMenuItem.Size = new Size(169, 26);
            ExitMenuItem.Text = "E&xit";
            ExitMenuItem.Click += ExitMenuItem_Click;
            // 
            // PCodesMenuItem
            // 
            PCodesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ImportMenuItem });
            PCodesMenuItem.Name = "PCodesMenuItem";
            PCodesMenuItem.Size = new Size(72, 24);
            PCodesMenuItem.Text = "&PCodes";
            // 
            // ImportMenuItem
            // 
            ImportMenuItem.Name = "ImportMenuItem";
            ImportMenuItem.Size = new Size(137, 26);
            ImportMenuItem.Text = "&Import";
            ImportMenuItem.Click += ImportMenuItem_Click;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 30);
            MainPanel.Margin = new Padding(3, 4, 3, 4);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(914, 570);
            MainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(MainPanel);
            Controls.Add(MainMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainMenu;
            Margin = new Padding(3, 4, 3, 4);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "MainForm";
            Text = "PCoder for MIMU";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}