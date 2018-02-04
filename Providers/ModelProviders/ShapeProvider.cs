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
        /// <param name="XBlocks">The width.</param>
        /// <param name="YBlocks">The height.</param>
        /// <returns>Empty Shape</returns>
        public ShapeModel Create(int XBlocks, int YBlocks)
        {
            var returnValue = new ShapeModel()
            {
                Blocks = new List<BlockModel>()
            };

            returnValue.XBlocks = XBlocks;
            returnValue.Height = YBlocks;

            for (var y = 0; y < YBlocks; y++)
            {
                for (var x = 0; x < XBlocks; x++)
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
