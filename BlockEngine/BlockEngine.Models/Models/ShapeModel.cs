// <copyright file="ShapeModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Models
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A basic shape.
    /// </summary>
    public class ShapeModel
    {
        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public List<BlockModel> Blocks { get; set; }
    }
}
