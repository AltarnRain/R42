// <copyright file="BlockModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models
{
    using System.Drawing;
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
        /// The color name
        /// </summary>
        private string colorName;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        [XmlIgnore]
        public Color Color
        {
            get
            {
                return this.color;
            }

            set
            {
                if (this.Color != value)
                {
                    this.color = value;
                    this.ColorName = value.Name;
                }
            }
        }

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
        /// Gets or sets the name of the color.
        /// </summary>
        /// <value>
        /// The name of the color.
        /// </value>
        public string ColorName
        {
            get
            {
                return this.colorName;
            }

            set
            {
                if (this.colorName != value)
                {
                    this.color = Color.FromName(value);
                    this.colorName = value;
                }
            }
        }

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
                Color = Color.Black,
                Column = column,
                Row = row
            };
        }
    }
}