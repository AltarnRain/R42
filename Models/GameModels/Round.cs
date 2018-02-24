// <copyright file="Round.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models.Levels
{
    using Round42.Models.Drawing;
    using Round42.Models.Enumerators;

    /// <summary>
    /// Represents a level.
    /// </summary>
    public class Round
    {
        /// <summary>
        /// Gets or sets the type of the level.
        /// </summary>
        /// <value>
        /// The type of the level.
        /// </value>
        public LevelTypes LevelType { get; set; }

        /// <summary>
        /// Gets or sets the LevelAsset. This is the enemy that appears in the level.
        /// </summary>
        /// <value>
        /// The game objects.
        /// </value>
        public AssetModel LevelAsset { get; set; }

        /// <summary>
        /// Gets or sets the asset count. This is the number of enemies in the level.
        /// </summary>
        /// <value>
        /// The asset count.
        /// </value>
        public int AssetCount { get; set; }
    }
}
