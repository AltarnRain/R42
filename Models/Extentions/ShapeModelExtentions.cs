// <copyright file="ShapeModelExtentions.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models.Extentions
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    /// <summary>
    /// Extention class
    /// </summary>
    public static partial class Extentions
    {
        /// <summary>
        /// Returns the last index
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>1 based index</returns>
        public static int LastColumn(this ShapeModel shapeModel)
        {
            return shapeModel.Blocks.Max(b => b.Column);
        }

        /// <summary>
        /// Returns the last row index.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>1 based index</returns>
        public static int LastRow(this ShapeModel shapeModel)
        {
            return shapeModel.Blocks.Max(b => b.Row);
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="row">The row.</param>
        /// <returns>Specified row</returns>
        public static IEnumerable<BlockModel> GetRow(this ShapeModel shapeModel, int row)
        {
            return shapeModel.Blocks.Where(b => b.Row == row);
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="column">The column.</param>
        /// <returns>Specified column</returns>
        public static IEnumerable<BlockModel> GetColumn(this ShapeModel shapeModel, int column)
        {
            return shapeModel.Blocks.Where(b => b.Column == column);
        }

        /// <summary>
        /// Adds the row.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void AddRow(this ShapeModel shapeModel)
        {
            var maxRow = shapeModel.LastRow();
            var maxColumns = shapeModel.LastColumn();

            var newRow = maxRow + 1;

            for (var col = 0; col < maxColumns; col++)
            {
                var newBlock = BlockModel.Create(col + 1, newRow);
                shapeModel.Blocks.Add(newBlock);
            }
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void AddColumn(this ShapeModel shapeModel)
        {
            var maxRow = shapeModel.LastRow();
            var maxColumns = shapeModel.LastColumn();

            var newColumn = maxColumns + 1;

            for (var row = 0; row < maxRow; row++)
            {
                var newBlock = BlockModel.Create(newColumn, row + 1);
                shapeModel.Blocks.Add(newBlock);
            }
        }

        /// <summary>
        /// Removes the last column.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void RemoveLastColumn(this ShapeModel shapeModel)
        {
            shapeModel.Blocks.RemoveAll(b => b.Column == shapeModel.LastColumn());
        }

        /// <summary>
        /// Removes the last row.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void RemoveLastRow(this ShapeModel shapeModel)
        {
            shapeModel.Blocks.RemoveAll(b => b.Row == shapeModel.LastRow());
        }

        /// <summary>
        /// Gets the block.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <returns>Returns a BlockModel</returns>
        public static BlockModel GetBlock(this ShapeModel shapeModel, int column, int row)
        {
            return shapeModel.Blocks.Single(b => b.Column == column && b.Row == row);
        }
    }
}
