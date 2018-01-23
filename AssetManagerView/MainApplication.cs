﻿// <copyright file="MainApplication.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetManagerView
{
    using Ninject;

    /// <summary>
    /// Main application class
    /// </summary>
    public class MainApplication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainApplication" /> class.
        /// </summary>
        public MainApplication()
        {
            this.Kernel = new StandardKernel();
            var view = this.Kernel.Get<AssetManagerView>();
            view.ShowDialog();
        }

        /// <summary>
        /// Gets or sets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel { get; set; }
    }
}
