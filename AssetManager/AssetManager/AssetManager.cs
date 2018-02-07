// <copyright file="AssetManager.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Managers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Exceptions;
    using Extentions;
    using Providers;
    using Round42.Models;
    using Round42.Models.Extentions;

    /// <summary>
    /// Manages assets
    /// </summary>
    public class AssetManager
    {
        /// <summary>
        /// The asset provider
        /// </summary>
        private readonly AssetProvider assetProvider;

        /// <summary>
        /// The shape provider
        /// </summary>
        private readonly ShapeProvider shapeProvider;

        /// <summary>
        /// The asset file
        /// </summary>
        private string assetFile;

        /// <summary>
        /// The current asset
        /// </summary>
        private AssetModel currentAsset;

        /// <summary>
        /// The current frame
        /// </summary>
        private ShapeModel currentFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager" /> class.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        /// <param name="assetProvider">The asset provider.</param>
        /// <param name="shapeProvider">The shape provider.</param>
        /// <param name="loadOnCreate">if set to <c>true</c> [load on create].</param>
        public AssetManager(string assetFile, AssetProvider assetProvider, ShapeProvider shapeProvider, bool loadOnCreate = false)
        {
            this.assetProvider = assetProvider;
            this.shapeProvider = shapeProvider;
            this.assetFile = assetFile;
            this.SetupAssets(this.assetFile);
        }

        /// <summary>
        /// Raised when the asset collection changes
        /// </summary>
        /// <param name="assets">The assets.</param>
        /// <param name="asset">The asset.</param>
        public delegate void NewAsset(IEnumerable<AssetModel> assets, AssetModel asset);

        /// <summary>
        /// Raised when the current asset changes
        /// </summary>
        /// <param name="asset">The asset.</param>
        public delegate void CurrentAssetChanged(AssetModel asset);

        /// <summary>
        /// Raised when the current asset changes
        /// </summary>
        /// <param name="assets">The assets.</param>
        public delegate void AssetsLoaded(IEnumerable<AssetModel> assets);

        /// <summary>
        /// Raised when a frame is selected.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public delegate void FrameSelected(ShapeModel shapeModel);

        /// <summary>
        /// Occurs when [on new asset].
        /// </summary>
        public event NewAsset OnNewAsset;

        /// <summary>
        /// Occurs when [on loaded asset].
        /// </summary>
        public event AssetsLoaded OnAssetsLoaded;

        /// <summary>
        /// Occurs when [on loaded asset].
        /// </summary>
        public event CurrentAssetChanged OnCurrentAssetChanged;

        /// <summary>
        /// Occurs when [on frame selected].
        /// </summary>
        public event FrameSelected OnFrameSelected;

        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<AssetModel> Assets { get; private set; }

        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <returns>
        ///   <see cref="IEnumerable{AssetModel}" />
        /// </returns>
        public IEnumerable<AssetModel> GetAssets()
        {
            return this.Assets.AsEnumerable();
        }

        /// <summary>
        /// Gets the frame.
        /// </summary>
        /// <param name="frame">The frame.</param>
        public void SelectFrame(int frame)
        {
            this.currentFrame = this.currentAsset.Shapes[frame];
            this.OnFrameSelected?.Invoke(this.currentFrame);
        }

        /// <summary>
        /// Adds the specified width.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="assetType">Type of the asset.</param>
        /// <param name="frames">The number of shapes.</param>
        /// <param name="columns">The width.</param>
        /// <param name="rows">The height.</param>
        /// <exception cref="DuplicateEntryException">Asset {0} already exists".FormatString(assetName)</exception>
        public void Add(string assetName, AssetTypes assetType, int frames, int columns, int rows)
        {
            if (this.Assets.Any(a => a.Name == assetName))
            {
                throw new DuplicateEntryException("Asset {0} already exists".FormatString(assetName));
            }

            var newAsset = this.assetProvider.Create(assetName, assetType, frames, columns, rows);
            this.Add(newAsset);
            this.Save();
        }

        /// <summary>
        /// Adds the shape.
        /// </summary>
        public void AddShapeToAsset()
        {
            var newShape = this.shapeProvider.Create(this.currentAsset.Columns, this.currentAsset.Rows);
            this.currentAsset.Shapes.Add(newShape);
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this.Assets);
            json.SaveToFile(this.assetFile);
        }

        /// <summary>
        /// Adds the specified new asset.
        /// </summary>
        /// <param name="newAsset">The new asset.</param>
        public void Add(AssetModel newAsset)
        {
            this.Assets.Add(newAsset);
            this.OnNewAsset?.Invoke(this.Assets, newAsset);
        }

        /// <summary>
        /// Removes this instance.
        /// </summary>
        public void Remove()
        {
            if (this.currentAsset != null)
            {
                this.Assets.Remove(this.currentAsset);
                this.OnAssetsLoaded?.Invoke(this.Assets);
            }
        }

        /// <summary>
        /// Removes the specified current asset.
        /// </summary>
        /// <param name="shapeIndex">Index of the shape.</param>
        public void RemoveShapeFromAsset(int shapeIndex)
        {
            if (this.currentAsset.Shapes.Count() > 1)
            {
                this.currentAsset.Shapes.RemoveAt(shapeIndex);
                this.OnCurrentAssetChanged?.Invoke(this.currentAsset);
            }
        }

        /// <summary>
        /// Adds the shape to asset.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void AddShapeToAsset(string assetName)
        {
            this.SetByName(assetName);
            this.AddShapeToAsset();
        }

        /// <summary>
        /// Adds the column left.
        /// </summary>
        public void AddColumnLeft()
        {
            foreach (var shape in this.currentAsset.Shapes)
            {
                shape.AddColumnLeft();
            }

            this.currentAsset.Columns++;
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        public void AddColumnRight()
        {
            foreach (var shape in this.currentAsset.Shapes)
            {
                shape.AddColumnRight();
            }

            this.currentAsset.Columns++;
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Adds the row top.
        /// </summary>
        public void AddRowTop()
        {
            foreach (var shape in this.currentAsset.Shapes)
            {
                shape.AddRowTop();
            }

            this.currentAsset.Rows++;
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Adds the row.
        /// </summary>
        public void AddRowBottom()
        {
            foreach (var shape in this.currentAsset.Shapes)
            {
                shape.AddRowBottom();
            }

            this.currentAsset.Rows++;
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Removes the row top.
        /// </summary>
        public void RemoveRowTop()
        {
            this.currentFrame.RemoveRowTop();
            this.currentAsset.Rows--;
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Removes the last row.
        /// </summary>
        public void RemoveRowBottom()
        {
            if (this.currentAsset.Rows > 1)
            {
                this.currentAsset.Shapes.ForEach(s => s.RemoveRowRight());
                this.currentAsset.Rows--;
                this.TriggerOnCurrentAssetChanged();
            }
        }

        /// <summary>
        /// Removes the last column.
        /// </summary>
        public void RemoveColumnLeft()
        {
            if (this.currentAsset.Columns > 1)
            {
                this.currentAsset.Shapes.ForEach(s => s.RemoveColumnLeft());
                this.currentAsset.Columns--;
                this.TriggerOnCurrentAssetChanged();
            }
        }

        /// <summary>
        /// Removes the column right.
        /// </summary>
        public void RemoveColumnRight()
        {
            if (this.currentAsset.Columns > 1)
            {
                this.currentAsset.Shapes.ForEach(s => s.RemoveColumnRight());
                this.currentAsset.Columns--;
                this.TriggerOnCurrentAssetChanged();
            }
        }

        /// <summary>
        /// Loads the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void LoadByName(string assetName)
        {
            this.SetByName(assetName);
            this.OnCurrentAssetChanged?.Invoke(this.currentAsset);
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void LoadAssets()
        {
            this.SetupAssets(this.assetFile);
        }

        /// <summary>
        /// Move blocks in frame to the left.
        /// </summary>
        public void MoveLeft()
        {
            this.currentFrame.MoveLeft();
            this.OnFrameSelected.Invoke(this.currentFrame);
        }

        /// <summary>
        /// Move blocks in frame up
        /// </summary>
        public void MoveUp()
        {
            this.currentFrame.MoveUp();
            this.OnFrameSelected.Invoke(this.currentFrame);
        }

        /// <summary>
        /// Move blocks in frame right.
        /// </summary>
        public void MoveRight()
        {
            this.currentFrame.MoveRight();
            this.OnFrameSelected.Invoke(this.currentFrame);
        }

        /// <summary>
        /// Move blocks in frame down.
        /// </summary>
        public void MoveDown()
        {
            this.currentFrame.MoveDown();
            this.OnFrameSelected.Invoke(this.currentFrame);
        }

        /// <summary>
        /// Sets up assets. If there are none, we'll create a new list we can add too.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        private void SetupAssets(string assetFile)
        {
            if (File.Exists(assetFile))
            {
                var fileContent = File.ReadAllText(assetFile);
                this.Assets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AssetModel>>(fileContent);
            }
            else
            {
                this.Assets = new List<AssetModel>();
            }

            this.OnAssetsLoaded?.Invoke(this.Assets);
        }

        /// <summary>
        /// Triggers the change event.
        /// </summary>
        private void TriggerOnCurrentAssetChanged()
        {
            this.OnCurrentAssetChanged?.Invoke(this.currentAsset);
        }

        /// <summary>
        /// Loads the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        private void SetByName(string assetName)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                return;
            }

            var asset = this.Assets.Single(a => a.Name == assetName);
            this.currentAsset = asset;
        }
    }
}
