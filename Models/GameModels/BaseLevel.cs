// <copyright file="Level.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models.GameModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a level.
    /// </summary>
    public abstract class BaseLevel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLevel"/> class.
        /// </summary>
        public BaseLevel()
        {
        }

        /// <summary>
        /// Gets or sets the game objects.
        /// </summary>
        /// <value>
        /// The game objects.
        /// </value>
        private List<BaseGameObject> GameObjects { get; set; }
    }
}
