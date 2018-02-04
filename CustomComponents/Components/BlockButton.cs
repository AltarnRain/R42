// <copyright file="BlockButton2.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.CustomComponents
{
    using System;
    using System.ComponentModel;
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
        /// The block model
        /// </summary>
        private readonly BlockModel blockModel;

        /// <summary>
        /// The active color
        /// </summary>
        private Color activeColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockButton"/> class.
        /// </summary>
        public BlockButton()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockButton"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public BlockButton(IContainer container)
        {
            container.Add(this);
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockButton" /> class.
        /// </summary>
        /// <param name="blockModel">The block model.</param>
        /// <param name="activeColor">Color of the active.</param>
        /// <param name="buttonSize">Size of the button.</param>
        public BlockButton(BlockModel blockModel, Color activeColor, int buttonSize)
            : base()
        {
            this.InitializeComponent();
            this.blockModel = blockModel;
            this.activeColor = activeColor;

            this.Width = this.Height = buttonSize;
            this.ForeColor = blockModel.Color;
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
            var setColor = this.blockModel.Color;

            var border = rc.Height * 0.10f;

            var innerRectangle = new RectangleF((float)rc.Left + border, (float)rc.Top + border, (float)rc.Width - (border * 2), (float)rc.Height - (border * 2));

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
            this.blockModel.Color = this.activeColor;
            this.Invalidate();
        }
    }
}
