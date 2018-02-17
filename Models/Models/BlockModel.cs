﻿// <copyright file="BlockModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models
{
    using System.Windows.Media;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the basic block of a shape.
    /// </summary>
    public class BlockModel : BaseModel
    {
        /// <summary>
        /// The color
        /// </summary>
        private Color color;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public Color Color
        {
            get
            {
                return Color.FromRgb(this.R, this.G, this.B);
            }

            set
            {
                this.color = value;
                this.R = value.R;
                this.G = value.G;
                this.B = value.B;
            }
        }

        /// <summary>
        /// Gets or sets the r.
        /// </summary>
        /// <value>
        /// The r.
        /// </value>
        public byte R { get; set; }

        /// <summary>
        /// Gets or sets the g.
        /// </summary>
        /// <value>
        /// The g.
        /// </value>
        public byte G { get; set; }

        /// <summary>
        /// Gets or sets the b.
        /// </summary>
        /// <value>
        /// The b.
        /// </value>
        public byte B { get; set; }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BlockModel"/> an anchor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if anchor; otherwise, <c>false</c>.
        /// </value>
        public bool Anchor { get; set; }

        /// <summary>
        /// Creates a block model
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <returns>a block model</returns>
        public static BlockModel Create(int column, int row)
        {
            return new BlockModel
            {
                Color = Color.FromRgb(0, 0, 0),
                Column = column,
                Row = row
            };
        }

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        public void SetColor(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}