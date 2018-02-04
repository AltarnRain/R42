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
        public delegate void AssedLoaded(AssetModel asset);

        /// <summary>
        /// Raised when the asset collection changes
        /// </summary>
        /// <param name="assets">The assets.</param>
        public delegate void AssetsChanged(IEnumerable<AssetModel> assets);

        /// <summary>
        /// Occurs when [on new asset].
        /// </summary>
        public event AssedLoaded OnNewAsset;

        /// <summary>
        /// Occurs when Assets are changed
        /// </summary>
        public event AssetsChanged OnAssetsChanged;

        /// <summary>
        /// Occurs when [on loaded asset].
        /// </summary>
        public event AssedLoaded OnAssetLoaded;

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
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="frame">The frame.</param>
        /// <returns>
        /// The asset model specified in the frame
        /// </returns>
        public ShapeModel GetFrameFromAsset(string assetName, int frame)
        {
            return this.Assets.Single(a => a.Name == assetName).Shapes[frame];
        }

        /// <summary>
        /// Adds the specified width.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="assetType">Type of the asset.</param>
        /// <param name="numberOfShapes">The number of shapes.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <exception cref="DuplicateEntryException">Asset {0} already exists".FormatString(assetName)</exception>
        public void Add(string assetName, AssetTypes assetType, int numberOfShapes, int width, int height)
        {
            if (this.Assets.Any(a => a.Name == assetName))
            {
                throw new DuplicateEntryException("Asset {0} already exists".FormatString(assetName));
            }

            var newAsset = this.assetProvider.Create(assetName, assetType, numberOfShapes, width, height);
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
            this.TriggerChangeEvent();
            this.OnNewAsset?.Invoke(newAsset);
        }

        /// <summary>
        /// Adds the shape.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        public void AddShapeToAsset(AssetModel assetModel)
        {
            var newShape = this.shapeProvider.Create(assetModel.XBlocks, assetModel.YBlocks);
            assetModel.Shapes.Add(newShape);
            this.TriggerChangeEvent();
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
        /// Finds the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <returns>An asset model</returns>
        public AssetModel FindByName(string assetName)
        {
            return this.Assets.SingleOrDefault(a => a.Name == assetName);
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

            this.TriggerChangeEvent();
        }

        /// <summary>
        /// Triggers the change event.
        /// </summary>
        private void TriggerChangeEvent()
        {
            this.OnAssetsChanged?.Invoke(this.GetAssets());
        }
    }
}
