// <copyright file="IMoves.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models.GameModels
{
    /// <summary>
    /// Flags a game object that it can move.
    /// </summary>
    public interface IMoves
    {
        /// <summary>
        /// Moveses this instance.
        /// </summary>
        void Move();
    }
}