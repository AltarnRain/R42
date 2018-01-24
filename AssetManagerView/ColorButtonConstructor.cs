// <copyright file="ColorButtonConstructor.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetManagerView
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Created buttons for setting color
    /// </summary>
    public class ColorButtonConstructor
    {
        /// <summary>
        /// The panel
        /// </summary>
        private readonly Panel panel;

        /// <summary>
        /// The colors
        /// </summary>
        private readonly string[] colors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorButtonConstructor"/> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        public ColorButtonConstructor(Panel panel)
        {
            this.panel = panel;
            this.colors = new string[]
            {
                Color.White.Name,
                Color.Blue.Name,
                Color.Green.Name,
                Color.Red.Name,
                Color.Black.Name,
            };
        }

        /// <summary>
        /// Called when a button changes the active color.
        /// </summary>
        /// <param name="colorName">Name of the color.</param>
        public delegate void ColorSelected(string colorName);

        /// <summary>
        /// Occurs when [on color selected].
        /// </summary>
        public event ColorSelected OnColorSelected;

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        public void DrawButtons()
        {
            foreach (var colorName in this.colors)
            {
                var button = new Button();
                button.ForeColor = Color.FromName(colorName);
                button.BackColor = Color.FromName(colorName);
                button.Dock = DockStyle.Top;
                button.Height = 30;
                button.Click += this.Click;

                this.panel.Controls.Add(button);
            }
        }

        private void Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var colorName = button.ForeColor.Name;
            this.OnColorSelected?.Invoke(colorName);
        }
    }
}
