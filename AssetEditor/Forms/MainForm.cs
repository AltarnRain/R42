// <copyright file="MainForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.AssetEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Extentions;
    using Providers;
    using Round42.AssetEditor.Properties;
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
        /// The drawer factory
        /// </summary>
        private readonly DrawerFactory drawerFactory;

        /// <summary>
        /// The drawer
        /// </summary>
        private readonly PaletFactory paletFactory;

        /// <summary>
        /// Gets the asset provider.
        /// </summary>
        /// <value>
        /// The asset provider.
        /// </value>
        private readonly AssetProvider assetProvider;

        /// <summary>
        /// Gets the drawer.
        /// </summary>
        /// <value>
        /// The drawer.
        /// </value>
        private readonly Drawer drawer;

        /// <summary>
        /// The palet
        /// </summary>
        private readonly Palet palet;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="assetManagerFactory">The asset manager factory.</param>
        /// <param name="assetProvider">The asset provider.</param>
        /// <param name="viewFactory">The view factory.</param>
        /// <param name="drawerFactory">The drawer factory.</param>
        /// <param name="paletFactory">The palet factory.</param>
        public MainForm(AssetManagerFactory assetManagerFactory, AssetProvider assetProvider, ViewFactory viewFactory, DrawerFactory drawerFactory, PaletFactory paletFactory)
        {
            this.InitializeComponent();
            this.assetProvider = assetProvider;
            this.viewFactory = viewFactory;
            this.drawerFactory = drawerFactory;
            this.paletFactory = paletFactory;

            var mainAssetFile = Path.Combine(Directory.GetCurrentDirectory(), AssetFile);
            this.assetManager = assetManagerFactory.Get(mainAssetFile, false);
            this.palet = this.paletFactory.Get(this.PaletPanel);
            this.drawer = this.drawerFactory.Get(this.DrawerPanel);

            this.ButtonSize.Value = Settings.Default.ZoomLevel;

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
            this.assetManager.OnNewAsset += (IEnumerable<AssetModel> assets, AssetModel asset) =>
            {
                this.UpdateAssetList(assets);
                this.AssetListBox.SetSelected(this.AssetListBox.FindString(asset.Name), true);
            };

            this.assetManager.OnAssetsLoaded += (IEnumerable<AssetModel> assets) =>
            {
                this.UpdateAssetList(assets);
            };

            this.assetManager.OnCurrentAssetChanged += (AssetModel asset) =>
            {
                this.UpdateFrameComboBox(asset);
            };

            this.assetManager.OnFrameSelected += (ShapeModel shapeModel) =>
            {
                this.drawer.DrawButtons(shapeModel, this.ButtonSize.Value);
            };

            this.palet.OnColorSelected += (System.Drawing.Color color) =>
            {
                this.drawer.SetAciveColor(color);
            };
        }

        /// <summary>
        /// Updates the frame ComboBox.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="selectIndex">Index of the select.</param>
        private void UpdateFrameComboBox(AssetModel asset, int selectIndex = 0)
        {
            var frames = Enumerable.Range(1, asset.Shapes.Count()).Select(e => e.ToString()).ToArray();
            this.SelectFrameCombobox.Items.Clear();
            this.SelectFrameCombobox.Items.AddRange(frames);
            this.SelectFrameCombobox.SelectedIndex = selectIndex;
        }

        /// <summary>
        /// Loads the frame.
        /// </summary>
        /// <param name="frame">The frame.</param>
        private void LoadFrame(int frame)
        {
            this.assetManager.SelectFrame(frame);
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
                this.AssetListBox.SelectedIndex = 0;
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
        /// Handles the Click event of the RemoveAssetToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RemoveAsset_Click(object sender, EventArgs e)
        {
            this.assetManager.Remove();
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
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AssetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var assetName = this.AssetListBox.SelectedItem as string;
            this.assetManager.LoadByName(assetName);
        }

        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.assetManager.Save();
            Settings.Default.Save();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the SelectFrameCombobox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void SelectFrameCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadFrame(sender.As<ComboBox>().SelectedIndex);
        }

        /// <summary>
        /// Handles the Click event of the AddFrameButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddFrameButton_Click(object sender, EventArgs e)
        {
            this.assetManager.AddShapeToAsset();
        }

        /// <summary>
        /// Handles the Click event of the RemoveFrameButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RemoveFrameButton_Click(object sender, EventArgs e)
        {
            this.assetManager.RemoveShapeFromAsset(this.SelectFrameCombobox.SelectedIndex);
        }

        /// <summary>
        /// Handles the Click event of the AddColumnButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddColumnRightButton_Click(object sender, EventArgs e)
        {
            this.assetManager.AddColumnRight();
        }

        /// <summary>
        /// Handles the Click event of the AddRowTopButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddRowTopButton_Click(object sender, EventArgs e)
        {
            this.assetManager.AddRowTop();
        }

        /// <summary>
        /// Handles the Click event of the RemoveRowTopButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RemoveRowTopButton_Click(object sender, EventArgs e)
        {
            this.assetManager.RemoveRowTop();
        }

        /// <summary>
        /// Handles the Click event of the AddRowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void AddRowBottomButtonButton_Click(object sender, EventArgs e)
        {
            this.assetManager.AddRowBottom();
        }

        /// <summary>
        /// Handles the Click event of the RemoveLastRowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RemoveRowBottomButton_Click(object sender, EventArgs e)
        {
            this.assetManager.RemoveRowBottom();
        }

        /// <summary>
        /// Handles the Click event of the RemoveTopRowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RemoveTopRowButton_Click(object sender, EventArgs e)
        {
            this.assetManager.RemoveRowTop();
        }

        /// <summary>
        /// Handles the Click event of the RemoveColumnLeftButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RemoveColumnLeftButton_Click(object sender, EventArgs e)
        {
            this.assetManager.RemoveColumnLeft();
        }

        /// <summary>
        /// Handles the Click event of the AddColumnLeftButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddColumnLeftButton_Click(object sender, EventArgs e)
        {
            this.assetManager.AddColumnLeft();
        }

        /// <summary>
        /// Handles the Click event of the RemoveLastColumnButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RemoveColumnRightButton_Click(object sender, EventArgs e)
        {
            this.assetManager.RemoveColumnRight();
        }

        /// <summary>
        /// Handles the Click event of the MoveUpButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            this.assetManager.MoveUp();
        }

        /// <summary>
        /// Handles the Click event of the MoveRightButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            this.assetManager.MoveRight();
        }

        /// <summary>
        /// Handles the Click event of the MoveDownButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            this.assetManager.MoveDown();
        }

        /// <summary>
        /// Handles the Click event of the MoveLeftButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void MoveLeftButton_Click(object sender, EventArgs e)
        {
            this.assetManager.MoveLeft();
        }

        private void ButtonSize_Scroll(object sender, EventArgs e)
        {
            this.drawer.RedrawButtons(this.ButtonSize.Value);
            Settings.Default.ZoomLevel = this.ButtonSize.Value;
        }
    }
}
