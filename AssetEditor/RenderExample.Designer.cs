namespace Round42.AssetEditor
{
    partial class RenderExample
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
            this.Render = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Render
            // 
            this.Render.BackColor = System.Drawing.Color.Black;
            this.Render.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Render.Location = new System.Drawing.Point(0, 0);
            this.Render.Name = "Render";
            this.Render.Size = new System.Drawing.Size(611, 382);
            this.Render.TabIndex = 0;
            // 
            // RenderExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 382);
            this.Controls.Add(this.Render);
            this.Name = "RenderExample";
            this.Text = "RenderExample";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Render;
    }
}