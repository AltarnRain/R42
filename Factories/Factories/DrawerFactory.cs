﻿// <copyright file="DrawerFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Factories.Factories
{
    using Ninject;
    using Ninject.Parameters;
    using Round42.CustomComponents;
    using System.Windows.Controls;

    /// <summary>
    /// Creates a drawer.
    /// </summary>
    public class DrawerFactory
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawerFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public DrawerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Gets the specified panel.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <returns>A drawer.</returns>
        public Drawer Get(Canvas panel)
        {
            return this.kernel.Get<Drawer>(new ConstructorArgument("panel", panel));
        }
    }
}
