// <copyright file="RenderTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round242.Tests.Render
{
    using System.IO;
    using System.Linq;
    using System.Windows.Media;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Factories.Factories;
    using Round42.Providers;
    using Round42.Tests;

    /// <summary>
    /// Tests the Render class
    /// </summary>
    /// <seealso cref="Round42.Tests.TestBase" />
    [TestClass]
    public class RenderTests :TestBase
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

            shape.Blocks.Where(b => b.Column == 3).ToList().ForEach(b => b.Color.Equals(Color.FromRgb(255, 0, 0)));
            shape.Blocks.Where(b => b.Row == 3).ToList().ForEach(b => b.Color.Equals(Color.FromRgb(255, 0, 0)));

            // Act
            var fileName = render.RenderShapeToBitmap(shape, "TestBitmap", 1);

            // Assert.
            var fileExists = File.Exists(this.GetOutFolder() + "TestBitmap_01.bmp");
            Assert.IsTrue(fileExists);

            // Process.Start(fileName);
        }
    }
}
