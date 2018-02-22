// <copyright file="ImageGenerator.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Render
{
    using System.Drawing;
    using Round42.Models;
    using Round42.Models.Extentions;

    /// <summary>
    /// Render class
    /// </summary>
    public class ImageGenerator
    {
        private readonly string folder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageGenerator"/> class.
        /// </summary>
        /// <param name="folder">The folder.</param>
        public ImageGenerator(string folder)
        {
            this.folder = folder;
        }

        /// <summary>
        /// Renders the shape.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="name">The name.</param>
        /// <param name="count">The count.</param>
        /// <returns>A filename</returns>
        public string RenderShapeToBitmap(ShapeModel shapeModel, string name, int count)
        {
            var width = 20 * shapeModel.LastColumn();
            var height = 20 * shapeModel.LastRow();

            var b = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(b);

            var size = 20;
            foreach (var block in shapeModel.Blocks)
            {
                var x = (block.Column - 1) * size;
                var y = (block.Row - 1) * size;

                var rect = new Rectangle(x, y, size, size);

                g.FillRectangle(new SolidBrush(block.Color), rect);
            }

            var paddedCount = count.ToString().PadLeft(2, '0');
            var fileName = this.folder + $"{name}_{paddedCount}.bmp";

            b.MakeTransparent(Color.Black);
            b.Save(fileName);
            return fileName;
        }
    }
}