// <copyright file="AssetProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Providers
{
    using System.Collections.Generic;
    using Round42.Models;

    /// <summary>
    /// Provides an Asset.
    /// </summary>
    public class AssetProvider
    {
        /// <summary>
        /// The shape provider
        /// </summary>
        private readonly ShapeProvider shapeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetProvider"/> class.
        /// </summary>
        /// <param name="shapeProvider">The shape provider.</param>
        public AssetProvider(ShapeProvider shapeProvider)
        {
            this.shapeProvider = shapeProvider;
        }

        /// <summary>
        /// Creates an AssetModel.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="assetType">Type of the asset.</param>
        /// <param name="numberOfShapes">The number of shapes.</param>
        /// <param name="numberOfBlocksOnXAxis">The number of blocks on x axis.</param>
        /// <param name="numberOfBlocksOnYAxis">The number of blocks on y axis.</param>
        /// <returns>An AssetModel</returns>
        public AssetModel Create(string name, AssetTypes assetType, int numberOfShapes, int numberOfBlocksOnXAxis, int numberOfBlocksOnYAxis)
        {
            var returnValue = new AssetModel
            {
                AssetType = assetType,
                Name = name,
                XBlocks = numberOfBlocksOnXAxis,
                YBlocks = numberOfBlocksOnYAxis
            };

            returnValue.Shapes = new List<ShapeModel>();

            for (var i = 0; i < numberOfShapes; i++)
            {
                var shape = this.shapeProvider.Create(numberOfBlocksOnXAxis, numberOfBlocksOnYAxis);
                returnValue.Shapes.Add(shape);
            }

            return returnValue;
        }
    }
}
