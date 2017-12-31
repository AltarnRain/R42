// <copyright file="Shape.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Drawing
{
    using System.Collections.Generic;

    /// <summary>
    /// A basic shape.
    /// </summary>
    internal class Shape
    {
        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        private readonly Dictionary<Location, Block> blocks;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>        
        public Shape()
        {
            
        }
    }
}
