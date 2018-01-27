// <copyright file="AssetModelTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Test.Creators
{
    using System.Linq;
    using BlockEngine.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests creating the asset model
    /// </summary>
    [TestClass]
    public class AssetModelTests
    {
        /// <summary>
        /// Assets the model create test.
        /// </summary>
        [TestMethod]
        public void AssetModelCreateTest()
        {
            var model = AssetModel.Create(5, 6, 3, "PlayerShip", AssetTypes.Player, string.Empty);

            Assert.AreEqual(5 * 6, model.AnimationModel.Shapes.First().Blocks.Count());
            Assert.AreEqual(3, model.AnimationModel.Shapes.Count());
            Assert.AreEqual("PlayerShip", model.Name);
            Assert.AreEqual(AssetTypes.Player, model.AssetType);
        }
    }
}
