// <copyright file="NewAsset.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.AssetEditor.Forms
{
    using System.Windows.Forms;
    using Round42.Models;

    /// <summary>
    /// Used to create a new asset
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NewAssetForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewAssetForm"/> class.
        /// </summary>
        private NewAssetForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the asset model.
        /// </summary>
        /// <value>
        /// The asset model.
        /// </value>
        public AssetModel AssetModel { get; private set; }

        /// <summary>
        /// Adds the asset.
        /// </summary>
        /// <returns>An asset model</returns>
        public static AssetModel AddAsset()
        {
            var form = new NewAssetForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                return form.AssetModel;
            }
            else
            {
                return null;
            }
        }
    }
}
