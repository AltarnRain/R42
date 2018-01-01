// <copyright file="Shape.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// A basic shape.
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public List<Block> Blocks { get; set; }
    }
}
