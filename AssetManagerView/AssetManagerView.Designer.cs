namespace AssetManagerView
{
    partial class AssetManagerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetManagerView));
            this.lbAssets = new System.Windows.Forms.ListBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.palet = new System.Windows.Forms.Panel();
            this.panelColor = new System.Windows.Forms.Panel();
            this.tspButtonBar = new System.Windows.Forms.ToolStrip();
            this.btnIncreaseBlocks = new System.Windows.Forms.ToolStripButton();
            this.btnDecreaseBlocks = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.containerPanel.SuspendLayout();
            this.tspButtonBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbAssets
            // 
            this.lbAssets.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbAssets.FormattingEnabled = true;
            this.lbAssets.Location = new System.Drawing.Point(0, 24);
            this.lbAssets.Name = "lbAssets";
            this.lbAssets.Size = new System.Drawing.Size(186, 511);
            this.lbAssets.TabIndex = 0;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(767, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.containerPanel);
            this.pnlMain.Controls.Add(this.tspButtonBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(186, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(581, 511);
            this.pnlMain.TabIndex = 2;
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.Color.White;
            this.containerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.containerPanel.Controls.Add(this.palet);
            this.containerPanel.Controls.Add(this.panelColor);
            this.containerPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 25);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(581, 486);
            this.containerPanel.TabIndex = 1;
            // 
            // palet
            // 
            this.palet.Location = new System.Drawing.Point(43, 3);
            this.palet.Name = "palet";
            this.palet.Size = new System.Drawing.Size(64, 65);
            this.palet.TabIndex = 0;
            // 
            // panelColor
            // 
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelColor.Location = new System.Drawing.Point(0, 0);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(37, 482);
            this.panelColor.TabIndex = 1;
            // 
            // tspButtonBar
            // 
            this.tspButtonBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIncreaseBlocks,
            this.btnDecreaseBlocks});
            this.tspButtonBar.Location = new System.Drawing.Point(0, 0);
            this.tspButtonBar.Name = "tspButtonBar";
            this.tspButtonBar.Size = new System.Drawing.Size(581, 25);
            this.tspButtonBar.TabIndex = 0;
            this.tspButtonBar.Text = "toolStrip1";
            // 
            // btnIncreaseBlocks
            // 
            this.btnIncreaseBlocks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnIncreaseBlocks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIncreaseBlocks.Name = "btnIncreaseBlocks";
            this.btnIncreaseBlocks.Size = new System.Drawing.Size(23, 22);
            this.btnIncreaseBlocks.Text = "+";
            this.btnIncreaseBlocks.ToolTipText = "Increase Blocks";
            // 
            // btnDecreaseBlocks
            // 
            this.btnDecreaseBlocks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDecreaseBlocks.Image = ((System.Drawing.Image)(resources.GetObject("btnDecreaseBlocks.Image")));
            this.btnDecreaseBlocks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDecreaseBlocks.Name = "btnDecreaseBlocks";
            this.btnDecreaseBlocks.Size = new System.Drawing.Size(23, 22);
            this.btnDecreaseBlocks.Text = "-";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 62);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // AssetManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 535);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lbAssets);
            this.Controls.Add(this.mnuMain);
            this.Name = "AssetManagerView";
            this.Text = "Asset Manager";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.containerPanel.ResumeLayout(false);
            this.tspButtonBar.ResumeLayout(false);
            this.tspButtonBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAssets;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStrip tspButtonBar;
        private System.Windows.Forms.ToolStripButton btnIncreaseBlocks;
        private System.Windows.Forms.ToolStripButton btnDecreaseBlocks;
        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.Panel palet;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
    }
}

