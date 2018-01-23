﻿// <copyright file="String.Extentions.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.DataHandling.Extentions
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The extention class
    /// </summary>
    public static partial class ExtentionClass
    {
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
