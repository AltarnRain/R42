namespace LevelEditor
{
    partial class LevelEditor
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
            this.Rounds = new System.Windows.Forms.ListBox();
            this.Tools = new System.Windows.Forms.Panel();
            this.EnemyMovement = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EnemyStartingPosition = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LevelType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Asset = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rounds
            // 
            this.Rounds.Dock = System.Windows.Forms.DockStyle.Left;
            this.Rounds.FormattingEnabled = true;
            this.Rounds.Location = new System.Drawing.Point(0, 0);
            this.Rounds.Name = "Rounds";
            this.Rounds.Size = new System.Drawing.Size(199, 524);
            this.Rounds.TabIndex = 0;
            this.Rounds.SelectedIndexChanged += new System.EventHandler(this.Rounds_SelectedIndexChanged);
            // 
            // Tools
            // 
            this.Tools.Controls.Add(this.EnemyMovement);
            this.Tools.Controls.Add(this.label5);
            this.Tools.Controls.Add(this.EnemyStartingPosition);
            this.Tools.Controls.Add(this.label4);
            this.Tools.Controls.Add(this.LevelType);
            this.Tools.Controls.Add(this.label1);
            this.Tools.Controls.Add(this.Asset);
            this.Tools.Controls.Add(this.label3);
            this.Tools.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tools.Location = new System.Drawing.Point(199, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(229, 524);
            this.Tools.TabIndex = 1;
            // 
            // EnemyMovement
            // 
            this.EnemyMovement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnemyMovement.FormattingEnabled = true;
            this.EnemyMovement.Location = new System.Drawing.Point(19, 186);
            this.EnemyMovement.Name = "EnemyMovement";
            this.EnemyMovement.Size = new System.Drawing.Size(165, 21);
            this.EnemyMovement.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Movement";
            // 
            // EnemyStartingPosition
            // 
            this.EnemyStartingPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnemyStartingPosition.FormattingEnabled = true;
            this.EnemyStartingPosition.Location = new System.Drawing.Point(19, 134);
            this.EnemyStartingPosition.Name = "EnemyStartingPosition";
            this.EnemyStartingPosition.Size = new System.Drawing.Size(165, 21);
            this.EnemyStartingPosition.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Enemy starting position";
            // 
            // LevelType
            // 
            this.LevelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LevelType.FormattingEnabled = true;
            this.LevelType.Location = new System.Drawing.Point(19, 36);
            this.LevelType.Name = "LevelType";
            this.LevelType.Size = new System.Drawing.Size(165, 21);
            this.LevelType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Level Type";
            // 
            // Asset
            // 
            this.Asset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Asset.FormattingEnabled = true;
            this.Asset.Location = new System.Drawing.Point(19, 89);
            this.Asset.Name = "Asset";
            this.Asset.Size = new System.Drawing.Size(165, 21);
            this.Asset.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Level Asset";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 524);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.Rounds);
            this.Name = "LevelEditor";
            this.Text = "Level Editor";
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Rounds;
        private System.Windows.Forms.Panel Tools;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Asset;
        private System.Windows.Forms.ComboBox LevelType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EnemyStartingPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox EnemyMovement;
        private System.Windows.Forms.Label label5;
    }
}

