// <copyright file="RoundManagerFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Factories
{
    using Ninject;
    using Ninject.Parameters;
    using Round42.Managers;

    /// <summary>
    /// Created a RoundManager
    /// </summary>
    public class RoundManagerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoundManagerFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public RoundManagerFactory(IKernel kernel)
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
        /// Gets the <see cref="RoundManager"/>
        /// </summary>
        /// <param name="roundFile">The level file.</param>
        /// <returns><see cref="RoundManager"/></returns>
        public RoundManager Get(string roundFile)
        {
            return this.Kernel.Get<RoundManager>(new ConstructorArgument("roundFile", roundFile));
        }
    }
}
