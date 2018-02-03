// <copyright file="MainForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.AssetEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Providers;
    using Round42.CustomComponents;
    using Round42.Factories;
    using Round42.Factories.Factories;
    using Round42.Managers;
    using Round42.Models;

    /// <summary>
    /// Editor for assets
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        /// <summary>
        /// The asset file
        /// </summary>
        private const string AssetFile = "Assets.json";

        /// <summary>
        /// The asset manager
        /// </summary>
        private readonly AssetManager assetManager;

        /// <summary>
        /// The view factory
        /// </summary>
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// The drawer
        /// </summary>
        private readonly Drawer drawer;
        private readonly PaletFactory paletFactory;

        /// <summary>
        /// Gets the asset provider.
        /// </summary>
        /// <value>
        /// The asset provider.
        /// </value>
        private readonly AssetProvider assetProvider;

        /// <summary>
        /// The palet
        /// </summary>
        private readonly Palet palet;

        /// <summary>
        /// The current asset
        /// </summary>
        private string currentAsset;

        /// <summary>
        /// Gets or sets the current frame.
        /// </summary>
        /// <value>
        /// The current frame.
        /// </value>
        private int currentFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="assetManagerFactory">The asset manager factory.</param>
        /// <param name="assetProvider">The asset provider.</param>
        /// <param name="viewFactory">The view factory.</param>
        /// <param name="drawer">The drawer.</param>
        /// <param name="paletFactory">The palet factory.</param>
        public MainForm(AssetManagerFactory assetManagerFactory, AssetProvider assetProvider, ViewFactory viewFactory, Drawer drawer, PaletFactory paletFactory)
        {
            this.InitializeComponent();
            this.assetProvider = assetProvider;
            this.viewFactory = viewFactory;
            this.drawer = drawer;
            this.paletFactory = paletFactory;

            var mainAssetFile = Path.Combine(Directory.GetCurrentDirectory(), AssetFile);
            this.assetManager = assetManagerFactory.Get(mainAssetFile, false);
            this.palet = this.paletFactory.Get();
            this.PaletPanel.Controls.Add(this.palet);
            this.DrawerPanel.Controls.Add(drawer);

            // Event handler setup must precede loading assets but happen after the asset manager is created
            this.SetupEventHandlers();

            // Load assets and trigger events.
            this.assetManager.LoadAssets();
        }

        /// <summary>
        /// Setups the event handlers.
        /// </summary>
        private void SetupEventHandlers()
        {
            this.assetManager.OnAssetsChanged += this.AssetManager_OnAssetsChanged;
            this.assetManager.OnNewAsset += this.AssetManager_OnNewAsset;
            this.assetManager.OnAssetLoaded += this.AssetManager_OnAssetLoaded;

            this.palet.OnColorSelected += this.Palet_OnColorSelected;
        }

        /// <summary>
        /// Palets the on color selected.
        /// </summary>
        /// <param name="color">The color.</param>
        private void Palet_OnColorSelected(System.Drawing.Color color)
        {
            this.drawer.SetAciveColor(color);
        }

        /// <summary>
        /// Assets the manager on asset loaded.
        /// </summary>
        /// <param name="asset">The asset.</param>
        private void AssetManager_OnAssetLoaded(AssetModel asset)
        {
            this.currentFrame = 0;
            this.currentAsset = asset.Name;
            this.LoadCurrentFrame();
        }

        /// <summary>
        /// Loads the current frame.
        /// </summary>
        private void LoadCurrentFrame()
        {
            var shape = this.assetManager.GetFrameFromAsset(this.currentAsset, this.currentFrame);
            this.drawer.DrawButtons(shape);
        }

        /// <summary>
        /// Assets the manager on new asset.
        /// </summary>
        /// <param name="asset">The asset.</param>
        private void AssetManager_OnNewAsset(Models.AssetModel asset)
        {
            this.AssetListBox.SetSelected(this.AssetListBox.FindString(asset.Name), true);
        }

        /// <summary>
        /// Assets the manager on assets changed.
        /// </summary>
        /// <param name="assets">The assets.</param>
        private void AssetManager_OnAssetsChanged(System.Collections.Generic.IEnumerable<Models.AssetModel> assets)
        {
            this.UpdateAssetList(assets);
        }

        /// <summary>
        /// Updates the asset list.
        /// </summary>
        /// <param name="assets">The assets.</param>
        private void UpdateAssetList(IEnumerable<AssetModel> assets)
        {
            var assetNames = assets.Select(a => a.Name).ToArray();

            if (assetNames.Length > 0)
            {
                this.AssetListBox.Items.Clear();
                this.AssetListBox.Items.AddRange(assetNames);
            }
        }

        /// <summary>
        /// Handles the Click event of the AddAsset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddAsset_Click(object sender, EventArgs e)
        {
            var newAsset = this.viewFactory.Get<NewAssetForm>();
            if (newAsset.ShowDialog() == DialogResult.OK)
            {
                this.assetManager.Add(newAsset.AssetName, newAsset.AssetType, newAsset.Frames, newAsset.XBlocks, newAsset.YBlocks);
            }
        }

        /// <summary>
        /// Handles the Click event of the ExitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the AssetListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AssetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var assetName = this.AssetListBox.SelectedItem as string;
            this.currentAsset = assetName;
            this.assetManager.LoadByName(assetName);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.assetManager.Save();
        }
    }
}
