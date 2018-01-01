// <copyright file="IModelProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.DataHandling.Interfaces
{
    /// <summary>
    /// Provides a contract for all model providers
    /// </summary>
    public interface IModelProvider
    {
        /// <summary>
        /// Gets a model of type T based on the XML string
        /// </summary>
        /// <typeparam name="T">A model type</typeparam>
        /// <param name="xmlString">The XML string.</param>
        /// <returns>
        /// An instance of T
        /// </returns>
        T GetModel<T>(string xmlString);
    }
}
