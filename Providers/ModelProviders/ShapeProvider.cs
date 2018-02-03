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
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>Empty Shape</returns>
        public ShapeModel Create(int width, int height)
        {
            var returnValue = new ShapeModel()
            {
                Blocks = new List<BlockModel>()
            };

            returnValue.Width = width;
            returnValue.Height = height;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var block = new BlockModel
                    {
                        Color = Color.Black,
                        X = x,
                        Y = y
                    };

                    returnValue.Blocks.Add(block);
                }
            }

            return returnValue;
        }
    }
}
