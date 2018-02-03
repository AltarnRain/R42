﻿// <copyright file="DrawerTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System.Drawing;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Providers;
    using Round42.CustomComponents;
    using Round42.Tests;

    /// <summary>
    /// Tests the Drawer component
    /// </summary>
    [TestClass]
    public class DrawerTests : TestBase
    {
        /// <summary>
        /// Tests the creation of the drawer component.
        /// </summary>
        [TestMethod]
        public void DrawerCreateTest()
        {
            // Arrange
            var shapeModel = this.Get<ShapeProvider>().Create(3, 5);

            // Act
            var drawer = new Drawer();
            drawer.DrawButtons(shapeModel);

            // Assert
            var numberOfButtons = drawer.BlockButtons.Count();

            // Each block should have its own button
            Assert.AreEqual(shapeModel.Blocks.Count, numberOfButtons);
        }

        /// <summary>
        /// Tests setting the active components
        /// </summary>
        [TestMethod]
        public void SetAciveColorTest()
        {
            // Arrange
            var shapeModel = this.Get<ShapeProvider>().Create(3, 5);

            // Act
            var drawer = new Drawer();

            drawer.SetAciveColor(Color.BlueViolet);

            var allButtonsSet = drawer.BlockButtons.All(b => b.ActiveColor == Color.BlueViolet);

            Assert.IsTrue(allButtonsSet);
        }
    }
}