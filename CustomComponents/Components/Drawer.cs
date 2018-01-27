// <copyright file="Drawer.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetManagerView
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using BlockEngine.Models;
    using CustomComponents.Components;

    /// <summary>
    /// Daws buttons on a panel to set the color.
    /// </summary>
    public class Drawer : Panel
    {
        /// <summary>
        /// The shape model
        /// </summary>
        private readonly ShapeModel shapeModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawer" /> class.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        private Drawer(ShapeModel shapeModel)
        {
            this.shapeModel = shapeModel ?? throw new System.ArgumentNullException(nameof(shapeModel));

            this.DrawButtons();
        }

        /// <summary>
        /// Gets the block buttons.
        /// </summary>
        /// <value>
        /// The block buttons.
        /// </value>
        public IEnumerable<BlockButton> BlockButtons
        {
            get
            {
                return this.Controls.Cast<BlockButton>();
            }
        }

        /// <summary>
        /// Creates the specified shape model.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>An instance of Drawer</returns>
        public static Drawer Create(ShapeModel shapeModel)
        {
            return new Drawer(shapeModel);
        }

        /// <summary>
        /// Passed down the active color to all the BlockButtons contained in the Drawer
        /// </summary>
        /// <param name="color">The color.</param>
        public void SetAciveColor(Color color)
        {
            foreach (BlockButton b in this.Controls)
            {
                b.SetActiveColor(color);
            }
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        private void DrawButtons()
        {
            foreach (var block in this.shapeModel.Blocks)
            {
                var blockButton = BlockButton.Create(block, Color.Black);
                this.Controls.Add(blockButton);

                blockButton.Left = block.X * blockButton.Width;
                blockButton.Top = block.Y * blockButton.Height;
            }

            var maxHeight = this.BlockButtons.Max(bb => bb.Width);
            var maxWidth = this.BlockButtons.Max(bb => bb.Height);

            this.Width = this.shapeModel.Blocks.Select(b => b.X + 1).Max() * maxWidth;
            this.Height = this.shapeModel.Blocks.Select(b => b.Y + 1).Max() * maxWidth;
        }
    }
}
