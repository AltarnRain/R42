// <copyright file="PaletConstructor.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetManagerView
{
    using BlockEngine.Models;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Daws buttons on a panel to set the color.
    /// </summary>
    public class PaletConstructor
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
        /// Initializes a new instance of the <see cref="PaletConstructor" /> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <param name="shapeModel">The shape model.</param>
        public PaletConstructor(Panel panel, ShapeModel shapeModel)
        {
            this.panel = panel;
            this.shapeModel = shapeModel;

            this.DrawButtons();
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void DrawButtons()
        {
            foreach (var block in this.shapeModel.Blocks)
            {
                var button = new Button();
                button.Parent = this.panel;

                button.Width = ButtonSize;
                button.Height = button.Width;
                button.ForeColor = block.Color;
                button.BackColor = block.Color;

                button.Left = block.X * ButtonSize;
                button.Top = block.Y * ButtonSize;

                button.Click += this.OnClick;

                this.panel.Width = this.shapeModel.Blocks.Select(b => b.X + 1).Max() * ButtonSize;
                this.panel.Height = this.shapeModel.Blocks.Select(b => b.Y + 1).Max() * ButtonSize;

                button.Tag = block;
            }
        }

        public void OnClick(object sender, System.EventArgs e)
        {
            MessageBox.Show((sender as Button).BackColor.Name);
        }
    }
}
