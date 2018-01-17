// <copyright file="BaseModel.Extentions.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.DataHandling.Extentions
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using BlockEngine.Models;

    /// <summary>
    /// Extentions for BaseModel
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Generates the XML.
        /// </summary>
        /// <typeparam name="T">A model of type T</typeparam>
        /// <param name="model">The model.</param>
        /// <returns>
        /// XML string
        /// </returns>
        /// <exception cref="System.Exception">An error occurred</exception>
        public static string Serialize<T>(this BaseModel model)
        {
            if (model == null)
            {
                return string.Empty;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";

                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, model);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        /// <summary>
        /// Clones the specified model.
        /// </summary>
        /// <typeparam name="T">A model</typeparam>
        /// <param name="model">The model.</param>
        /// <returns>The model T</returns>
        public static T Clone<T>(this BaseModel model)
            where T : class
        {
            var modelAsXml = model.Serialize<T>();
            var newModel = modelAsXml.Deserialize<T>();
            return newModel;
        }
    }
}
