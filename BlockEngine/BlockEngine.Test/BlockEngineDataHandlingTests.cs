// <copyright file="BlockEngineDataHandlingTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Test
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using BlockEngine.DataHandling.ModelHandlers;
    using BlockEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the block engine
    /// </summary>
    [TestClass]
    public class BlockEngineDataHandlingTests
    {
        /// <summary>
        /// Tests the Animation model provider
        /// </summary>
        [TestMethod]
        public void TestAnimationModelProvider()
        {
            // Arrange
            var model = GenerateAnimationmodel();
            var block1 = model.Shapes.First().Blocks[0];
            var block2 = model.Shapes.First().Blocks[1];

            var animationModelHandler = AnimationModelHandler.Create();

            // Act
            var xmlString = animationModelHandler.GenerateXml(model);
            var generatedModel = animationModelHandler.GetModel(xmlString);

            Assert.IsNotNull(generatedModel);

            var generatedBlock1 = generatedModel.Shapes.First().Blocks[0];
            var generatedBlock2 = generatedModel.Shapes.First().Blocks[1];

            Assert.AreEqual(block1.X, generatedBlock1.X);
            Assert.AreEqual(block1.Y, generatedBlock1.Y);
            Assert.AreEqual(block1.Color, generatedBlock1.Color);
            Assert.AreEqual(block1.ColorName, generatedBlock1.ColorName);

            Assert.AreEqual(block2.X, generatedBlock2.X);
            Assert.AreEqual(block2.Y, generatedBlock2.Y);
            Assert.AreEqual(block2.Color, generatedBlock2.Color);
            Assert.AreEqual(block2.ColorName, generatedBlock2.ColorName);
        }

        /// <summary>
        /// Generates am animationmodel.
        /// </summary>
        /// <returns>AnimationModel</returns>
        private static AnimationModel GenerateAnimationmodel()
        {
            // Arrange
            return new AnimationModel
            {
                Shapes = new List<ShapeModel>
                {
                    new ShapeModel
                    {
                        Blocks = new List<BlockModel>
                        {
                            new BlockModel
                            {
                                ColorName = Constants.ColorNames.Red,
                                Color = Color.Red,
                                X = 1,
                                Y = 1,
                            },
                            new BlockModel
                            {
                                ColorName = Constants.ColorNames.Blue,
                                Color = Color.Blue,
                                X = 1,
                                Y = 2,
                            }
                        }
                    }
                }
            };
        }
    }
}
