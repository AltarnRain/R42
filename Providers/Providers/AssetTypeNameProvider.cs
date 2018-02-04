// <copyright file="AssetTypeNameProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Providers
{
    using System;
    using System.Collections.Generic;
    using Round42.Models;

    /// <summary>
    /// Provides the names of the AssetType enum
    /// </summary>
    public class AssetTypeNameProvider
    {
        /// <summary>
        /// Gets the asset type list.
        /// </summary>
        /// <returns>List of AssetType Names</returns>
        public List<string> GetNames()
        {
            var returnValue = new List<string>();

            foreach (var name in Enum.GetNames(typeof(AssetTypes)))
            {
                returnValue.Add(name);
            }

            return returnValue;
        }
    }
}
