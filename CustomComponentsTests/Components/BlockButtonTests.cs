// <copyright file="BlockButtonTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace CustomComponents.Components.Tests
{
    using System.Drawing;
    using BlockEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var block = new BlockModel();
            block.Color = Color.Red;

            // Act
            var button = BlockButton.Create(block, Color.Black);

            // Assert
            Assert.AreEqual(Color.Red, button.ForeColor);
        }

        /// <summary>
        /// Tests the creation of a block button.
        /// </summary>
        [TestMethod]
        public void SetActiveColor()
        {
            var block = new BlockModel();
            block.ColorName = Color.Red.Name;
            var button = BlockButton.Create(block, Color.Black);

            // Act
            button.SetActiveColor(Color.Red);

            // Assert
            Assert.AreEqual(button.ActiveColor, Color.Red);
        }
    }
}