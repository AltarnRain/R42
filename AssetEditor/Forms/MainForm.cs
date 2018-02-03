﻿// <copyright file="MainForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.AssetEditor.Forms
{
    using System;
    using System.Windows.Forms;
    using AssetEditor.Properties;
    using Providers;
    using Round42.Factories;
    using Round42.Managers;

    /// <summary>
    /// Editor for assets
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        /// <summary>
        /// The asset manager
        /// </summary>
        private readonly AssetManager assetManager;

        /// <summary>
        /// The view factory
        /// </summary>
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="assetManagerFactory">The asset manager factory.</param>
        /// <param name="assetProvider">The asset provider.</param>
        /// <param name="viewFactory">The view factory.</param>
        public MainForm(AssetManagerFactory assetManagerFactory,  AssetProvider assetProvider, ViewFactory viewFactory)
        {
            this.InitializeComponent();
            this.AssetProvider = assetProvider;
            this.viewFactory = viewFactory;
            this.assetManager = assetManagerFactory.Get(Settings.Default.AssetFile);
        }

        /// <summary>
        /// Gets the asset provider.
        /// </summary>
        /// <value>
        /// The asset provider.
        /// </value>
        public AssetProvider AssetProvider { get; }

        /// <summary>
        /// Handles the Click event of the AddAsset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddAsset_Click(object sender, EventArgs e)
        {
            var newAsset = this.viewFactory.Get<NewAssetForm>();
            if (newAsset.ShowDialog() == DialogResult.OK)
            {
            }
        }
    }
}