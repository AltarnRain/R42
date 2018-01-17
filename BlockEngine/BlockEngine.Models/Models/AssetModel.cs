// <copyright file="AssetModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Models
{
    /// <summary>
    /// A model for game assets.
    /// </summary>
    public class AssetModel
    {
        /// <summary>
        /// Gets or sets the animation model.
        /// </summary>
        /// <value>
        /// The animation model.
        /// </value>
        public AnimationModel AnimationModel { get; set; }

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
        /// Creates the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="shapes">The shapes.</param>
        /// <param name="name">The name.</param>
        /// <param name="assetType">Type of the asset.</param>
        /// <returns>An asset model</returns>
        public static AssetModel Create(int width, int height, int shapes, string name, AssetTypes assetType)
        {
            var returnValue = new AssetModel();
            returnValue.AssetType = assetType;
            returnValue.Name = name;
            returnValue.AnimationModel = AnimationModel.Create(width, height, shapes);

            return returnValue;
        }
    }
}
