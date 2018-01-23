// <copyright file="BlockModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Models
{
    using System.Drawing;

    /// <summary>
    /// Defines the basic block of a shape.
    /// </summary>
    public class BlockModel : BaseModel
    {
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
        public Color Color { get; set; }

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
            get => this.colorName;
            set
            {
                this.colorName = value;
                this.Color = Color.FromName(value);
            }
        }

        /// <summary>
        /// Sets the specified color name.
        /// </summary>
        /// <param name="colorName">Name of the color.</param>
        public void SetColor(string colorName)
        {
            this.ColorName = colorName;
        }
    }
}