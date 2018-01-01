// <copyright file="String.Extentions.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.DataHandling.Extentions
{
    using System;
    using System.Drawing;

    /// <summary>
    /// The extention class
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Convert a string value to a Color if the value matches a predefined color
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A color</returns>
        public static Color ToColor(this string value)
        {
            switch (value)
            {
                case Constants.ColorNames.Red:
                    return Color.Red;

                case Constants.ColorNames.Blue:
                    return Color.Blue;
                default:
                    throw new NotImplementedException(string.Format("Color {0} is not supported", value));
            }
        }
    }
}
