// <copyright file="AssetManagerFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Factories
{
    using Ninject;
    using Ninject.Parameters;
    using Round42.Managers;

    /// <summary>
    /// Created an asset manager.
    /// </summary>
    public class AssetManagerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManagerFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public AssetManagerFactory(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel { get; }

        /// <summary>
        /// Gets the specified asset file.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        /// <returns>An asset manager</returns>
        public AssetManager Get(string assetFile)
        {
            return this.Kernel.Get<AssetManager>(new ConstructorArgument("assetFile", assetFile));
        }
    }
}
