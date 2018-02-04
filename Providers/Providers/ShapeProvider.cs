// <copyright file="ShapeProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Providers
{
    using System.Collections.Generic;
    using System.Drawing;
    using Round42.Models;

    /// <summary>
    /// The ShapeProvider. A shape is a collection of blocks.
    /// </summary>
    public class ShapeProvider
    {
        /// <summary>
        /// News the specified height.
        /// </summary>
        /// <param name="xBlocks">The width.</param>
        /// <param name="yBlocks">The height.</param>
        /// <returns>
        /// Empty Shape
        /// </returns>
        public ShapeModel Create(int xBlocks, int yBlocks)
        {
            var returnValue = new ShapeModel()
            {
                Blocks = new List<BlockModel>()
            };

            returnValue.XBlocks = xBlocks;
            returnValue.Height = yBlocks;

            for (var y = 0; y < yBlocks; y++)
            {
                for (var x = 0; x < xBlocks; x++)
                {
                    var block = new BlockModel
                    {
                        Color = Color.Black,
                        X = x + 1,
                        Y = y + 1
                    };

                    returnValue.Blocks.Add(block);
                }
            }

            return returnValue;
        }
    }
}
