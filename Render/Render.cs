// <copyright file="Render.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Render
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Round42.Models;
    using Round42.Models.Extentions;

    /// <summary>
    /// Render class
    /// </summary>
    public class Render
    {
        private readonly Panel panel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Render"/> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        public Render(Panel panel)
        {
            this.panel = panel;
        }

        /// <summary>
        /// Renders the shape.
        /// </summary>
        /// <param name="blocks">The blocks.</param>
        /// <param name="size">The size.</param>
        public void RenderShape(List<BlockModel> blocks, int size)
        {
            var g = this.panel.CreateGraphics();
            var rects = new List<RectangleF>();
            foreach (var block in blocks)
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
            var numberOfShapeModels = shapeModels.Count();
            var size = this.panel.Width / shapeModels.First().LastColumn();
            while (true)
            {
                for (int i = 0; i < numberOfShapeModels - 1; i++)
                {
                    this.RenderShape(shapeModels[i].Blocks, size);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }

                for (int i = numberOfShapeModels - 1; i > 1; i--)
                {
                    this.RenderShape(shapeModels[i].Blocks, size);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
    }
}