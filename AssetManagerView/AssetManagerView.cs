// <copyright file="AssetManagerView.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetManagerView
{
    using System.Windows.Forms;
    using BlockEngine;
    using BlockEngine.Models;
    using Ninject;

    /// <summary>
    /// AssetManager vew
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AssetManagerView : Form
    {
        /// <summary>
        /// The active color
        /// </summary>
        private string activeColor;

        /// <summary>
        /// The drawer
        /// </summary>
        private Drawer drawer;

        /// <summary>
        /// The asset manager
        /// </summary>
        private readonly AssetManager assetManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManagerView" /> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public AssetManagerView(IKernel kernel)
        {
            this.InitializeComponent();
            this.Kernel = kernel;
            this.assetManager = this.Kernel.Get<AssetManager>();
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel { get; }

        private void ButtonClick(object sender, System.EventArgs e)
        {
            var shapeModel = ShapeModel.Create(5, 6);
            this.drawer = new Drawer(this.palet, shapeModel);

            this.drawer.DrawButtons();

            var bc = new ColorButtonConstructor(this.panelColor);
            bc.DrawButtons();
            bc.OnColorSelected += this.SetActiveColor;
        }

        private void SetActiveColor(string colorName)
        {
            this.drawer.SetColor(colorName);
        }

        private void addToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
     
        }
    }
}
