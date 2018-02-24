// <copyright file="Bird.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models.GameModels.Enemies
{
    /// <summary>
    /// Bird enemy
    /// </summary>
    /// <seealso cref="BaseGameObject" />
    /// <seealso cref="IShootsHighLevel" />
    /// <seealso cref="IMoves" />
    public class Bird : BaseGameObject, IShootsHighLevel, IMoves
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bird"/> class.
        /// </summary>
        /// <param name="asset">The asset.</param>
        public Bird(AssetModel asset)
            : base(asset)
        {
        }

        /// <summary>
        /// Actor fires.
        /// </summary>
        public void Fire()
        {
            // do nothing
        }

        /// <summary>
        /// Moveses this instance.
        /// </summary>
        public void Move()
        {
            // todo
        }
    }
}
