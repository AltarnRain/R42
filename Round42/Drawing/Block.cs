// <copyright file="Block.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Drawing
{
    using System.Drawing;

    /// <summary>
    /// Defines the basic block of a shape.
    /// </summary>
    internal class Block
    {
        /// <summary>
        /// The width
        /// </summary>
        private const int Width = 30;

        /// <summary>
        /// The height
        /// </summary>
        private const int Height = 30;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        private Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="Block" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public Block(Color color)
        {
            this.color = color;
        }
    }
}