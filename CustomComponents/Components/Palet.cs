// <copyright file="Palet.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.CustomComponents
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Created buttons for setting color
    /// </summary>
    public class Palet : Panel
    {
        /// <summary>
        /// The colors
        /// </summary>
        private readonly Color[] colors;

        /// <summary>
        /// The button height
        /// </summary>
        private readonly int buttonHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="Palet" /> class.
        /// </summary>
        /// <param name="colors">The colors.</param>
        /// <param name="buttonHeight">The button height</param>
        private Palet(Color[] colors, int buttonHeight)
        {
            this.colors = colors;
            this.buttonHeight = buttonHeight;
            this.Dock = DockStyle.Fill;
            this.DrawButtons();
        }

        /// <summary>
        /// Called when a button changes the active color.
        /// </summary>
        /// <param name="color">The color.</param>
        public delegate void ColorSelected(Color color);

        /// <summary>
        /// Occurs when [on color selected].
        /// </summary>
        public event ColorSelected OnColorSelected;

        /// <summary>
        /// Gets the color buttons.
        /// </summary>
        /// <value>
        /// The color buttons.
        /// </value>
        public IEnumerable<Button> ColorButtons
        {
            get
            {
                return this.Controls.Cast<Button>();
            }
        }

        /// <summary>
        /// Creates the specified colors.
        /// </summary>
        /// <param name="colors">The colors.</param>
        /// <param name="buttonHeight">Height of the button.</param>
        /// <returns>A palet with the desired colors</returns>
        public static Palet Create(Color[] colors, int buttonHeight = 30)
        {
            return new Palet(colors, buttonHeight);
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        public void DrawButtons()
        {
            foreach (var color in this.colors)
            {
                var button = new Button();
                button.ForeColor = button.BackColor = color;
                button.Dock = DockStyle.Top;
                button.Height = 30;
                button.Click += this.ButtonClick;

                this.Controls.Add(button);
            }
        }

        /// <summary>
        /// Clicks the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            var color = button.ForeColor;
            this.OnColorSelected?.Invoke(color);
        }
    }
}
