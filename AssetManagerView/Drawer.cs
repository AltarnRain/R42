// <copyright file="PaletConstructor.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetManagerView
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using BlockEngine.Models;

    /// <summary>
    /// Daws buttons on a panel to set the color.
    /// </summary>
    public class Drawer
    {
        private const int ButtonSize = 20;

        /// <summary>
        /// The panel
        /// </summary>
        private readonly Panel panel;

        /// <summary>
        /// The shape model
        /// </summary>
        private readonly ShapeModel shapeModel;

        /// <summary>
        /// The active color
        /// </summary>
        private string activeColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawer" /> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <param name="shapeModel">The shape model.</param>
        public Drawer(Panel panel, ShapeModel shapeModel)
        {
            this.panel = panel;
            this.shapeModel = shapeModel;

            this.activeColor = Color.Black.Name;

            this.DrawButtons();
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        public void DrawButtons()
        {
            foreach (var block in this.shapeModel.Blocks)
            {
                var panel = new Panel();
                panel.Parent = this.panel;

                panel.Width = ButtonSize -1;
                panel.Height = panel.Width -1;
                panel.ForeColor = block.Color;
                panel.BackColor = block.Color;

                panel.Left = block.X * ButtonSize;
                panel.Top = block.Y * ButtonSize;

                panel.Click += this.OnClick;

                this.panel.Width = this.shapeModel.Blocks.Select(b => b.X + 1).Max() * ButtonSize;
                this.panel.Height = this.shapeModel.Blocks.Select(b => b.Y + 1).Max() * ButtonSize;

                panel.Tag = block;
            }
        }

        /// <summary>
        /// Called when [click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void OnClick(object sender, System.EventArgs e)
        {
            var button = sender as Panel;
            button.ForeColor = Color.FromName(this.activeColor);
            button.BackColor = Color.FromName(this.activeColor);
            var block = button.Tag as BlockModel;
            block.SetColor(this.activeColor);
        }

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="colorName">Name of the color.</param>
        public void SetColor(string colorName)
        {
            this.activeColor = colorName;
        }

    }
}
