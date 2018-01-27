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
        /// The block size
        /// </summary>
        private readonly int buttonSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawer" /> class.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="buttonSize">Size of the button.</param>
        /// <exception cref="System.ArgumentNullException">shapeModel</exception>
        private Drawer(ShapeModel shapeModel, int buttonSize = 20)
        {
            this.shapeModel = shapeModel ?? throw new System.ArgumentNullException(nameof(shapeModel));
            this.buttonSize = buttonSize;

            this.DrawButtons();
            this.Dock = DockStyle.Fill;
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
        /// <param name="buttonSize">Size of the button.</param>
        /// <returns>
        /// An instance of Drawer
        /// </returns>
        public static Drawer Create(ShapeModel shapeModel, int buttonSize = 20)
        {
            return new Drawer(shapeModel, buttonSize);
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

                // Recude height & with by two pixels so we have borders around the buttons.
                blockButton.Height = blockButton.Width = this.buttonSize - 2;

                // leave one pixel of spave between blocks
                blockButton.Left = (block.X * this.buttonSize) + 1;
                blockButton.Top = (block.Y * this.buttonSize) + 1;
            }
        }
    }
}
