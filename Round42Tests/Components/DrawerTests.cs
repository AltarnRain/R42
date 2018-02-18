// <copyright file="DrawerTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Providers;
    using Round42.Factories.Factories;

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
        public void CreateTest()
        {
            // Arrange
            var shapeModel = this.Get<ShapeProvider>().Create(3, 5);
            var panel = new Canvas();

            // Act
            var drawer = this.Get<DrawerFactory>().Get(panel);
            drawer.DrawButtons(shapeModel, 20);

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
            var panel = new Canvas();

            // Act
            var drawer = this.Get<DrawerFactory>().Get(panel);

            drawer.SetAciveColor(Brushes.BlueViolet);

            var allButtonsSet = drawer.BlockButtons.All(b => b.ActiveColor.Equals(Brushes.BlueViolet));

            Assert.IsTrue(allButtonsSet);
        }
    }
}