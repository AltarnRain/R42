﻿// <copyright file="PreviewBar.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.CustomComponents.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Render;
    using Round42.Models.Drawing;
    using Round42.Models.Enumerators;
    using Round42.R42Extentions;

    /// <summary>
    /// Shows a preview of each image.
    /// </summary>
    public class PreviewBar
    {
        /// <summary>
        /// The image generator
        /// </summary>
        private readonly ImageGenerator imageGenerator;

        /// <summary>
        /// The panel
        /// </summary>
        private readonly Panel panel;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewBar"/> class.
        /// </summary>
        /// <param name="imageGenerator">The image generator.</param>
        /// <param name="panel">The panel.</param>
        public PreviewBar(ImageGenerator imageGenerator, Panel panel)
        {
            this.imageGenerator = imageGenerator;
            this.panel = panel;

            this.panel.AutoScroll = true;
        }

        /// <summary>
        /// Gets or sets the on select image.
        /// </summary>
        /// <value>
        /// The on select image.
        /// </value>
        public Action<int> OnSelectImage { get; set; }

        /// <summary>
        /// Gets or sets the on move image left.
        /// </summary>
        /// <value>
        /// The on move image left.
        /// </value>
        public Action<int> OnMoveImageLeft { get; set; }

        /// <summary>
        /// Gets or sets the on move image right.
        /// </summary>
        /// <value>
        /// The on move image right.
        /// </value>
        public Action<int> OnMoveImageRight { get; set; }

        /// <summary>
        /// Draws the specified shapes.
        /// </summary>
        /// <param name="shapes">The shapes.</param>
        public void Draw(IEnumerable<ShapeModel> shapes)
        {
            this.panel.Controls.Clear();
            this.panel.SuspendLayout();

            var index = shapes.Count() - 1;

            this.panel.Height = 20 + (shapes.Max(s => s.LastRow()) * 20);

            foreach (var shape in shapes.Reverse())
            {
                var mainPanel = new Panel();
                var image = new Panel();
                var bitmap = this.imageGenerator.RenderShapeToBitmap(shape);

                image.Width = bitmap.Width;
                image.Height = bitmap.Height;
                image.Top = 0;
                image.Left = 20;
                image.BorderStyle = BorderStyle.Fixed3D;
                image.Tag = index;
                image.Click += this.OnDrawSurfaceClick;
                image.BackgroundImage = bitmap;
                image.BackColor = CGA16Colors.Black.GetColor();

                var moveLeftButton = this.CreateMovebutton("<", this.MoveLeft);
                var moveRightButton = this.CreateMovebutton(">", this.MoveRight);

                moveLeftButton.Dock = DockStyle.Left;
                moveLeftButton.Tag = index;
                moveRightButton.Dock = DockStyle.Right;
                moveRightButton.Tag = index;

                mainPanel.Controls.Add(moveLeftButton);
                mainPanel.Controls.Add(image);
                mainPanel.Controls.Add(moveRightButton);
                mainPanel.Dock = DockStyle.Left;
                mainPanel.Width = image.Width + 40;

                index--;

                this.panel.Controls.Add(mainPanel);
            }

            this.panel.ResumeLayout();
        }

        private Button CreateMovebutton(string text, EventHandler moveMethod)
        {
            var button = new Button();
            button.Height = this.panel.Height;
            button.Width = 20;
            button.Text = text;
            button.Click += moveMethod;

            return button;
        }

        private void MoveLeft(object sender, EventArgs e)
        {
            var index = this.GetButtonIndex(sender);
            this.OnMoveImageLeft?.Invoke(index);
        }

        private int GetButtonIndex(object sender)
        {
            var button = sender as Button;
            return (int)button.Tag;
        }

        private void MoveRight(object sender, EventArgs e)
        {
            var index = this.GetButtonIndex(sender);
            this.OnMoveImageRight?.Invoke(index);
        }

        private void OnDrawSurfaceClick(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            this.OnSelectImage((int)panel.Tag);
        }
    }
}
