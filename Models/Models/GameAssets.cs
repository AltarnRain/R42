// <copyright file="GameAssets.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42
{
    using System.Collections.Generic;
    using Round42.Models;

    /// <summary>
    /// Container class for assets
    /// </summary>
    public class GameAssets
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameAssets"/> class.
        /// </summary>
        public GameAssets()
        {
            this.Assets = new List<AssetModel>();
        }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<AssetModel> Assets { get; set; }
    }
}
