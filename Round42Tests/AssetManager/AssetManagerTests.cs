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
    using Round42.Models.Extentions;

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
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

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
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

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
            // Act
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
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
            this.DeleteAssetFile();
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
        }

        /// <summary>
        /// Assets the manager on new test event.
        /// </summary>
        [TestMethod]
        public void AssetManagerOnNewTest()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Act
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            assetManager.OnNewAsset += (IEnumerable<AssetModel> assets, AssetModel assetModel) =>
            {
                Assert.IsNotNull(assetModel);
                Assert.AreEqual("Test", assetModel.Name);
            };
        }

        /// <summary>
        /// Tests saving and loading.
        /// </summary>
        [TestMethod]
        public void AssetManagerSaveAndLoad()
        {
            // Arrange
            this.DeleteAssetFile();
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
        }

        /// <summary>
        /// Tests adding a shape
        /// </summary>
        [TestMethod]
        public void AssetManagerAddShape()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);

            assetManager.AddShapeToAsset("Test");

            assetManager.OnAssetsLoaded += (IEnumerable<AssetModel> assets) =>
            {
                // Assert
                Assert.AreEqual(11, assets.First().Shapes.Count());

                var addedShape = assets.First().Shapes.Last();
                Assert.AreEqual(15, addedShape.LastColumn());
                Assert.AreEqual(2, addedShape.LastRow());
            };

            // Act
            assetManager.AddShapeToAsset();
        }

        /// <summary>
        /// Tests removing a shape.
        /// </summary>
        [TestMethod]
        public void AssetManagerRemoveShape()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);
            assetManager.LoadByName("Test");

            assetManager.OnCurrentAssetChanged += (AssetModel asset) =>
            {
                // Assert
                Assert.AreEqual(9, asset.Shapes.Count());
            };

            // Act
            assetManager.RemoveShapeFromAsset(0);
        }

        /// <summary>
        /// Tests the add column.
        /// </summary>
        [TestMethod]
        public void AssetManagerAddColumnLeft()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);
            assetManager.LoadByName("Test");
            assetManager.OnCurrentAssetChanged += (AssetModel asset) =>
            {
                // Assert
                Assert.AreEqual(16, asset.Columns);
            };

            // Act
            assetManager.AddColumnLeft();
        }

        /// <summary>
        /// Tests the add column.
        /// </summary>
        [TestMethod]
        public void AssetManagerRemoveLastColumn()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);
            assetManager.LoadByName("Test");

            assetManager.OnCurrentAssetChanged += (AssetModel asset) =>
            {
                Assert.AreEqual(14, asset.Columns);
                Assert.AreEqual(14, asset.Shapes.First().Blocks.Count(b => b.Row == 1));
            };

            assetManager.RemoveColumnLeft();
        }

        /// <summary>
        /// Tests the add column.
        /// </summary>
        [TestMethod]
        public void AssetManagerRemoveLastRow()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", AssetTypes.Enemy, 10, 15, 2);
            assetManager.LoadByName("Test");

            assetManager.OnCurrentAssetChanged += (AssetModel asset) =>
            {
                Assert.AreEqual(1, asset.Rows);
                Assert.AreEqual(1, asset.Shapes.First().Blocks.Count(b => b.Column == 1));
            };

            assetManager.RemoveRowBottom();
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