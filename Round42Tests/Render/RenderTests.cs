﻿// <copyright file="RenderTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests.Render
{
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Factories;
    using Round42.Providers;
    using Round42.Tests;

    /// <summary>
    /// Tests the Render class
    /// </summary>
    /// <seealso cref="Round42.Tests.TestBase" />
    [TestClass]
    public class RenderTests : TestBase
    {
        /// <summary>
        /// Tests the render.
        /// </summary>
        [TestMethod]
        public void TestRender()
        {
            // Arrange
            var render = this.Get<RenderFactory>().Get(this.GetOutFolder());
            var shapeProvider = this.Get<ShapeProvider>();

            var shape = shapeProvider.Create(5, 5);

            shape.Blocks.Where(b => b.Column == 3).ToList().ForEach(b => b.Color = Color.Red);
            shape.Blocks.Where(b => b.Row == 3).ToList().ForEach(b => b.Color = Color.Red);

            // Act
            var fileName = render.RenderShapeToBitmapFile(shape, this.GetOutFolder(), "TestBitmap", 1);

            // Assert.
            var fileExists = File.Exists(this.GetOutFolder() + "TestBitmap_01.bmp");
            Assert.IsTrue(fileExists);

            // Process.Start(fileName);
        }
    }
}
