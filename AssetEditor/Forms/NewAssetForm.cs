// <copyright file="NewAssetForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.AssetEditor.Forms
{
    using System.Windows.Forms;

    /// <summary>
    /// Used to create a new asset
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NewAssetForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewAssetForm" /> class.
        /// </summary>
        public NewAssetForm()
        {
            this.InitializeComponent();
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
        public int AssetType
        {
            get
            {
                return this.AssetTypeCombobox.SelectedIndex;
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
    }
}
