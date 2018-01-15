// <copyright file="AnimationModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// An Animaltion. Wrapper for a list of shapes.
    /// </summary>
    public class AnimationModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the shapes.
        /// </summary>
        /// <value>
        /// The shapes.
        /// </value>
        public List<ShapeModel> Shapes { get; set; }
    }
}
