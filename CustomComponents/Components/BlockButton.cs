// <copyright file="BlockButton.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.CustomComponents
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Round42.Models;

    /// <summary>
    /// Custum button control that handles updating the color of a block model
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    public class BlockButton : Panel
    {
        /// <summary>
        /// The active color
        /// </summary>
        private Color activeColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockButton"/> class.
        /// </summary>
        /// <param name="blockModel">The block model.</param>
        private BlockButton(BlockModel blockModel)
        {
            this.BlockModel = blockModel;
        }

        /// <summary>
        /// Gets the color of the active.
        /// </summary>
        /// <value>
        /// The color of the active.
        /// </value>
        public Color ActiveColor
        {
            get { return this.activeColor; }
        }

        /// <summary>
        /// Gets the block model.
        /// </summary>
        /// <value>
        /// The block model.
        /// </value>
        public BlockModel BlockModel { get; }

        /// <summary>
        /// Creates the specified block model.
        /// </summary>
        /// <param name="blockModel">The block model.</param>
        /// <param name="activeColor">Color of the active.</param>
        /// <param name="buttonSize">Size of the button.</param>
        /// <returns>
        /// An instance of a BlockButton
        /// </returns>
        public static BlockButton Create(BlockModel blockModel, Color activeColor, int buttonSize = 20)
        {
            var button = new BlockButton(blockModel);
            button.Width = button.Height = buttonSize;
            button.ForeColor = button.BackColor = blockModel.Color;

            return button;
        }

        /// <summary>
        /// Sets the color of the active.
        /// </summary>
        /// <param name="color">The color.</param>
        public void SetActiveColor(Color color)
        {
            this.activeColor = color;
        }

        /// <summary>
        /// Click event that updates the accociated block.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.BlockModel.Color = this.activeColor;
            this.ForeColor = this.BackColor = this.activeColor;
        }
    }
}
