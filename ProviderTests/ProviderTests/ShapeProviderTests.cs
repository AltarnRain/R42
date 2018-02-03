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
        public void ShapeModelCreateTest()
        {
            var x = 10;
            var y = 5;

            var shapeModel = this.Get<ShapeProvider>().Create(15, 55);

            var block = shapeModel.Blocks.Single(b => b.X == x && b.Y == y);

            Assert.AreEqual(x, block.X);
            Assert.AreEqual(y, block.Y);
            Assert.AreEqual("Black", block.ColorName);
        }
    }
}
