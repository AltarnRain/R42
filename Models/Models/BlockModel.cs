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
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y { get; set; }

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
    }
}