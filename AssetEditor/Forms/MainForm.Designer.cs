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
            this.removeAssetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimatorTab = new System.Windows.Forms.TabControl();
            this.AnimationTab = new System.Windows.Forms.TabPage();
            this.DrawerPanel = new System.Windows.Forms.Panel();
            this.PaletPanel = new System.Windows.Forms.Panel();
            this.Tools = new System.Windows.Forms.Panel();
            this.RemoveTopRowButton = new System.Windows.Forms.Button();
            this.AddRowTopButton = new System.Windows.Forms.Button();
            this.RemoveLeftColumnButton = new System.Windows.Forms.Button();
            this.AddColumnLeftButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveRightButton = new System.Windows.Forms.Button();
            this.MoveLeftButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.RemoveBottomRowButton = new System.Windows.Forms.Button();
            this.RemoveRightColumnButton = new System.Windows.Forms.Button();
            this.AddRowBottomButton = new System.Windows.Forms.Button();
            this.AddColumnRightButton = new System.Windows.Forms.Button();
            this.RemoveFrameButton = new System.Windows.Forms.Button();
            this.AddFrameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectFrameCombobox = new System.Windows.Forms.ComboBox();
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
            this.ListPanel.Size = new System.Drawing.Size(200, 407);
            this.ListPanel.TabIndex = 0;
            // 
            // AssetListBox
            // 
            this.AssetListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetListBox.FormattingEnabled = true;
            this.AssetListBox.Location = new System.Drawing.Point(0, 0);
            this.AssetListBox.Name = "AssetListBox";
            this.AssetListBox.Size = new System.Drawing.Size(200, 407);
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
            this.AddAsset,
            this.removeAssetToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // AddAsset
            // 
            this.AddAsset.Name = "AddAsset";
            this.AddAsset.Size = new System.Drawing.Size(148, 22);
            this.AddAsset.Text = "Add Asset";
            this.AddAsset.Click += new System.EventHandler(this.AddAsset_Click);
            // 
            // removeAssetToolStripMenuItem
            // 
            this.removeAssetToolStripMenuItem.Name = "removeAssetToolStripMenuItem";
            this.removeAssetToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.removeAssetToolStripMenuItem.Text = "Remove Asset";
            this.removeAssetToolStripMenuItem.Click += new System.EventHandler(this.RemoveAsset_Click);
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
            this.AnimatorTab.Controls.Add(this.AnimationTab);
            this.AnimatorTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimatorTab.Location = new System.Drawing.Point(200, 24);
            this.AnimatorTab.Name = "AnimatorTab";
            this.AnimatorTab.SelectedIndex = 0;
            this.AnimatorTab.Size = new System.Drawing.Size(701, 407);
            this.AnimatorTab.TabIndex = 3;
            // 
            // AnimationTab
            // 
            this.AnimationTab.Controls.Add(this.DrawerPanel);
            this.AnimationTab.Controls.Add(this.PaletPanel);
            this.AnimationTab.Controls.Add(this.Tools);
            this.AnimationTab.Location = new System.Drawing.Point(4, 22);
            this.AnimationTab.Name = "AnimationTab";
            this.AnimationTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnimationTab.Size = new System.Drawing.Size(693, 381);
            this.AnimationTab.TabIndex = 1;
            this.AnimationTab.Text = "Animation";
            this.AnimationTab.UseVisualStyleBackColor = true;
            // 
            // DrawerPanel
            // 
            this.DrawerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawerPanel.Location = new System.Drawing.Point(96, 31);
            this.DrawerPanel.Name = "DrawerPanel";
            this.DrawerPanel.Size = new System.Drawing.Size(594, 347);
            this.DrawerPanel.TabIndex = 1;
            this.DrawerPanel.Resize += new System.EventHandler(this.DrawerPanel_Resize);
            // 
            // PaletPanel
            // 
            this.PaletPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PaletPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaletPanel.Location = new System.Drawing.Point(96, 3);
            this.PaletPanel.Name = "PaletPanel";
            this.PaletPanel.Size = new System.Drawing.Size(594, 28);
            this.PaletPanel.TabIndex = 0;
            // 
            // Tools
            // 
            this.Tools.BackColor = System.Drawing.Color.Silver;
            this.Tools.Controls.Add(this.RemoveTopRowButton);
            this.Tools.Controls.Add(this.AddRowTopButton);
            this.Tools.Controls.Add(this.RemoveLeftColumnButton);
            this.Tools.Controls.Add(this.AddColumnLeftButton);
            this.Tools.Controls.Add(this.label5);
            this.Tools.Controls.Add(this.label4);
            this.Tools.Controls.Add(this.label3);
            this.Tools.Controls.Add(this.label2);
            this.Tools.Controls.Add(this.MoveDownButton);
            this.Tools.Controls.Add(this.MoveRightButton);
            this.Tools.Controls.Add(this.MoveLeftButton);
            this.Tools.Controls.Add(this.MoveUpButton);
            this.Tools.Controls.Add(this.RemoveBottomRowButton);
            this.Tools.Controls.Add(this.RemoveRightColumnButton);
            this.Tools.Controls.Add(this.AddRowBottomButton);
            this.Tools.Controls.Add(this.AddColumnRightButton);
            this.Tools.Controls.Add(this.RemoveFrameButton);
            this.Tools.Controls.Add(this.AddFrameButton);
            this.Tools.Controls.Add(this.label1);
            this.Tools.Controls.Add(this.SelectFrameCombobox);
            this.Tools.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tools.Location = new System.Drawing.Point(3, 3);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(93, 375);
            this.Tools.TabIndex = 0;
            // 
            // RemoveTopRowButton
            // 
            this.RemoveTopRowButton.Location = new System.Drawing.Point(11, 203);
            this.RemoveTopRowButton.Name = "RemoveTopRowButton";
            this.RemoveTopRowButton.Size = new System.Drawing.Size(31, 23);
            this.RemoveTopRowButton.TabIndex = 19;
            this.RemoveTopRowButton.Text = "/\\";
            this.RemoveTopRowButton.UseVisualStyleBackColor = true;
            this.RemoveTopRowButton.Click += new System.EventHandler(this.RemoveRowTopButton_Click);
            // 
            // AddRowTopButton
            // 
            this.AddRowTopButton.Location = new System.Drawing.Point(11, 161);
            this.AddRowTopButton.Name = "AddRowTopButton";
            this.AddRowTopButton.Size = new System.Drawing.Size(31, 23);
            this.AddRowTopButton.TabIndex = 18;
            this.AddRowTopButton.Text = "/\\";
            this.AddRowTopButton.UseVisualStyleBackColor = true;
            this.AddRowTopButton.Click += new System.EventHandler(this.AddRowTopButton_Click);
            // 
            // RemoveLeftColumnButton
            // 
            this.RemoveLeftColumnButton.Location = new System.Drawing.Point(11, 119);
            this.RemoveLeftColumnButton.Name = "RemoveLeftColumnButton";
            this.RemoveLeftColumnButton.Size = new System.Drawing.Size(31, 23);
            this.RemoveLeftColumnButton.TabIndex = 17;
            this.RemoveLeftColumnButton.Text = "<";
            this.RemoveLeftColumnButton.UseVisualStyleBackColor = true;
            this.RemoveLeftColumnButton.Click += new System.EventHandler(this.RemoveColumnLeftButton_Click);
            // 
            // AddColumnLeftButton
            // 
            this.AddColumnLeftButton.Location = new System.Drawing.Point(11, 77);
            this.AddColumnLeftButton.Name = "AddColumnLeftButton";
            this.AddColumnLeftButton.Size = new System.Drawing.Size(31, 23);
            this.AddColumnLeftButton.TabIndex = 16;
            this.AddColumnLeftButton.Text = "<";
            this.AddColumnLeftButton.UseVisualStyleBackColor = true;
            this.AddColumnLeftButton.Click += new System.EventHandler(this.AddColumnLeftButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Remove column";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Add column";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Remove row";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Add row";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(34, 280);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(26, 26);
            this.MoveDownButton.TabIndex = 11;
            this.MoveDownButton.Text = "\\/";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveRightButton
            // 
            this.MoveRightButton.Location = new System.Drawing.Point(57, 256);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(26, 26);
            this.MoveRightButton.TabIndex = 10;
            this.MoveRightButton.Text = ">";
            this.MoveRightButton.UseVisualStyleBackColor = true;
            this.MoveRightButton.Click += new System.EventHandler(this.MoveRightButton_Click);
            // 
            // MoveLeftButton
            // 
            this.MoveLeftButton.Location = new System.Drawing.Point(11, 257);
            this.MoveLeftButton.Name = "MoveLeftButton";
            this.MoveLeftButton.Size = new System.Drawing.Size(26, 26);
            this.MoveLeftButton.TabIndex = 9;
            this.MoveLeftButton.Text = "<";
            this.MoveLeftButton.UseVisualStyleBackColor = true;
            this.MoveLeftButton.Click += new System.EventHandler(this.MoveLeftButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(34, 233);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(26, 26);
            this.MoveUpButton.TabIndex = 8;
            this.MoveUpButton.Text = "/\\";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // RemoveBottomRowButton
            // 
            this.RemoveBottomRowButton.Location = new System.Drawing.Point(43, 203);
            this.RemoveBottomRowButton.Name = "RemoveBottomRowButton";
            this.RemoveBottomRowButton.Size = new System.Drawing.Size(31, 23);
            this.RemoveBottomRowButton.TabIndex = 7;
            this.RemoveBottomRowButton.Text = "\\/";
            this.RemoveBottomRowButton.UseVisualStyleBackColor = true;
            this.RemoveBottomRowButton.Click += new System.EventHandler(this.RemoveRowBottomButton_Click);
            // 
            // RemoveRightColumnButton
            // 
            this.RemoveRightColumnButton.Location = new System.Drawing.Point(43, 119);
            this.RemoveRightColumnButton.Name = "RemoveRightColumnButton";
            this.RemoveRightColumnButton.Size = new System.Drawing.Size(31, 23);
            this.RemoveRightColumnButton.TabIndex = 6;
            this.RemoveRightColumnButton.Text = ">";
            this.RemoveRightColumnButton.UseVisualStyleBackColor = true;
            this.RemoveRightColumnButton.Click += new System.EventHandler(this.RemoveColumnRightButton_Click);
            // 
            // AddRowBottomButton
            // 
            this.AddRowBottomButton.Location = new System.Drawing.Point(43, 161);
            this.AddRowBottomButton.Name = "AddRowBottomButton";
            this.AddRowBottomButton.Size = new System.Drawing.Size(31, 23);
            this.AddRowBottomButton.TabIndex = 5;
            this.AddRowBottomButton.Text = "\\/";
            this.AddRowBottomButton.UseVisualStyleBackColor = true;
            this.AddRowBottomButton.Click += new System.EventHandler(this.AddRowBottomButtonButton_Click);
            // 
            // AddColumnRightButton
            // 
            this.AddColumnRightButton.Location = new System.Drawing.Point(43, 77);
            this.AddColumnRightButton.Name = "AddColumnRightButton";
            this.AddColumnRightButton.Size = new System.Drawing.Size(31, 23);
            this.AddColumnRightButton.TabIndex = 4;
            this.AddColumnRightButton.Text = ">";
            this.AddColumnRightButton.UseVisualStyleBackColor = true;
            this.AddColumnRightButton.Click += new System.EventHandler(this.AddColumnRightButton_Click);
            // 
            // RemoveFrameButton
            // 
            this.RemoveFrameButton.Location = new System.Drawing.Point(57, 25);
            this.RemoveFrameButton.Name = "RemoveFrameButton";
            this.RemoveFrameButton.Size = new System.Drawing.Size(26, 23);
            this.RemoveFrameButton.TabIndex = 3;
            this.RemoveFrameButton.Text = "-";
            this.RemoveFrameButton.UseVisualStyleBackColor = true;
            this.RemoveFrameButton.Click += new System.EventHandler(this.RemoveFrameButton_Click);
            // 
            // AddFrameButton
            // 
            this.AddFrameButton.Location = new System.Drawing.Point(34, 25);
            this.AddFrameButton.Name = "AddFrameButton";
            this.AddFrameButton.Size = new System.Drawing.Size(30, 23);
            this.AddFrameButton.TabIndex = 2;
            this.AddFrameButton.Text = "+";
            this.AddFrameButton.UseVisualStyleBackColor = true;
            this.AddFrameButton.Click += new System.EventHandler(this.AddFrameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frame";
            // 
            // SelectFrameCombobox
            // 
            this.SelectFrameCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectFrameCombobox.FormattingEnabled = true;
            this.SelectFrameCombobox.Location = new System.Drawing.Point(3, 26);
            this.SelectFrameCombobox.Name = "SelectFrameCombobox";
            this.SelectFrameCombobox.Size = new System.Drawing.Size(36, 21);
            this.SelectFrameCombobox.TabIndex = 0;
            this.SelectFrameCombobox.SelectedIndexChanged += new System.EventHandler(this.SelectFrameCombobox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 431);
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
        private System.Windows.Forms.TabPage AnimationTab;
        private System.Windows.Forms.ListBox AssetListBox;
        private System.Windows.Forms.Panel DrawerPanel;
        private System.Windows.Forms.Panel PaletPanel;
        private System.Windows.Forms.Panel Tools;
        private System.Windows.Forms.ComboBox SelectFrameCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemoveFrameButton;
        private System.Windows.Forms.Button AddFrameButton;
        private System.Windows.Forms.Button AddRowBottomButton;
        private System.Windows.Forms.Button AddColumnRightButton;
        private System.Windows.Forms.Button RemoveBottomRowButton;
        private System.Windows.Forms.Button RemoveRightColumnButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveRightButton;
        private System.Windows.Forms.Button MoveLeftButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RemoveTopRowButton;
        private System.Windows.Forms.Button AddRowTopButton;
        private System.Windows.Forms.Button RemoveLeftColumnButton;
        private System.Windows.Forms.Button AddColumnLeftButton;
        private System.Windows.Forms.ToolStripMenuItem removeAssetToolStripMenuItem;
    }
}

