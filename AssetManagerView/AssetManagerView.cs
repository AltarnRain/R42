// <copyright file="AssetManagerView.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetManagerView
{
    using System.Drawing;
    using System.Windows.Forms;
    using Round42.CustomComponents;
    using Round42.Models;

    /// <summary>
    /// AssetManager vew
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AssetManagerView : Form
    {
        /// <summary>
        /// The palet
        /// </summary>
        private Palet palet;

        private Drawer drawer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManagerView" /> class.
        /// </summary>
        public AssetManagerView()
        {
            this.InitializeComponent();

            this.palet = Palet.Create(new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Cyan });
            this.PaletPanel.Controls.Add(this.palet);
        }

        private void NewMenuItem_Click(object sender, System.EventArgs e)
        {
            var shapeModel = ShapeModel.Create(5, 6);

            this.drawer = Drawer.Create(shapeModel);
            this.DrawerPanel.Controls.Add(this.drawer);
            this.palet.OnColorSelected += this.drawer.SetAciveColor;
        }
    }
}
