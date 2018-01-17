// <copyright file="AnimationModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Models
{
    using System;
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

        /// <summary>
        /// Creates the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="shapes">The shapes.</param>
        /// <returns>AnimationModel</returns>
        public static AnimationModel Create(int width, int height, int shapes)
        {
            var returnValue = new AnimationModel();

            returnValue.Shapes = new List<ShapeModel>();

            for (var i = 0; i < shapes; i++)
            {
                returnValue.Shapes.Add(ShapeModel.Create(width, height));
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the specified frame.
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <returns>A shape model</returns>
        public ShapeModel Get(int frame)
        {
            return this.Shapes[frame];
        }
    }
}
