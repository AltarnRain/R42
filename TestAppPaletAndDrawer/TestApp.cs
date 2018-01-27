// <copyright file="TestApp.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.TestAppPaletAndDrawer
{
    using System.Drawing;
    using System.Windows.Forms;
    using Round42.CustomComponents;
    using Round42.Models;
    using Round42.TestAppPaletAndDrawer.Properties;

    /// <summary>
    /// AssetManager vew
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class TestApp : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestApp" /> class.
        /// </summary>
        public TestApp()
        {
            this.InitializeComponent();

            var palet = Palet.Create(new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Cyan, Color.Purple, Color.Green });
            this.PaletPanel.Controls.Add(palet);

            var shapeModel = ShapeModel.Create(30, 20);

            var drawer = Drawer.Create(shapeModel);
            this.DrawerPanel.Controls.Add(drawer);
            palet.OnColorSelected += drawer.SetAciveColor;

            this.Width = Settings.Default.Width;
            this.Height = Settings.Default.Height;
        }

        private void TestApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Height = this.Height;
            Settings.Default.Width = this.Width;
            Settings.Default.Save();
        }
    }
}
