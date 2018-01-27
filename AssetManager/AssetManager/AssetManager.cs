// <copyright file="AssetManager.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42
{
    using System;
    using System.Collections.Generic;
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
        private List<AssetModel> assets = new List<AssetModel>();

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
        /// Occurs when [on new asset].
        /// </summary>
        public event AssetsChanged OnAssetsChanged;

        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<AssetModel> Assets
        {
            get
            {
                return this.assets;
            }
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>An AssetManager</returns>
        public static AssetManager Create()
        {
            return new AssetManager();
        }

        /// <summary>
        /// Adds the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="numberOfShapes">The number of shapes.</param>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="assetType">Type of the asset.</param>
        public void Add(int width, int height, int numberOfShapes, string assetName, AssetTypes assetType)
        {
            if (this.assets.Any(a => a.Name == assetName))
            {
                throw new DuplicateEntryException("Asset {0} already exists".FormatString(assetName));
            }

            var newAsset = AssetModel.Create(width, height, 1, assetName, assetType);
            this.assets.Add(newAsset);
            this.OnNewAsset?.Invoke(newAsset);
            this.OnAssetsChanged?.Invoke(this.assets);
        }

        /// <summary>
        /// Finds the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <returns>An asset model</returns>
        public AssetModel FindByName(string assetName)
        {
            return this.assets.SingleOrDefault(a => a.Name == assetName);
        }
    }
}
