// <copyright file="Render.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Render
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Round42.Models;

    /// <summary>
    /// Render class
    /// </summary>
    public class Render
    {
        /// <summary>
        /// Makes the images.
        /// </summary>
        /// <param name="assetModel">The asset model.</param>
        public void MakeImages(AssetModel assetModel)
        {
            foreach (var shape in assetModel.Shapes)
            {
                this.RenderShape(shape);
            }
        }

        private void RenderShape(ShapeModel shapeModel)
        {

        }
    }
}
