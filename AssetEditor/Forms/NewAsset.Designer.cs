// <copyright file="MainForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetEditor.Forms
{
    /// <summary>
    /// NewAssetForms
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class NewAssetForm
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
            this.AssetName = new System.Windows.Forms.TextBox();
            this.Frames = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.ComboBox();
            this.XBlocks = new System.Windows.Forms.TextBox();
            this.YBlocks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AssetName
            // 
            this.AssetName.Location = new System.Drawing.Point(63, 12);
            this.AssetName.Name = "AssetName";
            this.AssetName.Size = new System.Drawing.Size(235, 20);
            this.AssetName.TabIndex = 2;
            // 
            // Frames
            // 
            this.Frames.Location = new System.Drawing.Point(63, 64);
            this.Frames.Name = "Frames";
            this.Frames.Size = new System.Drawing.Size(57, 20);
            this.Frames.TabIndex = 4;
            this.Frames.TextChanged += new System.EventHandler(this.Frames_TextChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(146, 143);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 5;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(227, 143);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Frames";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "X blocks";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Type
            // 
            this.Type.FormattingEnabled = true;
            this.Type.Location = new System.Drawing.Point(63, 37);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(235, 21);
            this.Type.TabIndex = 11;
            // 
            // XBlocks
            // 
            this.XBlocks.Location = new System.Drawing.Point(63, 90);
            this.XBlocks.Name = "XBlocks";
            this.XBlocks.Size = new System.Drawing.Size(57, 20);
            this.XBlocks.TabIndex = 12;
            // 
            // YBlocks
            // 
            this.YBlocks.Location = new System.Drawing.Point(63, 116);
            this.YBlocks.Name = "YBlocks";
            this.YBlocks.Size = new System.Drawing.Size(57, 20);
            this.YBlocks.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Y block";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NewAssetForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(310, 178);
            this.ControlBox = false;
            this.Controls.Add(this.YBlocks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.XBlocks);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Frames);
            this.Controls.Add(this.AssetName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewAssetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new Asset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox AssetName;
        private System.Windows.Forms.TextBox Frames;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.TextBox XBlocks;
        private System.Windows.Forms.TextBox YBlocks;
        private System.Windows.Forms.Label label5;
    }
}