// <copyright file="ShapeModelTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Test.Providers
{
    using System.Linq;
    using BlockEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for ShapeModel extentions
    /// </summary>
    /// <seealso cref="BlockEngine.Test.TestBase" />
    [TestClass]
    public class ShapeModelTests : TestBase
    {
        /// <summary>
        /// Test the generation of a new shape
        /// </summary>
        [TestMethod]
        public void NewShape()
        {
            // Arrange
            // Assert
            var width = 10;
            var height = 5;
            var model = ShapeModel.Create(width, height);

            Assert.AreEqual(height * width, model.Blocks.Count());
        }

        /// <summary>
        /// Gets the block.
        /// </summary>
        [TestMethod]
        public void GetBlock()
        {
            var x = 10;
            var y = 5;

            var shapeModel = ShapeModel.Create(15, 55);

            var block = shapeModel.Get(x, y);

            Assert.AreEqual(x, block.X);
            Assert.AreEqual(y, block.Y);
            Assert.AreEqual("Black", block.ColorName);
        }
    }
}
