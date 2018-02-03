// <copyright file="NewAssetForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.AssetEditor.Forms
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
            this.AssetNameTextBox = new System.Windows.Forms.TextBox();
            this.FramesTextBox = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AssetTypeCombobox = new System.Windows.Forms.ComboBox();
            this.XBlocksTextBox = new System.Windows.Forms.TextBox();
            this.YBlocksTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AssetNameTextBox
            // 
            this.AssetNameTextBox.Location = new System.Drawing.Point(63, 12);
            this.AssetNameTextBox.Name = "AssetNameTextBox";
            this.AssetNameTextBox.Size = new System.Drawing.Size(235, 20);
            this.AssetNameTextBox.TabIndex = 10;
            // 
            // FramesTextBox
            // 
            this.FramesTextBox.Location = new System.Drawing.Point(63, 64);
            this.FramesTextBox.Name = "FramesTextBox";
            this.FramesTextBox.Size = new System.Drawing.Size(57, 20);
            this.FramesTextBox.TabIndex = 30;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(146, 143);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 60;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(223, 143);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 999;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
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
            // AssetTypeCombobox
            // 
            this.AssetTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssetTypeCombobox.FormattingEnabled = true;
            this.AssetTypeCombobox.Location = new System.Drawing.Point(63, 37);
            this.AssetTypeCombobox.Name = "AssetTypeCombobox";
            this.AssetTypeCombobox.Size = new System.Drawing.Size(235, 21);
            this.AssetTypeCombobox.TabIndex = 20;
            // 
            // XBlocksTextBox
            // 
            this.XBlocksTextBox.Location = new System.Drawing.Point(63, 90);
            this.XBlocksTextBox.Name = "XBlocksTextBox";
            this.XBlocksTextBox.Size = new System.Drawing.Size(57, 20);
            this.XBlocksTextBox.TabIndex = 40;
            // 
            // YBlocksTextBox
            // 
            this.YBlocksTextBox.Location = new System.Drawing.Point(63, 116);
            this.YBlocksTextBox.Name = "YBlocksTextBox";
            this.YBlocksTextBox.Size = new System.Drawing.Size(57, 20);
            this.YBlocksTextBox.TabIndex = 50;
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
            this.Controls.Add(this.YBlocksTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.XBlocksTextBox);
            this.Controls.Add(this.AssetTypeCombobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.FramesTextBox);
            this.Controls.Add(this.AssetNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewAssetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new Asset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox AssetNameTextBox;
        private System.Windows.Forms.TextBox FramesTextBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AssetTypeCombobox;
        private System.Windows.Forms.TextBox XBlocksTextBox;
        private System.Windows.Forms.TextBox YBlocksTextBox;
        private System.Windows.Forms.Label label5;
    }
}