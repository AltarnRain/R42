// <copyright file="Render.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Render
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using Round42.Models;
    using Round42.Models.Extentions;
    using Round42.Models.Models;

    /// <summary>
    /// Render class
    /// </summary>
    public class Render
    {
        private readonly string folder;

        /// <summary>
        /// Initializes a new instance of the <see cref="Render"/> class.
        /// </summary>
        /// <param name="folder">The folder.</param>
        public Render(string folder)
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

        /// <summary>
        /// Animates the shapes.
        /// </summary>
        /// <param name="assetModel">The shape models.</param>
        /// <returns>File names</returns>
        public AssetBitmapModel RenderAsset(AssetModel assetModel)
        {
            var files = new List<string>();
            for (int i = 0; i < assetModel.Shapes.Count(); i++)
            {
                files.Add(this.RenderShapeToBitmap(assetModel.Shapes[i], assetModel.Name, i + 1));
            }

            return new AssetBitmapModel { Name = assetModel.Name, Bitmaps = files };
        }

        /// <summary>
        /// Renders the assets.
        /// </summary>
        /// <param name="assets">The assets.</param>
        /// <returns>List of generated files</returns>
        public IEnumerable<AssetBitmapModel> RenderAssets(IEnumerable<AssetModel> assets)
        {
            var allFiles = new List<AssetBitmapModel>();
            foreach (var asset in assets)
            {
                var assetBitmaps = this.RenderAsset(asset);
                allFiles.Add(assetBitmaps);
            }

            return allFiles;
        }
    }
}