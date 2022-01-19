namespace OldUI
{
    partial class Dashboard
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OutputComboBox = new System.Windows.Forms.ComboBox();
            this.OuputLable = new System.Windows.Forms.Label();
            this.ListPanel = new System.Windows.Forms.Panel();
            this.PlayListLable = new System.Windows.Forms.Label();
            this.PlayListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DirectoryAssistButton = new System.Windows.Forms.Button();
            this.DirectoryBox = new System.Windows.Forms.TextBox();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.MusicControlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewSourceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ListPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MusicControlPanel.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Controls.Add(this.panel2);
            this.MainPanel.Controls.Add(this.ListPanel);
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Controls.Add(this.MusicControlPanel);
            this.MainPanel.Location = new System.Drawing.Point(0, 27);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(708, 674);
            this.MainPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.OutputComboBox);
            this.panel2.Controls.Add(this.OuputLable);
            this.panel2.Location = new System.Drawing.Point(12, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 38);
            this.panel2.TabIndex = 7;
            // 
            // OutputComboBox
            // 
            this.OutputComboBox.FormattingEnabled = true;
            this.OutputComboBox.Location = new System.Drawing.Point(128, 3);
            this.OutputComboBox.Name = "OutputComboBox";
            this.OutputComboBox.Size = new System.Drawing.Size(164, 24);
            this.OutputComboBox.TabIndex = 2;
            // 
            // OuputLable
            // 
            this.OuputLable.AutoSize = true;
            this.OuputLable.Location = new System.Drawing.Point(3, 3);
            this.OuputLable.Name = "OuputLable";
            this.OuputLable.Size = new System.Drawing.Size(102, 17);
            this.OuputLable.TabIndex = 1;
            this.OuputLable.Text = "Current Output";
            // 
            // ListPanel
            // 
            this.ListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPanel.Controls.Add(this.PlayListLable);
            this.ListPanel.Controls.Add(this.PlayListBox);
            this.ListPanel.Location = new System.Drawing.Point(353, 6);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(351, 596);
            this.ListPanel.TabIndex = 6;
            // 
            // PlayListLable
            // 
            this.PlayListLable.AutoSize = true;
            this.PlayListLable.Location = new System.Drawing.Point(3, 3);
            this.PlayListLable.Name = "PlayListLable";
            this.PlayListLable.Size = new System.Drawing.Size(52, 17);
            this.PlayListLable.TabIndex = 5;
            this.PlayListLable.Text = "Playlist";
            // 
            // PlayListBox
            // 
            this.PlayListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PlayListBox.FormattingEnabled = true;
            this.PlayListBox.ItemHeight = 16;
            this.PlayListBox.Location = new System.Drawing.Point(7, 23);
            this.PlayListBox.Name = "PlayListBox";
            this.PlayListBox.Size = new System.Drawing.Size(337, 548);
            this.PlayListBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DirectoryAssistButton);
            this.panel1.Controls.Add(this.DirectoryBox);
            this.panel1.Controls.Add(this.DirectoryLabel);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 38);
            this.panel1.TabIndex = 3;
            // 
            // DirectoryAssistButton
            // 
            this.DirectoryAssistButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DirectoryAssistButton.Location = new System.Drawing.Point(299, 0);
            this.DirectoryAssistButton.Name = "DirectoryAssistButton";
            this.DirectoryAssistButton.Size = new System.Drawing.Size(30, 22);
            this.DirectoryAssistButton.TabIndex = 3;
            this.DirectoryAssistButton.Text = "...";
            this.DirectoryAssistButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DirectoryAssistButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.DirectoryAssistButton.UseVisualStyleBackColor = true;
            this.DirectoryAssistButton.Click += new System.EventHandler(this.DirectoryAssistButtonClick);
            // 
            // DirectoryBox
            // 
            this.DirectoryBox.Location = new System.Drawing.Point(128, 0);
            this.DirectoryBox.Name = "DirectoryBox";
            this.DirectoryBox.Size = new System.Drawing.Size(164, 22);
            this.DirectoryBox.TabIndex = 2;
            this.DirectoryBox.TextChanged += new System.EventHandler(this.DirectoryBoxTextChanged);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Location = new System.Drawing.Point(3, 3);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(116, 17);
            this.DirectoryLabel.TabIndex = 1;
            this.DirectoryLabel.Text = "Current Directory";
            // 
            // MusicControlPanel
            // 
            this.MusicControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MusicControlPanel.Controls.Add(this.PlayButton);
            this.MusicControlPanel.Controls.Add(this.StopButton);
            this.MusicControlPanel.Controls.Add(this.PauseButton);
            this.MusicControlPanel.Location = new System.Drawing.Point(184, 612);
            this.MusicControlPanel.Name = "MusicControlPanel";
            this.MusicControlPanel.Size = new System.Drawing.Size(521, 59);
            this.MusicControlPanel.TabIndex = 0;
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(3, 3);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(166, 56);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButtonClick);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(175, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(166, 56);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(347, 3);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(166, 56);
            this.PauseButton.TabIndex = 2;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 704);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(708, 22);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "MainStatusStrip";
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.musicToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(708, 28);
            this.MainMenuStrip.TabIndex = 2;
            this.MainMenuStrip.Text = "MainMenuStrip";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewSourceFileToolStripMenuItem});
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            this.musicToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.musicToolStripMenuItem.Text = "Music";
            // 
            // createNewSourceFileToolStripMenuItem
            // 
            this.createNewSourceFileToolStripMenuItem.Name = "createNewSourceFileToolStripMenuItem";
            this.createNewSourceFileToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.createNewSourceFileToolStripMenuItem.Text = "Create New SourceFile";
            this.createNewSourceFileToolStripMenuItem.Click += new System.EventHandler(this.CreateNewSourceFileToolStripMenuItemClick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 726);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.Controls.Add(this.MainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(726, 773);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.MainPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ListPanel.ResumeLayout(false);
            this.ListPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MusicControlPanel.ResumeLayout(false);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.FlowLayoutPanel MusicControlPanel;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Panel ListPanel;
        private System.Windows.Forms.Label PlayListLable;
        private System.Windows.Forms.ListBox PlayListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox DirectoryBox;
        private System.Windows.Forms.Label DirectoryLabel;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox OutputComboBox;
        private System.Windows.Forms.Label OuputLable;
        private System.Windows.Forms.Button DirectoryAssistButton;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewSourceFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

