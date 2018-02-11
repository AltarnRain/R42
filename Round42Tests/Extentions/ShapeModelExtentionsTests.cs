// <copyright file="ShapeModelExtentionsTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round242.Tests.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
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
        public void ShapeModelExtentionsAddRowTop()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeRowRed(shape, 10);

            // Act
            shape.AddRowTop();

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

            var expectedRowIsRed = shape.GetRow(11).All(b => b.Color == Color.Red);
            Assert.IsTrue(expectedRowIsRed);
        }

        /// <summary>
        /// Tests the AddRow extention method
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsAddRowBottom()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeRowRed(shape, 10);

            // Act
            shape.AddRowBottom();

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

            var expectedRowIsRed = shape.GetRow(10).All(b => b.Color == Color.Red);
            Assert.IsTrue(expectedRowIsRed);

            var bottomRowIsBlack = shape.GetRow(11).All(b => b.Color == Color.Black);
            Assert.IsTrue(bottomRowIsBlack);
        }

        /// <summary>
        /// Tests the AddRow extention method
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsRemoveRowTop()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeRowRed(shape, 10);

            // Act
            shape.RemoveRowTop();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(45, numberOfBlocks);

            var expectedRowIsRed = shape.GetRow(9).All(b => b.Color == Color.Red);
            Assert.IsTrue(expectedRowIsRed);
            Assert.AreEqual(9, shape.LastRow());
        }

        /// <summary>
        /// Tests the AddRow extention method
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsRemoveRowBottom()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeRowRed(shape, 9);

            // Act
            shape.RemoveRowBottom();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(45, numberOfBlocks);

            var expectedRowIsRed = shape.GetRow(9).All(b => b.Color == Color.Red);
            Assert.IsTrue(expectedRowIsRed);
            Assert.AreEqual(9, shape.LastRow());
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsAddColumnLeft()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeColumnRed(shape, 5);

            // Act
            shape.AddColumnLeft();

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

            var expectedColumnIsRed = shape.GetColumn(6).All(b => b.Color == Color.Red);
            Assert.IsTrue(expectedColumnIsRed);
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsAddColumnRight()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeColumnRed(shape, 5);

            // Act
            shape.AddColumnRight();

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

            var expectedColumnIsRed = shape.GetColumn(5).All(b => b.Color == Color.Red);
            Assert.IsTrue(expectedColumnIsRed);
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsRemoveColumnLeft()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeColumnRed(shape, 5);

            // Act
            shape.RemoveColumnLeft();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(40, numberOfBlocks);

            var expectedColumnIsRed = shape.GetColumn(4).All(b => b.Color == Color.Red);
            Assert.IsTrue(expectedColumnIsRed);
            Assert.AreEqual(4, shape.LastColumn());
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsRemoveColumnRight()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeColumnRed(shape, 4);

            // Act
            shape.RemoveColumnRight();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(40, numberOfBlocks);

            var expectedColumnIsRed = shape.GetColumn(4).All(b => b.Color == Color.Red);
            Assert.IsTrue(expectedColumnIsRed);
            Assert.AreEqual(4, shape.LastColumn());
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsCropImage()
        {
            // Arrange
            const int columns = 6;
            const int rows = 6;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.Where(b => b.Row > 3 && b.Column > 3).ToList().ForEach(b => b.Color = Color.Red);

            // Act
            shape.CropImage();

            // Assert
            var numberOfRedBlocks = shape.Blocks.Count(b => b.Color == Color.Red);
            Assert.AreEqual(9, numberOfRedBlocks);
            Assert.AreEqual(9, shape.Blocks.Count());
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsCropImageWithInnerBlackSpace()
        {
            // Arrange
            const int columns = 6;
            const int rows = 6;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            // Create a red square
            shape.Blocks.Where(b => b.Row > 3 && b.Column > 3).ToList().ForEach(b => b.Color = Color.Red);

            // Create black line, this means there's two red lines split by a black line.
            shape.Blocks.Where(b => b.Row == 5 && b.Column > 3).ToList().ForEach(b => b.Color = Color.Black);

            // Act
            shape.CropImage();

            // Assert
            var numberOfRedBlocks = shape.Blocks.Count(b => b.Color == Color.Red);
            Assert.AreEqual(6, numberOfRedBlocks);
            Assert.AreEqual(9, shape.Blocks.Count());
        }

        /// <summary>
        /// move up test.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsMoveUp()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.ForEach((b) =>
            {
                if (b.Row == 2)
                {
                    b.Color = Color.Red;
                }
            });

            // Act
            shape.MoveUp();

            // Assert
            var firstRowIsRed = shape.GetRow(1).All(b => b.Color == Color.Red);
            Assert.IsTrue(firstRowIsRed);
        }

        /// <summary>
        /// move down test.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsMoveDown()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.ForEach((b) =>
            {
                if (b.Row == 2)
                {
                    b.Color = Color.Red;
                }
            });

            // Act
            shape.MoveDown();

            // Assert
            var thirdRowIsRed = shape.GetRow(3).All(b => b.Color == Color.Red);
            Assert.IsTrue(thirdRowIsRed);
        }

        /// <summary>
        /// move down test.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsMoveRight()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.ForEach((b) =>
            {
                if (b.Column == 2)
                {
                    b.Color = Color.Red;
                }
            });

            // Act
            shape.MoveRight();

            // Assert
            var isRed = shape.GetColumn(3).All(b => b.Color == Color.Red);
            Assert.IsTrue(isRed);
        }

        /// <summary>
        /// move left test.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsMoveLeft()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.ForEach((b) =>
            {
                if (b.Column == 2)
                {
                    b.Color = Color.Red;
                }
            });

            // Act
            shape.MoveLeft();

            // Assert
            var isRed = shape.GetColumn(1).All(b => b.Color == Color.Red);
            Assert.IsTrue(isRed);
        }

        /// <summary>
        /// Tests if the anchor is removed from a block.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsSetAnchors()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.GetBlock(4, 4).Anchor = true;
            shape.ResetAnchor();

            // Act
            shape.SetAnchor(5, 5);

            // Assert.
            Assert.IsFalse(shape.GetBlock(4, 4).Anchor);
            Assert.IsTrue(shape.GetBlock(5, 5).Anchor);
        }

        /// <summary>
        /// Tests if the anchor is removed from a block.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsRetrieveAcnhor()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);
            shape.SetAnchor(5, 6);

            // Act
            var block = shape.GetAnchorBlock();

            // Assert.
            Assert.AreEqual(block.Column, 5);
            Assert.AreEqual(block.Row, 6);
        }

        /// <summary>
        /// Tests if the anchor is removed from a block.
        /// </summary>
        [TestMethod]
        public void ShapeModelExtentionsRemoveAnchors()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.GetBlock(5, 5).Anchor = true;

            // Act
            shape.ResetAnchor();

            // Assert.
            Assert.IsFalse(shape.GetBlock(5, 5).Anchor);
        }

        /// <summary>
        /// Makes the column red.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="column">The column.</param>
        private void MakeColumnRed(ShapeModel shapeModel, int column)
        {
            shapeModel.Blocks.Where(b => b.Column == column).ToList().ForEach(b => b.Color = Color.Red);
        }

        /// <summary>
        /// Makes the row red.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="row">The row.</param>
        private void MakeRowRed(ShapeModel shapeModel, int row)
        {
            shapeModel.Blocks.Where(b => b.Row == row).ToList().ForEach(b => b.Color = Color.Red);
        }
    }
}
