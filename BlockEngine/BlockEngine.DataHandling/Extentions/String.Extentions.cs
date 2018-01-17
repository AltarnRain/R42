// <copyright file="String.Extentions.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.DataHandling.Extentions
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using BlockEngine.Models;

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

                case Constants.ColorNames.Black:
                    return Color.Black;
                default:
                    throw new NotImplementedException(string.Format("Color {0} is not supported", value));
            }
        }

        /// <summary>
        /// Gets a model of type T based on the XML string
        /// </summary>
        /// <typeparam name="T">A model type</typeparam>
        /// <param name="xmlString">The XML string.</param>
        /// <returns>
        /// An instance of T
        /// </returns>
        /// <exception cref="System.InvalidCastException">Invalid model cast</exception>
        /// <exception cref="System.Exception">An error occurred</exception>
        public static T Deserialize<T>(this string xmlString)
            where T : class
        {
            if (xmlString == null)
            {
                return null;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringReader = new StringReader(xmlString);

                using (var reader = XmlReader.Create(stringReader))
                {
                    var returnValue = xmlserializer.Deserialize(reader) as T;

                    if (returnValue == null)
                    {
                        throw new InvalidCastException("Invalid model cast");
                    }
                    else
                    {
                        return returnValue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
    }
}
