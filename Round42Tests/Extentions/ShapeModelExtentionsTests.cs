// <copyright file="ShapeModelExtentionsTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round242.Tests.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Models;
    using Round42.Models.Extentions;
    using Round42.Providers;
    using Round42.Tests;

    /// <summary>
    /// Tests the <see cref="ShapeModel"/> extentions/>
    /// </summary>
    [TestClass]
    public class ShapeModelExtentionsTests : TestBase
    {
        /// <summary>
        /// Tests the AddRow extention method
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsAddRow()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            // Act
            shape.AddRow();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(55, numberOfBlocks);

            var newRow = shape.GetRow(rows + 1);
            Assert.AreEqual(5, newRow.Count());

            for (var col = 0; col < columns; col++)
            {
                var foundBlock = shape.Blocks.Any(b => b.Column == col + 1 && b.Row == rows + 1);
                Assert.IsTrue(foundBlock);
            }
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsAddColumn()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            // Act
            shape.AddColumn();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(60, numberOfBlocks);

            var newColumn = shape.GetColumn(columns + 1);
            Assert.AreEqual(rows, newColumn.Count());

            for (var row = 0; row < rows; row++)
            {
                var foundBlock = shape.Blocks.Any(b => b.Row == row + 1 && b.Column == columns + 1);
                Assert.IsTrue(foundBlock);
            }
        }
    }
}
