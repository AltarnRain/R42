// <copyright file="Drawer.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.CustomComponents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Round42.Models;
    using Round42.Models.Extentions;

    /// <summary>
    /// Daws buttons on a panel to set the color.
    /// </summary>
    public class Drawer
    {
        /// <summary>
        /// The panel
        /// </summary>
        private readonly Canvas canvas;

        /// <summary>
        /// The current shape
        /// </summary>
        private ShapeModel currentShape;

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawer" /> class.
        /// </summary>
        /// <param name="canvas">The panel.</param>
        /// <exception cref="System.ArgumentNullException">shapeModel</exception>
        public Drawer(Canvas canvas)
            : base()
        {
            this.canvas = canvas;
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
                return this.canvas.Children.Cast<BlockButton>();
            }
        }

        /// <summary>
        /// Passed down the active color to all the BlockButtons contained in the Drawer
        /// </summary>
        /// <param name="color">The color.</param>
        public void SetAciveColor(Brush color)
        {
            foreach (BlockButton b in this.canvas.Children)
            {
                b.ActiveColor = color;
            }
        }

        /// <summary>
        /// Sets the achor.
        /// </summary>
        public void SetAchor()
        {
            this.currentShape.ResetAnchor();
            foreach (BlockButton b in this.canvas.Children)
            {
                b.BecomeAnchorOnClick = true;
                //b.Text = "Click to set Anchor";
            }
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="buttonSize">Size of the button.</param>
        public void DrawButtons(ShapeModel shapeModel, int buttonSize)
        {
            this.currentShape = shapeModel;
            this.canvas.Children.Clear();

            foreach (var block in shapeModel.Blocks)
            {
                var blockButton = new BlockButton(block)
                {
                    Width = buttonSize,
                    Height = buttonSize,
                    OnBecomeAnchor = this.SetAnchor
                };

                Canvas.SetLeft(blockButton, (block.Column - 1) * buttonSize);
                Canvas.SetTop(blockButton, (block.Row - 1) * buttonSize);

            this.canvas.Children.Add(blockButton);
            }

        }

        /// <summary>
        /// Redraws the buttons.
        /// </summary>
        /// <param name="buttonSize">Size of the button.</param>
        public void RedrawButtons(int buttonSize)
        {
            if (this.currentShape != null)
            {
                this.DrawButtons(this.currentShape, buttonSize);
            }
        }

        /// <summary>
        /// Sets the anchor.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        private void SetAnchor(int column, int row)
        {
            foreach (BlockButton b in this.canvas.Children)
            {
                b.BecomeAnchorOnClick = false;
                //b.Text = string.Empty;
            }

            this.currentShape.SetAnchor(column, row);
        }
    }
}
