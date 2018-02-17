﻿// <copyright file="MainForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.AssetEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
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
        /// The render factory
        /// </summary>
        private readonly RenderFactory renderFactory;

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
        /// <param name="renderFactory">The render factory.</param>
        public MainForm(
            AssetManagerFactory assetManagerFactory,
            AssetProvider assetProvider,
            ViewFactory viewFactory,
            DrawerFactory drawerFactory,
            PaletFactory paletFactory,
            RenderFactory renderFactory)
        {
            this.InitializeComponent();
            this.assetProvider = assetProvider;
            this.viewFactory = viewFactory;
            this.drawerFactory = drawerFactory;
            this.paletFactory = paletFactory;
            this.renderFactory = renderFactory;

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

            this.assetManager.OnLoadFrame += (ShapeModel shapeModel) =>
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
            this.assetManager.LoadFrameByIndex(frame);
        }

        /// <summary>
        /// Updates the asset list.
        /// </summary>
        /// <param name="assets">The assets.</param>
        private void UpdateAssetList(IEnumerable<AssetModel> assets)
        {
            var assetNames = assets.Select(a => a.Name).ToArray();
            this.AssetListBox.Items.Clear();

            if (assetNames.Length > 0)
            {
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
            this.SelectFrameCombobox.SelectedIndex = this.SelectFrameCombobox.Items.Count - 1;
        }

        /// <summary>
        /// Handles the Click event of the RemoveFrameButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RemoveFrameButton_Click(object sender, EventArgs e)
        {
            this.assetManager.RemoveShapeFromAsset(this.SelectFrameCombobox.SelectedIndex);
            this.SelectFrameCombobox.SelectedIndex = 0;
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

        /// <summary>
        /// Handles the Scroll event of the ButtonSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSize_Scroll(object sender, EventArgs e)
        {
            this.drawer.RedrawButtons(this.ButtonSize.Value);
            Settings.Default.ZoomLevel = this.ButtonSize.Value;
        }

        /// <summary>
        /// Handles the ShapeOrPositionChanged event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_ShapeOrPositionChanged(object sender, EventArgs e)
        {
            Settings.Default.Top = this.Top;
            Settings.Default.Left = this.Left;
            Settings.Default.Height = this.Height;
            Settings.Default.Width = this.Width;
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
        /// Determines whether [is form open] [the specified form type].
        /// </summary>
        /// <param name="formType">Type of the form.</param>
        /// <returns>
        ///   <c>true</c> if [is form open] [the specified form type]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsFormOpen(Type formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Name == form.Name)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Handles the Shown event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Set stored position and size
            this.Left = Settings.Default.Left;
            this.Top = Settings.Default.Top;
            this.Width = Settings.Default.Width;
            this.Height = Settings.Default.Height;

            // Bind event after form is shown so it is only triggered after initual values are set.
            this.Resize += this.MainForm_ShapeOrPositionChanged;
            this.Move += this.MainForm_ShapeOrPositionChanged;
        }

        /// <summary>
        /// Handles the Click event of the CropShapesToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CropShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.assetManager.CropAndAlignAnchors();
        }

        /// <summary>
        /// Handles the Click event of the SetAnchorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SetAnchorButton_Click(object sender, EventArgs e)
        {
            this.drawer.SetAchor();
        }

        private void Render_Click(object sender, EventArgs e)
        {
            var render = this.renderFactory.Get(Settings.Default.RenderOutput);
            var assetBitmaps = render.RenderAsset(this.assetManager.CurrentAsset);
            this.assetManager.SetBitmap(assetBitmaps);
            Process.Start(Settings.Default.RenderOutput);
        }

        /// <summary>
        /// Handles the Click event of the renderAllAssetsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RenderAllAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var render = this.renderFactory.Get(Settings.Default.RenderOutput);
            var assetBitmaps = render.RenderAssets(this.assetManager.GetAssets());
            this.assetManager.SetBitmaps(assetBitmaps);
            Process.Start(Settings.Default.RenderOutput);
        }
    }
}
