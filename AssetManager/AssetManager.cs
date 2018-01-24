// <copyright file="AssetManager.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using BlockEngine.Models;
    using Newtonsoft.Json;

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
        private BindingList<AssetModel> assets = new BindingList<AssetModel>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager" /> class.
        /// </summary>
        /// <param name="assets">The assets.</param>
        public AssetManager(string assets)
        {
            this.assets = JsonConvert.DeserializeObject<BindingList<AssetModel>>(assets);
        }

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
