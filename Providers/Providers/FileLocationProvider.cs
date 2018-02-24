// <copyright file="FileLocationProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Providers
{
    /// <summary>
    /// Providers the location of core game files.
    /// </summary>
    public class FileLocationProvider
    {
        /// <summary>
        /// Gets the asset file.
        /// </summary>
        /// <value>
        /// The asset file.
        /// </value>
        public string AssetFile
        {
            get
            {
                return @"E:\Reps\R42\Data\Assets.json";
            }
        }

        /// <summary>
        /// Gets the level file.
        /// </summary>
        /// <value>
        /// The level file.
        /// </value>
        public string RoundFile
        {
            get
            {
                return @"E:\Reps\R42\Data\Rounds.json";
            }
        }
    }
}
