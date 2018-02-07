// <copyright file="TestApp.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.TestAppPaletAndDrawer
{
    using System.Drawing;
    using System.Windows.Forms;
    using Ninject;
    using Providers;
    using Round42.CustomComponents;
    using Round42.Factories.Factories;
    using Round42.Models;
    using Round42.TestAppPaletAndDrawer.Properties;

    /// <summary>
    /// AssetManager vew
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class TestApp : Form
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// The drawer
        /// </summary>
        private readonly Drawer drawer;

        /// <summary>
        /// The color provider
        /// </summary>
        private readonly ColorProvider colorProvider;
        private readonly PaletFactory paletFactory;
        private readonly DrawerFactory drawerFactory;

        /// <summary>
        /// The color provider
        /// </summary>
        private ShapeModel shapeModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestApp" /> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="colorProvider">The color provider.</param>
        /// <param name="paletFactory">The palet factory.</param>
        /// <param name="drawerFactory">The drawer factory.</param>
        public TestApp(IKernel kernel, ColorProvider colorProvider, PaletFactory paletFactory, DrawerFactory drawerFactory)
        {
            this.InitializeComponent();

            this.kernel = kernel;
            this.colorProvider = colorProvider;
            this.paletFactory = paletFactory;
            this.drawerFactory = drawerFactory;
            var palet = this.paletFactory.Get(this.PaletPanel);

            this.shapeModel = this.kernel.Get<ShapeProvider>().Create(25, 15);

            this.drawer = this.drawerFactory.Get(this.DrawerPanel);
            palet.OnColorSelected += this.drawer.SetAciveColor;

            this.Width = Settings.Default.Width;
            this.Height = Settings.Default.Height;
            this.kernel = kernel;
        }

        /// <summary>
        /// Handles the FormClosed event of the TestApp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void TestApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Height = this.Height;
            Settings.Default.Width = this.Width;
            Settings.Default.Save();
        }

        /// <summary>
        /// Handles the SizeChanged event of the DrawerPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DrawerPanel_SizeChanged(object sender, System.EventArgs e)
        {
            this.drawer.DrawButtons(this.shapeModel, 50);
        }
    }
}
