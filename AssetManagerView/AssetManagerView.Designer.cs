namespace BlockEngine
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
            this.tspButtonBar = new System.Windows.Forms.ToolStrip();
            this.btnIncreaseBlocks = new System.Windows.Forms.ToolStripButton();
            this.btnDecreaseBlocks = new System.Windows.Forms.ToolStripButton();
            this.pnlBlocks = new System.Windows.Forms.Panel();
            this.mnuMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBlocks);
            this.pnlMain.Controls.Add(this.tspButtonBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(186, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(581, 511);
            this.pnlMain.TabIndex = 2;
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
            // pnlBlocks
            // 
            this.pnlBlocks.BackColor = System.Drawing.Color.Black;
            this.pnlBlocks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBlocks.Cursor = System.Windows.Forms.Cursors.No;
            this.pnlBlocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBlocks.Location = new System.Drawing.Point(0, 25);
            this.pnlBlocks.Name = "pnlBlocks";
            this.pnlBlocks.Size = new System.Drawing.Size(581, 486);
            this.pnlBlocks.TabIndex = 1;
            // 
            // AssetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 535);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lbAssets);
            this.Controls.Add(this.mnuMain);
            this.Name = "AssetManager";
            this.Text = "Asset Manager";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
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
        private System.Windows.Forms.Panel pnlBlocks;
    }
}

