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
    /// The block button,
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public partial class BlockButton : Control
    {
        /// <summary>
        /// The active color
        /// </summary>
        private Color activeColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockButton" /> class.
        /// </summary>
        /// <param name="blockModel">The block model.</param>
        /// <param name="activeColor">Color of the active.</param>
        public BlockButton(BlockModel blockModel, Color activeColor)
            : base()
        {
            this.BlockModel = blockModel;
            this.activeColor = activeColor;
        }

        /// <summary>
        /// Gets the block model
        /// </summary>
        /// <value>
        /// The block model.
        /// </value>
        public BlockModel BlockModel { get; private set; }

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
        /// Gets or sets the text associated with this control.
        /// </summary>
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (value != this.Text)
                {
                    base.Text = value;
                    this.Invalidate();
                }
            }
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
        /// Raises the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var gfx = e.Graphics;
            var rc = this.ClientRectangle;
            var setColor = this.BlockModel.Color;

            var tonAndBottomBorder = rc.Height * 0.10f;
            var leftAndRightBorder = rc.Width * 0.10f;

            var innerRectangle = new RectangleF(
                rc.Left + leftAndRightBorder,
                rc.Top + tonAndBottomBorder,
                rc.Width - (leftAndRightBorder * 2),
                rc.Height - (tonAndBottomBorder * 2));

            if (setColor == Color.Black)
            {
                gfx.FillRectangle(new SolidBrush(this.Parent.BackColor), rc);
                gfx.FillRectangle(new SolidBrush(setColor), innerRectangle);
            }
            else
            {
                gfx.FillRectangle(new SolidBrush(setColor), rc);
            }
        }

        /// <summary>
        /// Click event that updates the accociated block.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.BlockModel.Color = this.activeColor;
            this.Invalidate();
        }
    }
}
