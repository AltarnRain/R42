// <copyright file="BlockButtonTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.CustomComponents;
    using Round42.Models;
    using System.Windows.Media;

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
            var button = new BlockButton(block);

            // Assert
            Assert.AreEqual(Brushes.Black, button.ActiveColor);
        }

        /// <summary>
        /// Tests the creation of a block button.
        /// </summary>
        [TestMethod]
        public void SetActiveColor()
        {
            var block = BlockModel.Create(0, 0);
            var button = new BlockButton(block);

            // Act
            button.ActiveColor = Brushes.Red;

            // Assert
            Assert.AreEqual(button.ActiveColor, Brushes.Red);
        }
    }
}