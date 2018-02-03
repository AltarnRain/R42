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
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Assert
            Assert.IsNotNull(assetManager);
            this.DeleteAssetFile();
        }

        /// <summary>
        /// Assets the manager add.
        /// </summary>
        [TestMethod]
        public void AssetManagerAdd()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            // Assert
            var asset = assetManager.Assets.SingleOrDefault(a => a.Name == "Test");
            Assert.IsNotNull(asset);

            this.DeleteAssetFile();
        }

        /// <summary>
        /// Duplicate assets are not allowed
        /// </summary>
        [TestMethod]
        public void AssetManagerAddDuplicate()
        {
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

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

            this.DeleteAssetFile();
        }

        /// <summary>
        /// Check if exception is only thrown when duplicates are added not multiple assets
        /// </summary>
        [TestMethod]
        public void AssetManagerAddTwoAssets()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

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

            this.DeleteAssetFile();
        }

        /// <summary>
        /// Assets the manager on new test event.
        /// </summary>
        [TestMethod]
        public void AssetManagerOnNewTest()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            assetManager.OnNewAsset += (AssetModel assetModel) =>
            {
                Assert.IsNotNull(assetModel);
                Assert.AreEqual("Test", assetModel.Name);
            };

            this.DeleteAssetFile();
        }

        /// <summary>
        /// Fixates the new event comes after the change event.
        /// </summary>
        [TestMethod]
        public void AssetManagerOnNewAfterChangeTest()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
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

            this.DeleteAssetFile();
        }

        /// <summary>
        /// Assets the manager add.
        /// </summary>
        [TestMethod]
        public void AssetManagerOnAssetChanged()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            assetManager.OnAssetsChanged += (IEnumerable<AssetModel> assetModels) =>
            {
                Assert.IsNotNull(assetModels);
                Assert.IsTrue(assetModels.Any(a => a.Name == "Test"));
            };

            this.DeleteAssetFile();
        }

        /// <summary>
        /// Assets the manager find by name test.
        /// </summary>
        [TestMethod]
        public void AssetManagerFindByNameTest()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            // Act
            var asset = assetManager.FindByName("Test");

            // Assert
            Assert.AreEqual("Test", asset.Name);

            this.DeleteAssetFile();
        }

        /// <summary>
        /// Assets the manager save.
        /// </summary>
        [TestMethod]
        public void AssetManagerSaveAndLoad()
        {
            // Arrange
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            // Act
            assetManager.Save();

            // Assert
            Assert.IsTrue(File.Exists(this.GetAssetFile()));

            // Act
            var assetManager2 = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Assert
            Assert.AreEqual(1, assetManager2.Assets.Count());
            Assert.AreEqual(10, assetManager2.Assets.First().Shapes.Count());
            Assert.AreEqual(30, assetManager2.Assets.First().Shapes.First().Blocks.Count());

            this.DeleteAssetFile();
        }

        /// <summary>
        /// Gets the asset file.
        /// </summary>
        /// <returns>A string with a temporary asset file</returns>
        private string GetAssetFile()
        {
            // Arrange
            return this.GetOutFolder() + "Assets.json";
        }

        private void DeleteAssetFile()
        {
            File.Delete(this.GetAssetFile());
        }
    }
}