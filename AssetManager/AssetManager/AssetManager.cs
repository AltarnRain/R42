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
        /// <param name="asset">The asset.</param>
        public delegate void NewAsset(AssetModel asset);

        /// <summary>
        /// Raised when the current asset changes
        /// /// </summary>
        /// <param name="asset">The asset.</param>
        public delegate void CurrentAssetChanged(AssetModel asset);

        /// <summary>
        /// Raised when the current asset changes
        /// /// </summary>
        /// <param name="asset">The asset.</param>
        public delegate void AssetLoaded(AssetModel asset);

        /// <summary>
        /// Raised when the asset collection changes
        /// </summary>
        /// <param name="assets">The assets.</param>
        public delegate void AssetsChanged(IEnumerable<AssetModel> assets);

        /// <summary>
        /// Occurs when [on new asset].
        /// </summary>
        public event NewAsset OnNewAsset;

        /// <summary>
        /// Occurs when Assets are changed
        /// </summary>
        public event AssetsChanged OnAssetsChanged;

        /// <summary>
        /// Occurs when [on loaded asset].
        /// </summary>
        public event AssetLoaded OnAssetLoaded;

        /// <summary>
        /// Occurs when [on loaded asset].
        /// </summary>
        public event CurrentAssetChanged OnCurrentAssetChanged;

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<AssetModel> Assets { get; set; }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void LoadAssets()
        {
            this.SetupAssets(this.assetFile);
        }

        /// <summary>
        /// Gets the frame.
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <returns>
        /// The asset model specified in the frame
        /// </returns>
        public ShapeModel GetFrame(int frame)
        {
            return this.currentAsset.Shapes[frame];
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
        /// Adds the specified new asset.
        /// </summary>
        /// <param name="newAsset">The new asset.</param>
        public void Add(AssetModel newAsset)
        {
            this.Assets.Add(newAsset);
            this.TriggerOnAssetsChanged();
            this.OnNewAsset?.Invoke(newAsset);
        }

        /// <summary>
        /// Removes the specified current asset.
        /// </summary>
        /// <param name="shapeIndex">Index of the shape.</param>
        public void RemoveShapeFromAsset(int shapeIndex)
        {
            this.currentAsset.Shapes.RemoveAt(shapeIndex);
            this.TriggerOnAssetsChanged();
        }

        /// <summary>
        /// Removes the shape from asset.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="shapeIndex">Index of the shape.</param>
        public void RemoveShapeFromAsset(string assetName, int shapeIndex)
        {
            this.LoadByName(assetName);
            this.RemoveShapeFromAsset(shapeIndex);
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
        /// Adds the shape to asset.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void AddShapeToAsset(string assetName)
        {
            this.LoadByName(assetName);
            this.AddShapeToAsset();
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        public void AddColumn()
        {
            foreach (var shape in this.currentAsset.Shapes)
            {
                shape.AddColumn();
            }

            this.currentAsset.Columns++;
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void AddColumn(string assetName)
        {
            this.LoadByName(assetName);
            this.AddColumn();
        }

        /// <summary>
        /// Adds the row.
        /// </summary>
        public void AddRow()
        {
            foreach (var shape in this.currentAsset.Shapes)
            {
                shape.AddRow();
            }

            this.currentAsset.Rows++;
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <returns><see cref="IEnumerable{AssetModel}"/></returns>
        public IEnumerable<AssetModel> GetAssets()
        {
            return this.Assets.AsEnumerable();
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
        /// Removes the last column.
        /// </summary>
        public void RemoveLastColumn()
        {
            if (this.currentAsset.Columns > 1)
            {
                this.currentAsset.Shapes.ForEach(s => s.RemoveLastColumn());
                this.currentAsset.Columns--;
            }

            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Removes the last column.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void RemoveLastColumn(string assetName)
        {
            this.LoadByName(assetName);
            this.RemoveLastColumn();
        }

        /// <summary>
        /// Removes the last row.
        /// </summary>
        public void RemoveLastRow()
        {
            if (this.currentAsset.Rows > 1)
            {
                this.currentAsset.Shapes.ForEach(s => s.RemoveLastRow());
                this.currentAsset.Rows--;
                this.TriggerOnCurrentAssetChanged();
            }
        }

        /// <summary>
        /// Removes the last row.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void RemoveLastRow(string assetName)
        {
            this.LoadByName(assetName);
            this.RemoveLastRow();
        }

        /// <summary>
        /// Loads the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void LoadByName(string assetName)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                return;
            }

            var asset = this.Assets.Single(a => a.Name == assetName);
            this.currentAsset = asset;
            this.OnAssetLoaded?.Invoke(asset);
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

            this.TriggerOnAssetsChanged();
        }

        /// <summary>
        /// Triggers the change event.
        /// </summary>
        private void TriggerOnAssetsChanged()
        {
            this.OnAssetsChanged?.Invoke(this.GetAssets());
        }

        /// <summary>
        /// Triggers the change event.
        /// </summary>
        private void TriggerOnCurrentAssetChanged()
        {
            this.OnCurrentAssetChanged?.Invoke(this.currentAsset);
        }
    }
}
