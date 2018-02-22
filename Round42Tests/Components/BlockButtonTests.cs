// <copyright file="BlockButtonTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System.Drawing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.CustomComponents;
    using Round42.Models;

    /// <summary>
    /// Tests the block button.
    /// </summary>
    [TestClass]
    public class BlockButtonTests
    {
        /// <summary>
        /// Tests the creation of a block button.
        /// </summary>
        [TestMethod]
        public void CreateTest()
        {
            var block = BlockModel.Create(0, 0);

            // Act
            var button = new BlockButton(block, Color.Black);

            // Assert
            Assert.AreEqual(Color.Black, button.ActiveColor);
        }

        /// <summary>
        /// Tests the creation of a block button.
        /// </summary>
        [TestMethod]
        public void SetActiveColor()
        {
            var block = BlockModel.Create(0, 0);
            var button = new BlockButton(block, Color.Black);

            // Act
            button.ActiveColor = Color.Red;

            // Assert
            Assert.AreEqual(button.ActiveColor, Color.Red);
        }
    }
}