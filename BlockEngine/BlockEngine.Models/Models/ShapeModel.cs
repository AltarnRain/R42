// <copyright file="ShapeModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Models
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    /// <summary>
    /// A basic shape.
    /// </summary>
    public class ShapeModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public List<BlockModel> Blocks { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; set; }

        /// <summary>
        /// News the specified height.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>Empty Shape</returns>
        public static ShapeModel Create(int width, int height)
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

        /// <summary>
        /// Gets the specified Block
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>A block model at the given x/y coordinates</returns>
        public BlockModel Get(int x, int y)
        {
            return this.Blocks.Single(b => b.X == x && b.Y == y);
        }
    }
}
