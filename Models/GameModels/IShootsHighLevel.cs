// <copyright file="IShootsHighLevel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models.GameModels
{
    /// <summary>
    /// Flags a game actor that it shoots at high level.
    /// </summary>
    internal interface IShootsHighLevel
    {
        /// <summary>
        /// Fires this instance.
        /// </summary>
        void Fire();
    }
}