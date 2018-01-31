// <copyright file="AssetManager.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Exceptions;
    using Extentions;
    using Round42.Models;

    /// <summary>
    /// Manages assets
    /// </summary>
    public class AssetManager
    {
        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        private GameAssets gameAssets = new GameAssets();

        /// <summary>
        /// The asset file
        /// </summary>
        private string assetFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager"/> class.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        public AssetManager(string assetFile)
        {
            this.assetFile = assetFile;
            this.SetupAssets(assetFile);
        }

        /// <summary>
        /// Raised when the asset collection changes
        /// </summary>
        /// <param name="asset">The asset.</param>
        public delegate void NewAsset(AssetModel asset);

        /// <summary>
        /// Raised when the asset collection changes
        /// </summary>
        /// <param name="assets">The assets.</param>
        public delegate void AssetsChanged(List<AssetModel> assets);

        /// <summary>
        /// Occurs when [on new asset].
        /// </summary>
        public event NewAsset OnNewAsset;

        /// <summary>
        /// Occurs when Assets are changed
        /// </summary>
        public event AssetsChanged OnAssetsChanged;

        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public IEnumerable<AssetModel> Assets
        {
            get
            {
                return this.gameAssets.Assets.AsEnumerable();
            }
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        /// <returns>
        /// An AssetManager
        /// </returns>
        public static AssetManager Create(string assetFile)
        {
            return new AssetManager(assetFile);
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
            if (this.gameAssets.Assets.Any(a => a.Name == assetName))
            {
                throw new DuplicateEntryException("Asset {0} already exists".FormatString(assetName));
            }

            var newAsset = AssetModel.Create(width, height, numberOfShapes, assetName, assetType);
            this.gameAssets.Assets.Add(newAsset);
            this.OnAssetsChanged?.Invoke(this.gameAssets.Assets);
            this.OnNewAsset?.Invoke(newAsset);
        }

        /// <summary>
        /// Finds the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <returns>An asset model</returns>
        public AssetModel FindByName(string assetName)
        {
            return this.gameAssets.Assets.SingleOrDefault(a => a.Name == assetName);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            var xml = this.gameAssets.Serialize<GameAssets>();
            xml.SaveToFile(this.assetFile);
        }

        /// <summary>
        /// Sets up assets. If there are none, we'll create a new list we can add too.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        private void SetupAssets(string assetFile)
        {
            if (File.Exists(assetFile))
            {
                this.gameAssets = assetFile.DeserializeFile<GameAssets>();
            }
            else
            {
                this.gameAssets = new GameAssets();
            }
        }
    }
}
