// <copyright file="Render.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Render
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Round42.Models;
    using Round42.Models.Extentions;

    /// <summary>
    /// Render class
    /// </summary>
    public class Render
    {
        private readonly Panel panel;

        public Render(Panel panel)
        {
            this.panel = panel;
        }

        /// <summary>
        /// Renders the shape.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public void RenderShape(ShapeModel shapeModel)
        {
            var g = this.panel.CreateGraphics();
            var size = this.panel.Width / shapeModel.LastColumn();
            var rects = new List<RectangleF>();
            foreach (var block in shapeModel.Blocks)
            {
                var x = (block.Column - 1) * size;
                var y = (block.Row - 1) * size;

                var rect = new Rectangle(x, y, size, size);
                g.FillRectangle(new SolidBrush(block.Color), rect);
            }
        }

        /// <summary>
        /// Animates the shapes.
        /// </summary>
        /// <param name="shapeModels">The shape models.</param>
        public void AnimateShapes(List<ShapeModel> shapeModels)
        {

            while (true)
            {
                var numberOfShapeModels = shapeModels.Count();

                for (int i = 0; i < numberOfShapeModels - 1; i++)
                {
                    this.RenderShape(shapeModels[i]);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }

                for (int i = numberOfShapeModels - 1; i > 1; i--)
                {
                    this.RenderShape(shapeModels[i]);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
    }
}