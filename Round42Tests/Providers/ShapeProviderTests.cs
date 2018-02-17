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
        public void CreateTest()
        {
            // Arrange
            var x = 10;
            var y = 5;

            // Act
            var shapeModel = this.Get<ShapeProvider>().Create(x, y);

            // Assert
            var block = shapeModel.Blocks.Single(b => b.Column == x && b.Row == y);

            Assert.AreEqual(x, block.Column);
            Assert.AreEqual(y, block.Row);
        }

        /// <summary>
        /// Checks the shape dimensions.
        /// </summary>
        [TestMethod]
        public void CheckShapeDimensions()
        {
            // Arrange
            var x = 10;
            var y = 5;

            // Act
            var shapeModel = this.Get<ShapeProvider>().Create(x, y);

            // Assert
            var maxX = shapeModel.Blocks.Max(b => b.Column);
            var maxY = shapeModel.Blocks.Max(b => b.Row);

            Assert.AreEqual(x, maxX);
            Assert.AreEqual(y, maxY);
        }
    }
}
