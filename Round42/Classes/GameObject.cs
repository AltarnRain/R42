// <copyright file="GameObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Round42.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Basic game object
    /// </summary>
    internal abstract class GameObject
    {
        /// <summary>
        /// Gets or sets the screen y position.
        /// </summary>
        /// <value>
        /// The screen y position.
        /// </value>
        public long ScreenYPos { get; set; }

        /// <summary>
        /// Gets or sets the s creen x position.
        /// </summary>
        /// <value>
        /// The s creen x position.
        /// </value>
        public long SCreenXPos { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GameObject"/> is invulnerable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if invulnerable; otherwise, <c>false</c>.
        /// </value>
        public bool Invulnerable { get; set; }
    }
}
