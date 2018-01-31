// <copyright file="AssetModelTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Test.Creators
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Models;

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
            var model = AssetModel.Create(5, 6, 3, "PlayerShip", AssetTypes.Player);

            Assert.AreEqual(5 * 6, model.Animation.Shapes.First().Blocks.Count());
            Assert.AreEqual(3, model.Animation.Shapes.Count());
            Assert.AreEqual("PlayerShip", model.Name);
            Assert.AreEqual(AssetTypes.Player, model.AssetType);
        }
    }
}
