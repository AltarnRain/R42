// <copyright file="BaseModelHandler.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.DataHandling.ModelHandlers
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Providers animation models
    /// </summary>
    /// <seealso cref="BlockEngine.DataHandling.Interfaces.IModelProvider" />
    public abstract class BaseModelHandler
    {
        /// <summary>
        /// Gets a model of type T based on the XML string
        /// </summary>
        /// <typeparam name="T">A model type</typeparam>
        /// <param name="xmlString">The XML string.</param>
        /// <returns>
        /// An instance of T
        /// </returns>
        public virtual T GetModel<T>(string xmlString)
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

        /// <summary>
        /// Generates the XML.
        /// </summary>
        /// <typeparam name="T">A model of type T</typeparam>
        /// <param name="model">The model.</param>
        /// <returns>XML string</returns>
        /// <exception cref="System.Exception">An error occurred</exception>
        public virtual string GenerateXml<T>(T model)
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
    }
}