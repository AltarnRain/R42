using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round42.Models.Extentions
{
    public static partial class Extentions
    {
        /// <summary>
        /// Adds the row.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public static void AddRow(this ShapeModel shapeModel)
        {
            var maxRow = shapeModel.Blocks.Max(b => b.X);
            var columns = shapeModel.Blocks.Max(b => b.Y);

            var newRow = maxRow + 1;

            for (var col = 0; col < columns; col++)
            {
                var newBlock = new BlockModel
                {
                    Color = Color.Black,
                    X = newRow,
                    Y = col + 1
                };

                shapeModel.Blocks.Add(newBlock);
            }
        }
    }
}
