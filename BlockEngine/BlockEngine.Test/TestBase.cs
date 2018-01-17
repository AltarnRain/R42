// <copyright file="TestBase.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Test
{
    using Ninject;

    /// <summary>
    /// Base class for all test classes
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        public TestBase() => this.Kernel = new StandardKernel();

        /// <summary>
        /// Gets or sets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel { get; set; }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T">A type</typeparam>
        /// <returns>Instance of T</returns>
        public T Get<T>()
        {
            return this.Kernel.Get<T>();
        }
    }
}