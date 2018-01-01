// <copyright file="BlockEngineDataHandlingTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Test
{
    using System;
    using System.Collections.Generic;
    using BlockEngine.DataHandling.Providers;
    using BlockEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the block engine
    /// </summary>
    [TestClass]
    public class BlockEngineDataHandlingTests
    {
        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        public void GetModelXml()
        {
            // Arrange
            var model = GenerateAnimationmodel();
            var modelHandler = ModelHandler.Create();

            // Act
            var xmlString = modelHandler.GenerateXml<AnimationModel>(model);
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
                                Color = System.Drawing.Color.Red,
                                X = 1,
                                Y = 1,
                            },
                            new BlockModel
                            {
                                Color = System.Drawing.Color.Blue,
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
