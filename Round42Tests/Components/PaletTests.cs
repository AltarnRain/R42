// <copyright file="PaletTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System.Linq;
    using System.Windows.Controls;
    using Extentions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.CustomComponents;
    using Round42.Factories.Factories;
    using Round42.Providers;

    /// <summary>
    /// Tests the palet component
    /// </summary>
    [TestClass]
    public class PaletTests : TestBase
    {
        /// <summary>
        /// Creates the test.
        /// </summary>
        [TestMethod]
        public void PaletCreateTest()
        {
            // Arrange
            var colors = this.Get<ColorProvider>().GetColors();
            var panel = new StackPanel();

            // Act
            var palet = this.Get<PaletFactory>().Get(panel);

            // Assert
            var numberOfControls = palet.ColorButtons.Count();

            Assert.AreEqual(colors.Length, numberOfControls);
        }

        /// <summary>
        /// Tests if all the colors were assigned to the buttons.
        /// </summary>
        [TestMethod]
        public void SetColorTest()
        {
            // Arrange
            var colors = this.Get<ColorProvider>().GetColors();
            var panel = new StackPanel();

            // Act
            var palet = this.Get<PaletFactory>().Get(panel);

            // Act
            foreach (var c in palet.ColorButtons)
            {
                if (c is Button)
                {
                    var b = c as Button;
                    if (colors.Any(color => color.Equals(c.Foreground)) == false)
                    {
                        Assert.Fail();
                    }
                }
            }

            // If not fail then test passes.
        }
    }
}