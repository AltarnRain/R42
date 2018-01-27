// <copyright file="PaletTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetManagerView.Tests
{
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Extentions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the palet component
    /// </summary>
    [TestClass]
    public class PaletTests
    {
        /// <summary>
        /// Creates the test.
        /// </summary>
        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            var colors = new Color[] { Color.Red, Color.Black, Color.Blue, Color.Green };

            // Act
            var palet = Palet.Create(colors);

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
            var colors = new Color[] { Color.Red, Color.Black, Color.Blue, Color.Green };
            var palet = Palet.Create(colors);

            // Act
            foreach (var c in palet.Controls)
            {
                if (c is Button)
                {
                    var b = c as Button;
                    if (colors.Any(color => color == c.As<Button>().ForeColor) == false)
                    {
                        Assert.Fail();
                    }
                }
            }

            // If not fail then test passes.
        }
    }
}