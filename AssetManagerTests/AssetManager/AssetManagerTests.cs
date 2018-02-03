// <copyright file="AssetManagerTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Factories;
    using Round42.Models;

    /// <summary>
    /// Tests for the asset manager
    /// </summary>
    [TestClass]
    public class AssetManagerTests : TestBase
    {
        /// <summary>
        /// Assets the manager create test.
        /// </summary>
        [TestMethod]
        public void AssetManagerCreateTest()
        {
            // Arrange / Act
            var assetManager = this.Get<AssetManagerFactory>().Get(string.Empty);

            // Assert
            Assert.IsNotNull(assetManager);
        }

        /// <summary>
        /// Assets the manager add.
        /// </summary>
        [TestMethod]
        public void AssetManagerAdd()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(string.Empty);

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            // Assert
            var asset = assetManager.Assets.SingleOrDefault(a => a.Name == "Test");
            Assert.IsNotNull(asset);
        }

        /// <summary>
        /// Duplicate assets are not allowed
        /// </summary>
        [TestMethod]
        public void AssetManagerAddDuplicate()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(string.Empty);

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            try
            {
                assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);
            }
            catch (DuplicateEntryException ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }

        /// <summary>
        /// Check if exception is only thrown when duplicates are added not multiple assets
        /// </summary>
        [TestMethod]
        public void AssetManagerAddTwoAssets()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(string.Empty);

            // Act
            try
            {
                assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);
                assetManager.Add("Test2", AssetTypes.Enemy, 10, 15, 2);
            }
            catch (DuplicateEntryException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Assets the manager on new test event.
        /// </summary>
        [TestMethod]
        public void AssetManagerOnNewTest()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(string.Empty);

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            assetManager.OnNewAsset += (AssetModel assetModel) =>
            {
                Assert.IsNotNull(assetModel);
                Assert.AreEqual("Test", assetModel.Name);
            };
        }

        /// <summary>
        /// Fixates the new event comes after the change event.
        /// </summary>
        [TestMethod]
        public void AssetManagerOnNewAfterChangeTest()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(string.Empty);
            var changeEventTriggered = false;

            assetManager.OnAssetsChanged += (IEnumerable<AssetModel> assetModels) =>
            {
                changeEventTriggered = true;
            };

            assetManager.OnNewAsset += (AssetModel assetModel) =>
            {
                Assert.IsTrue(changeEventTriggered);
            };

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);
        }

        /// <summary>
        /// Assets the manager add.
        /// </summary>
        [TestMethod]
        public void AssetManagerOnAssetChanged()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(string.Empty);

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            assetManager.OnAssetsChanged += (IEnumerable<AssetModel> assetModels) =>
            {
                Assert.IsNotNull(assetModels);
                Assert.IsTrue(assetModels.Any(a => a.Name == "Test"));
            };
        }

        /// <summary>
        /// Assets the manager find by name test.
        /// </summary>
        [TestMethod]
        public void AssetManagerFindByNameTest()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(string.Empty);
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            // Act
            var asset = assetManager.FindByName("Test");

            // Assert
            Assert.AreEqual("Test", asset.Name);
        }

        /// <summary>
        /// Assets the manager save.
        /// </summary>
        [TestMethod]
        public void AssetManagerSaveAndLoad()
        {
            // Arrange
            var assetFile = this.GetOutFolder() + "Assets.json";
            var assetManager = this.Get<AssetManagerFactory>().Get(assetFile);
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            // Act
            assetManager.Save();

            // Assert
            Assert.IsTrue(File.Exists(assetFile));

            // Act
            var assetManager2 = this.Get<AssetManagerFactory>().Get(assetFile);

            // Assert
            Assert.AreEqual(1, assetManager2.Assets.Count());
            Assert.AreEqual(10, assetManager2.Assets.First().Shapes.Count());
            Assert.AreEqual(30, assetManager2.Assets.First().Shapes.First().Blocks.Count());
        }

        /// <summary>
        /// Assets the manager get asset list.
        /// </summary>
        [TestMethod]
        public void AssetManagerGetAssetList()
        {
        }
    }
}