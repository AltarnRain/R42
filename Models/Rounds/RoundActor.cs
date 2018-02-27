// <copyright file="RoundActor.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models.Rounds
{
    using System.Collections.Generic;
    using Round42.Models.Drawing;
    using Round42.Models.Enumerators;

    /// <summary>
    /// An actor in a level.
    /// </summary>
    public class RoundActor
    {
        /// <summary>
        /// Gets or sets the screen x.
        /// </summary>
        /// <value>
        /// The screen x.
        /// </value>
        public double ScreenPositionX { get; set; }

        /// <summary>
        /// Gets or sets the s creen y.
        /// </summary>
        /// <value>
        /// The s creen y.
        /// </value>
        public double ScreenPositionY { get; set; }

        /// <summary>
        /// Gets or sets the asset.
        /// </summary>
        /// <value>
        /// The asset.
        /// </value>
        public string AssetName { get; set; }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>
        /// The shapes.
        /// </value>
        public ShapeModel Shape { get; set; }

        /// <summary>
        /// Gets or sets the movement x.
        /// </summary>
        /// <value>
        /// The movement x.
        /// </value>
        public List<Movement> Movements { get; set; }
    }
}