// <copyright file="ShapeProviderTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Providers;

    /// <summary>
    /// Tests for ShapeModel extentions
    /// </summary>
    [TestClass]
    public class ShapeProviderTests : TestBase
    {
        /// <summary>
        /// Gets the block.
        /// </summary>
        [TestMethod]
        public void ShapeProviderCreate()
        {
            // Arrange
            var x = 10;
            var y = 5;

            // Act
            var shapeModel = this.Get<ShapeProvider>().Create(x, y);

            // Assert
            var block = shapeModel.Blocks.Single(b => b.X == x && b.Y == y);

            Assert.AreEqual(x, block.X);
            Assert.AreEqual(y, block.Y);
            Assert.AreEqual("Black", block.ColorName);
        }

        /// <summary>
        /// Checks the shape dimensions.
        /// </summary>
        [TestMethod]
        public void ShapeProviderCheckShapeDimensions()
        {
            // Arrange
            var x = 10;
            var y = 5;

            // Act
            var shapeModel = this.Get<ShapeProvider>().Create(x, y);

            // Assert
            var maxX = shapeModel.Blocks.Max(b => b.X);
            var maxY = shapeModel.Blocks.Max(b => b.Y);

            Assert.AreEqual(x, maxX);
            Assert.AreEqual(y, maxY);
        }
    }
}
