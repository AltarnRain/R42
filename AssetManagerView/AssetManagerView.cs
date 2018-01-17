// <copyright file="AssetManagerView.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine
{
    using System.Windows.Forms;
    using Ninject;

    /// <summary>
    /// AssetManager vew
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AssetManagerView : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManagerView" /> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public AssetManagerView(IKernel kernel)
        {
            this.InitializeComponent();
            this.Kernel = kernel;
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel { get; }
    }
}
