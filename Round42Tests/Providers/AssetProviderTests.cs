// <copyright file="AssetProviderTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Models;
    using Round42.Providers;

    /// <summary>
    /// Tests creating the asset model
    /// </summary>
    [TestClass]
    public class AssetProviderTests : TestBase
    {
        /// <summary>
        /// Assets the model create test.
        /// </summary>
        [TestMethod]
        public void CreateTest()
        {
            var model = this.Get<AssetProvider>().Create("PlayerShip", AssetTypes.Player, 3, 5, 6);

            Assert.AreEqual(5 * 6, model.Shapes.First().Blocks.Count());
            Assert.AreEqual(3, model.Shapes.Count());
            Assert.AreEqual("PlayerShip", model.Name);
            Assert.AreEqual(AssetTypes.Player, model.AssetType);
        }
    }
}
