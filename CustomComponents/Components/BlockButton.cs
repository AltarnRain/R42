// <copyright file="BlockButton.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.CustomComponents
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Extentions;
    using Round42.Models;

    /// <summary>
    /// The block button,
    /// </summary>
    public partial class BlockButton : Button
    {
        /// <summary>
        /// Gets the block model
        /// </summary>
        /// <value>
        /// The block model.
        /// </value>
        private BlockModel blockModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockButton" /> class.
        /// </summary>
        /// <param name="blockModel">The block model.</param>
        public BlockButton(BlockModel blockModel)
            : base()
        {
            this.blockModel = blockModel;
            this.ActiveColor = Brushes.Black;
        }

        ///// <summary>
        ///// Gets or sets the text associated with this control.
        ///// </summary>
        //public new string Text
        //{
        //    get
        //    {
        //        return base.Text;
        //    }

        //    set
        //    {
        //        if (value != base.Text)
        //        {
        //            base.Text = value;
        //            this.Invalidate();
        //        }
        //    }
        //}

        /// <summary>
        /// Gets or sets the color of the active.
        /// </summary>
        /// <value>
        /// The color of the active.
        /// </value>
        public Brush ActiveColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [become anchor on click].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [become anchor on click]; otherwise, <c>false</c>.
        /// </value>
        public bool BecomeAnchorOnClick { get; set; }

        /// <summary>
        /// Gets or sets the on become anchor action
        /// </summary>
        /// <value>
        /// The on become anchor.
        /// </value>
        public Action<int, int> OnBecomeAnchor { get; set; }

        /// <summary>
        /// Raises the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        //protected override void OnPaint()
        //{
        //    base.OnPaint();

        //    var gfx = e.Graphics;
        //    var rc = this.ClientRectangle;
        //    var setColor = this.blockModel.Color;

        //    var tonAndBottomBorder = rc.Height * 0.10f;
        //    var leftAndRightBorder = rc.Width * 0.10f;

        //    var innerRectangle = new RectangleF(
        //        rc.Left + leftAndRightBorder,
        //        rc.Top + tonAndBottomBorder,
        //        rc.Width - (leftAndRightBorder * 2),
        //        rc.Height - (tonAndBottomBorder * 2));

        //    if (setColor == Color.Black)
        //    {
        //        gfx.FillRectangle(new SolidBrush(this.Parent.BackColor), rc);
        //        gfx.FillRectangle(new SolidBrush(setColor), innerRectangle);
        //    }
        //    else
        //    {
        //        gfx.FillRectangle(new SolidBrush(setColor), rc);
        //    }

        //    if (this.blockModel.Anchor)
        //    {
        //        this.Text = "Anchor";
        //    }

        //    var sf = new StringFormat
        //    {
        //        Alignment = StringAlignment.Center,
        //        LineAlignment = StringAlignment.Center
        //    };

        //    gfx.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), new RectangleF((float)rc.Left, (float)rc.Top, (float)rc.Height, (float)rc.Width), sf);
        //}

        /// <summary>
        /// Click event that updates the accociated block.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick()
        {
            base.OnClick();

            if (this.BecomeAnchorOnClick)
            {
                this.blockModel.Anchor = this.BecomeAnchorOnClick;
                this.OnBecomeAnchor?.Invoke(this.blockModel.Column, this.blockModel.Row);
            }
            else
            {
                this.blockModel.Color = this.ActiveColor.As<SolidColorBrush>().Color;
            }
        }
    }
}
