// <copyright file="ShapeModelTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Test.Providers
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Models;

    /// <summary>
    /// Tests for ShapeModel extentions
    /// </summary>
    [TestClass]
    public class ShapeModelTests
    {
        /// <summary>
        /// Gets the block.
        /// </summary>
        [TestMethod]
        public void ShapeModelCreateTest()
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
