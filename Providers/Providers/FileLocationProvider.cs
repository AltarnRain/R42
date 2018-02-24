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
        /// Assets the file.
        /// </summary>
        /// <returns>Location of the asset file</returns>
        public string AssetFile()
        {
            return @"E:\Reps\R42\Data\Assets.json";
        }

        /// <summary>
        /// Levels the file.
        /// </summary>
        /// <returns>Location of the level file</returns>
        public string LevelFile()
        {
            return @"E:\Reps\R42\Data\Levels.json";
        }
    }
}
