// <copyright file="ColorProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Providers
{
    using System.Drawing;

    /// <summary>
    /// Providers Color
    /// </summary>
    public class ColorProvider
    {
        /// <summary>
        /// Gets the colors of the CGA 16 palet.
        /// </summary>
        /// <returns>An array of colors</returns>
        public Brush[] GetColors()
        {
            //return new Color[]
            //{
            //    Color.Gray, Color.Brown, Color.Magenta,
            //    Color.Red, Color.Cyan, Color.Green,
            //    Color.Blue, Color.Black,
            //    Color.White, Color.Yellow, Color.LightPink,
            //    Color.PaleVioletRed, Color.LightCyan, Color.LightGreen,
            //    Color.LightBlue, Color.DarkGray
            //};

            return new Brush[]
{
                Brushes.Gray, Brushes.Brown, Brushes.Magenta,
                Brushes.Red, Brushes.Cyan, Brushes.Green,
                Brushes.Blue, Brushes.Black,
                Brushes.White, Brushes.Yellow, Brushes.LightPink,
                Brushes.PaleVioletRed, Brushes.LightCyan, Brushes.LightGreen,
                Brushes.LightBlue, Brushes.DarkGray
};
        }
    }
}
