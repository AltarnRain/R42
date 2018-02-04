﻿namespace Round42.AssetEditor.Forms
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
            this.ListPanel = new System.Windows.Forms.Panel();
            this.AssetListBox = new System.Windows.Forms.ListBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddAsset = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimatorTab = new System.Windows.Forms.TabControl();
            this.PropertiesTab = new System.Windows.Forms.TabPage();
            this.AnimationTab = new System.Windows.Forms.TabPage();
            this.DrawerPanel = new System.Windows.Forms.Panel();
            this.PaletPanel = new System.Windows.Forms.Panel();
            this.Tools = new System.Windows.Forms.Panel();
            this.SelectFrameCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddFrameButton = new System.Windows.Forms.Button();
            this.RemoveFrameButton = new System.Windows.Forms.Button();
            this.ListPanel.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.AnimatorTab.SuspendLayout();
            this.AnimationTab.SuspendLayout();
            this.Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListPanel
            // 
            this.ListPanel.Controls.Add(this.AssetListBox);
            this.ListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListPanel.Location = new System.Drawing.Point(0, 24);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(200, 609);
            this.ListPanel.TabIndex = 0;
            // 
            // AssetListBox
            // 
            this.AssetListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetListBox.FormattingEnabled = true;
            this.AssetListBox.Location = new System.Drawing.Point(0, 0);
            this.AssetListBox.Name = "AssetListBox";
            this.AssetListBox.Size = new System.Drawing.Size(200, 609);
            this.AssetListBox.TabIndex = 0;
            this.AssetListBox.SelectedIndexChanged += new System.EventHandler(this.AssetListBox_SelectedIndexChanged);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(901, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAsset});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // AddAsset
            // 
            this.AddAsset.Name = "AddAsset";
            this.AddAsset.Size = new System.Drawing.Size(127, 22);
            this.AddAsset.Text = "Add Asset";
            this.AddAsset.Click += new System.EventHandler(this.AddAsset_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(107, 22);
            this.About.Text = "About";
            // 
            // AnimatorTab
            // 
            this.AnimatorTab.Controls.Add(this.PropertiesTab);
            this.AnimatorTab.Controls.Add(this.AnimationTab);
            this.AnimatorTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimatorTab.Location = new System.Drawing.Point(200, 24);
            this.AnimatorTab.Name = "AnimatorTab";
            this.AnimatorTab.SelectedIndex = 0;
            this.AnimatorTab.Size = new System.Drawing.Size(701, 609);
            this.AnimatorTab.TabIndex = 3;
            // 
            // PropertiesTab
            // 
            this.PropertiesTab.Location = new System.Drawing.Point(4, 22);
            this.PropertiesTab.Name = "PropertiesTab";
            this.PropertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropertiesTab.Size = new System.Drawing.Size(693, 583);
            this.PropertiesTab.TabIndex = 0;
            this.PropertiesTab.Text = "Properties";
            this.PropertiesTab.UseVisualStyleBackColor = true;
            // 
            // AnimationTab
            // 
            this.AnimationTab.Controls.Add(this.DrawerPanel);
            this.AnimationTab.Controls.Add(this.PaletPanel);
            this.AnimationTab.Controls.Add(this.Tools);
            this.AnimationTab.Location = new System.Drawing.Point(4, 22);
            this.AnimationTab.Name = "AnimationTab";
            this.AnimationTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnimationTab.Size = new System.Drawing.Size(693, 583);
            this.AnimationTab.TabIndex = 1;
            this.AnimationTab.Text = "Animation";
            this.AnimationTab.UseVisualStyleBackColor = true;
            // 
            // DrawerPanel
            // 
            this.DrawerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawerPanel.Location = new System.Drawing.Point(47, 44);
            this.DrawerPanel.Name = "DrawerPanel";
            this.DrawerPanel.Size = new System.Drawing.Size(643, 536);
            this.DrawerPanel.TabIndex = 1;
            // 
            // PaletPanel
            // 
            this.PaletPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PaletPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PaletPanel.Location = new System.Drawing.Point(3, 44);
            this.PaletPanel.Name = "PaletPanel";
            this.PaletPanel.Size = new System.Drawing.Size(44, 536);
            this.PaletPanel.TabIndex = 0;
            // 
            // Tools
            // 
            this.Tools.BackColor = System.Drawing.Color.Silver;
            this.Tools.Controls.Add(this.RemoveFrameButton);
            this.Tools.Controls.Add(this.AddFrameButton);
            this.Tools.Controls.Add(this.label1);
            this.Tools.Controls.Add(this.SelectFrameCombobox);
            this.Tools.Dock = System.Windows.Forms.DockStyle.Top;
            this.Tools.Location = new System.Drawing.Point(3, 3);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(687, 41);
            this.Tools.TabIndex = 0;
            // 
            // SelectFrameCombobox
            // 
            this.SelectFrameCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectFrameCombobox.FormattingEnabled = true;
            this.SelectFrameCombobox.Location = new System.Drawing.Point(44, 14);
            this.SelectFrameCombobox.Name = "SelectFrameCombobox";
            this.SelectFrameCombobox.Size = new System.Drawing.Size(121, 21);
            this.SelectFrameCombobox.TabIndex = 0;
            this.SelectFrameCombobox.SelectedIndexChanged += new System.EventHandler(this.SelectFrameCombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frame";
            // 
            // AddFrameButton
            // 
            this.AddFrameButton.Location = new System.Drawing.Point(171, 14);
            this.AddFrameButton.Name = "AddFrameButton";
            this.AddFrameButton.Size = new System.Drawing.Size(75, 23);
            this.AddFrameButton.TabIndex = 2;
            this.AddFrameButton.Text = "Add";
            this.AddFrameButton.UseVisualStyleBackColor = true;
            this.AddFrameButton.Click += new System.EventHandler(this.AddFrameButton_Click);
            // 
            // RemoveFrameButton
            // 
            this.RemoveFrameButton.Location = new System.Drawing.Point(252, 15);
            this.RemoveFrameButton.Name = "RemoveFrameButton";
            this.RemoveFrameButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveFrameButton.TabIndex = 3;
            this.RemoveFrameButton.Text = "Remove";
            this.RemoveFrameButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 633);
            this.Controls.Add(this.AnimatorTab);
            this.Controls.Add(this.ListPanel);
            this.Controls.Add(this.MainMenu);
            this.Name = "MainForm";
            this.Text = "Asset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ListPanel.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.AnimatorTab.ResumeLayout(false);
            this.AnimationTab.ResumeLayout(false);
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ListPanel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddAsset;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.TabControl AnimatorTab;
        private System.Windows.Forms.TabPage PropertiesTab;
        private System.Windows.Forms.TabPage AnimationTab;
        private System.Windows.Forms.ListBox AssetListBox;
        private System.Windows.Forms.Panel DrawerPanel;
        private System.Windows.Forms.Panel PaletPanel;
        private System.Windows.Forms.Panel Tools;
        private System.Windows.Forms.ComboBox SelectFrameCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemoveFrameButton;
        private System.Windows.Forms.Button AddFrameButton;
    }
}

