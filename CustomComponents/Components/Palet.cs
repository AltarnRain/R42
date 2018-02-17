// <copyright file="Palet.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.CustomComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Round42.Providers;

    /// <summary>
    /// Created buttons for setting color
    /// </summary>
    public class Palet
    {
        private readonly ColorProvider colorProvider;

        /// <summary>
        /// The button height
        /// </summary>
        private readonly int buttonHeight;

        /// <summary>
        /// The panel
        /// </summary>
        private readonly StackPanel panel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Palet" /> class.
        /// </summary>
        /// <param name="colorProvider">The color provider.</param>
        /// <param name="buttonHeight">The button height</param>
        /// <param name="panel">The panel.</param>
        public Palet(ColorProvider colorProvider, int buttonHeight, StackPanel panel)
            : base()
        {
            this.colorProvider = colorProvider;
            this.buttonHeight = buttonHeight;
            this.panel = panel;
            this.DrawButtons();
        }

        /// <summary>
        /// Called when a button changes the active color.
        /// </summary>
        /// <param name="color">The color.</param>
        public delegate void ColorSelected(Brush color);

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
                return this.panel.Children.Cast<Button>();
            }
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        public void DrawButtons()
        {
            foreach (var color in this.colorProvider.GetColors())
            {
                var button = new Button();
                button.Foreground = button.Background = Brushes.Black;
                button.Width = 30;
                button.Click += this.ButtonClick;

                this.panel.Children.Add(button);
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
            var color = button.Foreground;
            this.OnColorSelected?.Invoke(color);
        }
    }
}
