// <copyright file="AnimationModelHandler.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.DataHandling.ModelHandlers
{
    using System;
    using System.Drawing;
    using BlockEngine.DataHandling.Extentions;
    using BlockEngine.Models;

    /// <summary>
    /// Animation model handlers
    /// </summary>
    public class AnimationModelHandler
    {
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <param name="xmlString">The XML string.</param>
        /// <returns>An animation model</returns>
        /// <exception cref="InvalidCastException">Model was not of type AnimationModel</exception>
        public AnimationModel GetModel(string xmlString)
        {
            // Get the basic model.
            var returnValue = xmlString.Deserialize<AnimationModel>();

            if (returnValue == null)
            {
                throw new InvalidCastException("Model was not of type AnimationModel");
            }

            // Set color for each block. The Color is not serializable.
            foreach (var shape in returnValue.Shapes)
            {
                foreach (var block in shape.Blocks)
                {
                    block.ColorName = Color.Black.Name;
                }
            }

            return returnValue;
        }
    }
}
