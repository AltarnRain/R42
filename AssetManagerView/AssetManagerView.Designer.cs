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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaletPanel = new System.Windows.Forms.Panel();
            this.DrawerPanel = new System.Windows.Forms.Panel();
            this.MainMenu.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(767, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MainMenu";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ContainerPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(767, 511);
            this.MainPanel.TabIndex = 2;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.BackColor = System.Drawing.Color.White;
            this.ContainerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContainerPanel.Controls.Add(this.DrawerPanel);
            this.ContainerPanel.Controls.Add(this.PaletPanel);
            this.ContainerPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(767, 511);
            this.ContainerPanel.TabIndex = 1;
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Name = "NewMenuItem";
            this.NewMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NewMenuItem.Text = "New";
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // PaletPanel
            // 
            this.PaletPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PaletPanel.Location = new System.Drawing.Point(0, 0);
            this.PaletPanel.Name = "PaletPanel";
            this.PaletPanel.Size = new System.Drawing.Size(200, 507);
            this.PaletPanel.TabIndex = 0;
            // 
            // DrawerPanel
            // 
            this.DrawerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawerPanel.Location = new System.Drawing.Point(200, 0);
            this.DrawerPanel.Name = "DrawerPanel";
            this.DrawerPanel.Size = new System.Drawing.Size(563, 507);
            this.DrawerPanel.TabIndex = 1;
            // 
            // AssetManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 535);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MainMenu);
            this.Name = "AssetManagerView";
            this.Text = "Asset Manager";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem NewMenuItem;
        private System.Windows.Forms.Panel DrawerPanel;
        private System.Windows.Forms.Panel PaletPanel;
    }
}

