// <copyright file="AnimationModelHandler.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.DataHandling.ModelHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlockEngine.DataHandling.Extentions;
    using BlockEngine.DataHandling.ModelHandlers;
    using BlockEngine.Models;

    /// <summary>
    /// Animation model handlers
    /// </summary>
    /// <seealso cref="BlockEngine.DataHandling.ModelHandlers.BaseModelHandler" />
    public class AnimationModelHandler : BaseModelHandler
    {
        /// <summary>
        /// The animation model handle
        /// </summary>
        private static AnimationModelHandler animationModelHandler = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationModelHandler"/> class.
        /// </summary>
        private AnimationModelHandler()
            : base()
        {
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>An instance of AnimationModelHandler</returns>
        public static AnimationModelHandler Create()
        {
            if (animationModelHandler == null)
            {
                animationModelHandler = new AnimationModelHandler();
            }

            return animationModelHandler;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <param name="xmlString">The XML string.</param>
        /// <returns>An animation model</returns>
        /// <exception cref="InvalidCastException">Model was not of type AnimationModel</exception>
        public AnimationModel GetModel(string xmlString)
        {
            // Get the basic model.
            var returnValue = base.GetModel<AnimationModel>(xmlString);

            if (returnValue == null)
            {
                throw new InvalidCastException("Model was not of type AnimationModel");
            }

            // Set color for each block. The Color is not serializable.
            foreach (var shape in returnValue.Shapes)
            {
                foreach (var block in shape.Blocks)
                {
                    block.Color = block.ColorName.ToColor();
                }
            }

            return returnValue;
        }
    }
}
