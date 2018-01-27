// <copyright file="AssetManagerTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Models;

    /// <summary>
    /// Tests for the asset manager
    /// </summary>
    [TestClass]
    public class AssetManagerTests
    {
        /// <summary>
        /// Assets the manager create test.
        /// </summary>
        [TestMethod]
        public void AssetManagerCreateTest()
        {
            // Arrange / Act
            var assetManager = AssetManager.Create();

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
            var assetManager = AssetManager.Create();

            // Act
            assetManager.Add(10, 15, 2, "Test", Models.AssetTypes.Enemy);

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
            var assetManager = AssetManager.Create();

            // Act
            assetManager.Add(10, 15, 2, "Test", Models.AssetTypes.Enemy);

            try
            {
                assetManager.Add(10, 15, 2, "Test", Models.AssetTypes.Enemy);
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
            var assetManager = AssetManager.Create();

            // Act
            try
            {
                assetManager.Add(10, 15, 2, "Test", Models.AssetTypes.Enemy);
                assetManager.Add(10, 15, 2, "Test2", Models.AssetTypes.Enemy);
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
            var assetManager = AssetManager.Create();

            // Act
            assetManager.Add(10, 15, 2, "Test", Models.AssetTypes.Enemy);

            assetManager.OnNewAsset += (AssetModel assetModel) =>
            {
                Assert.IsNotNull(assetModel);
                Assert.AreEqual("Test", assetModel.Name);
            };
        }

        /// <summary>
        /// Assets the manager add.
        /// </summary>
        [TestMethod]
        public void AssetManagerOnAssetChanged()
        {
            // Arrange
            var assetManager = AssetManager.Create();

            // Act
            assetManager.Add(10, 15, 2, "Test", Models.AssetTypes.Enemy);

            assetManager.OnAssetsChanged += (List<AssetModel> assetModels) =>
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
            var assetManager = AssetManager.Create();
            assetManager.Add(10, 15, 2, "Test", Models.AssetTypes.Enemy);

            // Act
            var asset = assetManager.FindByName("Test");

            // Assert
            Assert.AreEqual("Test", asset.Name);
        }
    }
}