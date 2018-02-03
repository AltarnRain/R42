// <copyright file="NewAssetForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.AssetEditor.Forms
{
    using System.Windows.Forms;
    using Round42.Models;
    using Round42.Providers;

    /// <summary>
    /// Used to create a new asset
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NewAssetForm : Form
    {
        /// <summary>
        /// The asset type name provider
        /// </summary>
        private readonly AssetTypeNameProvider assetTypeNameProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewAssetForm" /> class.
        /// </summary>
        /// <param name="assetTypeNameProvider">The asset type name provider.</param>
        public NewAssetForm(AssetTypeNameProvider assetTypeNameProvider)
        {
            this.InitializeComponent();
            this.assetTypeNameProvider = assetTypeNameProvider;

            this.AssetTypeCombobox.Items.AddRange(this.assetTypeNameProvider.GetNames().ToArray());
        }

        /// <summary>
        /// Gets the name of the asset.
        /// </summary>
        /// <value>
        /// The name of the asset.
        /// </value>
        public string AssetName
        {
            get
            {
                return this.AssetNameTextBox.Text;
            }
        }

        /// <summary>
        /// Gets the type of the asset.
        /// </summary>
        /// <value>
        /// The type of the asset.
        /// </value>
        public AssetTypes AssetType
        {
            get
            {
                return (AssetTypes)this.AssetTypeCombobox.SelectedIndex;
            }
        }

        /// <summary>
        /// Gets the frames.
        /// </summary>
        /// <value>
        /// The frames.
        /// </value>
        public int Frames
        {
            get
            {
                return int.Parse(this.FramesTextBox.Text);
            }
        }

        /// <summary>
        /// Gets the x blocks.
        /// </summary>
        /// <value>
        /// The x blocks.
        /// </value>
        public int XBlocks
        {
            get
            {
                return int.Parse(this.XBlocksTextBox.Text);
            }
        }

        /// <summary>
        /// Gets the y blocks.
        /// </summary>
        /// <value>
        /// The y blocks.
        /// </value>
        public int YBlocks
        {
            get
            {
                return int.Parse(this.YBlocksTextBox.Text);
            }
        }

        /// <summary>
        /// Handles the Click event of the OK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
