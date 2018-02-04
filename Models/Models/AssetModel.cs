// <copyright file="AssetModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for game assets.
    /// </summary>
    public class AssetModel
    {
        /// <summary>
        /// Gets or sets the animation.
        /// </summary>
        /// <value>
        /// The animation.
        /// </value>
        public List<ShapeModel> Shapes { get; set; }

        /// <summary>
        /// Gets or sets the type of the asset.
        /// </summary>
        /// <value>
        /// The type of the asset.
        /// </value>
        public AssetTypes AssetType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the x blocks.
        /// </summary>
        /// <value>
        /// The x blocks.
        /// </value>
        public int XBlocks { get; set; }

        /// <summary>
        /// Gets or sets the y blocks.
        /// </summary>
        /// <value>
        /// The y blocks.
        /// </value>
        public int YBlocks { get; set; }
    }
}
