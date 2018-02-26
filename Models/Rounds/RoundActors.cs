// <copyright file="RoundActors.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

using Round42.Models.Enumerators;

namespace Round42.Models.Rounds
{
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
        public double ScreenX { get; set; }

        /// <summary>
        /// Gets or sets the s creen y.
        /// </summary>
        /// <value>
        /// The s creen y.
        /// </value>
        public double ScreenY { get; set; }

        /// <summary>
        /// Gets or sets the asset.
        /// </summary>
        /// <value>
        /// The asset.
        /// </value>
        public string AssetName { get; set; }

        /// <summary>
        /// Gets or sets the movement.
        /// </summary>
        /// <value>
        /// The movement.
        /// </value>
        public Movement Movement { get; set; }
    }
}