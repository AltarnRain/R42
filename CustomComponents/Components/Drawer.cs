// <copyright file="Drawer.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.CustomComponents
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Round42.Models;

    /// <summary>
    /// Daws buttons on a panel to set the color.
    /// </summary>
    public class Drawer
    {
        /// <summary>
        /// The panel
        /// </summary>
        private readonly Panel panel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawer" /> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <exception cref="System.ArgumentNullException">shapeModel</exception>
        public Drawer(Panel panel)
            : base()
        {
            this.panel = panel;
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
                return this.panel.Controls.Cast<BlockButton>();
            }
        }

        /// <summary>
        /// Passed down the active color to all the BlockButtons contained in the Drawer
        /// </summary>
        /// <param name="color">The color.</param>
        public void SetAciveColor(Color color)
        {
            foreach (BlockButton b in this.panel.Controls)
            {
                b.SetActiveColor(color);
            }
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public void DrawButtons(ShapeModel shapeModel)
        {
            var numberOfButtonsOnXAxis = shapeModel.Blocks.Max(b => b.X);
            var buttonSize = this.panel.Width / (numberOfButtonsOnXAxis + 1);
            var buttonBorder = (int)Math.Floor(buttonSize * 0.15);
            this.panel.Controls.Clear();

            var bbList = new List<BlockButton>();
            foreach (var block in shapeModel.Blocks)
            {
                var blockModel = block;
                var blockButton = new BlockButton(block, Color.Black);

                // Reduce height & with by two pixels so we have borders around the buttons.
                blockButton.Height = blockButton.Width = buttonSize - buttonBorder;

                // leave one pixel of spave between blocks
                blockButton.Top = ((block.Y - 1) * buttonSize) + buttonBorder;
                blockButton.Left = ((block.X - 1) * buttonSize) + buttonBorder;

                bbList.Add(blockButton);
            }

            this.panel.Controls.AddRange(bbList.ToArray());
        }
    }
}
