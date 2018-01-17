// <copyright file="AnimationModelTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Test.Creators
{
    using System.Linq;
    using BlockEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests animation model methods
    /// </summary>
    [TestClass]
    public class AnimationModelTests
    {
        /// <summary>
        /// Animations the model creation test.
        /// </summary>
        [TestMethod]
        public void AnimationModelCreationTest()
        {
            // Arrange
            var model = AnimationModel.Create(5, 19, 5);

            // Assert
            Assert.AreEqual(5, model.Shapes.Count());
        }

        /// <summary>
        /// Animations the model creation test.
        /// </summary>
        [TestMethod]
        public void AnimationModelGetTest()
        {
            // Arrange
            var model = AnimationModel.Create(5, 19, 5);

            var animationModel = model.Get(4);

            // Assert
            Assert.IsNotNull(animationModel);
        }
    }
}
