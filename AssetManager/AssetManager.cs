// <copyright file="AssetManager.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine
{
    using System.Collections.Generic;
    using BlockEngine.Models;

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
        /// Adds the asset.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        public void AddAsset(AssetModel assetModel)
        {
            this.assets.Add(assetModel);
        }
    }
}
