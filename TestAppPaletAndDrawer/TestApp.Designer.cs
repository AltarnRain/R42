namespace Round42.TestAppPaletAndDrawer
{
    partial class TestApp
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
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.DrawerPanel = new System.Windows.Forms.Panel();
            this.PaletPanel = new System.Windows.Forms.Panel();
            this.MainPanel.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(759, 348);
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
            this.ContainerPanel.Size = new System.Drawing.Size(759, 348);
            this.ContainerPanel.TabIndex = 1;
            // 
            // DrawerPanel
            // 
            this.DrawerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawerPanel.Location = new System.Drawing.Point(200, 0);
            this.DrawerPanel.Name = "DrawerPanel";
            this.DrawerPanel.Size = new System.Drawing.Size(555, 344);
            this.DrawerPanel.TabIndex = 1;
            // 
            // PaletPanel
            // 
            this.PaletPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PaletPanel.Location = new System.Drawing.Point(0, 0);
            this.PaletPanel.Name = "PaletPanel";
            this.PaletPanel.Size = new System.Drawing.Size(200, 344);
            this.PaletPanel.TabIndex = 0;
            // 
            // TestApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 348);
            this.Controls.Add(this.MainPanel);
            this.Name = "TestApp";
            this.Text = "Asset Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestApp_FormClosed);
            this.MainPanel.ResumeLayout(false);
            this.ContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.Panel DrawerPanel;
        private System.Windows.Forms.Panel PaletPanel;
    }
}

