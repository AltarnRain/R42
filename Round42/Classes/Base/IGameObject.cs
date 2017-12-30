// <copyright file="IGameObject.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Interfaces
{
    /// <summary>
    /// Basic game object
    /// </summary>
    internal interface IGameObject
    {
        /// <summary>
        /// Gets or sets the screen y position.
        /// </summary>
        /// <value>
        /// The screen y position.
        /// </value>
        int ScreenYPos { get; set; }

        /// <summary>
        /// Gets or sets the s creen x position.
        /// </summary>
        /// <value>
        /// The s creen x position.
        /// </value>
        int ScreenXPos { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGameObject"/> is invulnerable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if invulnerable; otherwise, <c>false</c>.
        /// </value>
        bool Invulnerable { get; set; }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        void Draw();
    }
}
