// <copyright file="AssetManager.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Managers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Exceptions;
    using Extentions;
    using Providers;
    using Round42.Models;
    using Round42.Models.Extentions;
    using Round42.Models.Models;

    /// <summary>
    /// Manages assets
    /// </summary>
    public class AssetManager
    {
        /// <summary>
        /// The asset provider
        /// </summary>
        private readonly AssetProvider assetProvider;

        /// <summary>
        /// The shape provider
        /// </summary>
        private readonly ShapeProvider shapeProvider;

        /// <summary>
        /// The asset file
        /// </summary>
        private string assetFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager" /> class.
        /// </summary>
        /// <param name="assetProvider">The asset provider.</param>
        /// <param name="shapeProvider">The shape provider.</param>
        public AssetManager(
            AssetProvider assetProvider,
            ShapeProvider shapeProvider)
        {
            this.assetProvider = assetProvider;
            this.shapeProvider = shapeProvider;
            this.assetFile = Path.Combine(Directory.GetCurrentDirectory(), "Assets.json");

            this.SetupAssets();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager"/> class.
        /// </summary>
        /// <exception cref="System.Exception">Not implemented</exception>
        public AssetManager()
        {
            throw new System.Exception("Not implemented");
        }

        /// <summary>
        /// Gets the current asset.
        /// </summary>
        /// <value>
        /// The current asset.
        /// </value>
        public AssetModel CurrentAsset { get; private set; }

        /// <summary>
        /// Gets the current frame.
        /// </summary>
        /// <value>
        /// The current frame.
        /// </value>
        public ShapeModel CurrentFrame { get; private set; }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        private List<AssetModel> Assets { get; set; }

        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <returns>
        ///   <see cref="IEnumerable{AssetModel}" />
        /// </returns>
        public IEnumerable<AssetModel> GetAssets()
        {
            return this.Assets.AsEnumerable();
        }

        /// <summary>
        /// Gets the frame.
        /// </summary>
        /// <param name="index">The frame.</param>
        public void LoadFrameByIndex(int index)
        {
            this.CurrentFrame = this.CurrentAsset.Shapes[index];
        }

        /// <summary>
        /// Adds the specified width.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="assetType">Type of the asset.</param>
        /// <param name="frames">The number of shapes.</param>
        /// <param name="columns">The width.</param>
        /// <param name="rows">The height.</param>
        /// <exception cref="DuplicateEntryException">Asset {0} already exists".FormatString(assetName)</exception>
        public void Add(string assetName, AssetTypes assetType, int frames, int columns, int rows)
        {
            if (this.Assets.Any(a => a.Name == assetName))
            {
                throw new DuplicateEntryException("Asset {0} already exists".FormatString(assetName));
            }

            var newAsset = this.assetProvider.Create(assetName, assetType, frames, columns, rows);
            this.Add(newAsset);
            this.Save();
        }

        /// <summary>
        /// Adds the shape.
        /// </summary>
        public void AddShapeToAsset()
        {
            var newShape = this.shapeProvider.Create(this.CurrentAsset.Shapes.First().LastColumn(), this.CurrentAsset.Shapes.First().LastRow());
            this.CurrentAsset.Shapes.Add(newShape);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this.Assets);
            json.SaveToFile(this.assetFile);
        }

        /// <summary>
        /// Adds the specified new asset.
        /// </summary>
        /// <param name="newAsset">The new asset.</param>
        public void Add(AssetModel newAsset)
        {
            this.Assets.Add(newAsset);
        }

        /// <summary>
        /// Removes this instance.
        /// </summary>
        public void Remove()
        {
            if (this.CurrentAsset != null)
            {
                this.Assets.Remove(this.CurrentAsset);
            }
        }

        /// <summary>
        /// Removes the specified current asset.
        /// </summary>
        /// <param name="shapeIndex">Index of the shape.</param>
        public void RemoveShapeFromAsset(int shapeIndex)
        {
            if (this.CurrentAsset.Shapes.Count() > 1)
            {
                this.CurrentAsset.Shapes.RemoveAt(shapeIndex);
                
            }
        }

        /// <summary>
        /// Adds the shape to asset.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void AddShapeToAsset(string assetName)
        {
            this.SetByName(assetName);
            this.AddShapeToAsset();
        }

        /// <summary>
        /// Adds the column left.
        /// </summary>
        public void AddColumnLeft()
        {
            this.CurrentFrame.AddColumnLeft();
            
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        public void AddColumnRight()
        {
            this.CurrentFrame.AddColumnRight();
        }

        /// <summary>
        /// Adds the row top.
        /// </summary>
        public void AddRowTop()
        {
            this.CurrentFrame.AddRowTop();
        }

        /// <summary>
        /// Adds the row.
        /// </summary>
        public void AddRowBottom()
        {
            this.CurrentFrame.AddRowBottom();
        }

        /// <summary>
        /// Removes the row top.
        /// </summary>
        public void RemoveRowTop()
        {
            if (this.CurrentFrame.LastRow() > 1)
            {
                this.CurrentFrame.RemoveRowTop();
            }

            
        }

        /// <summary>
        /// Removes the last row.
        /// </summary>
        public void RemoveRowBottom()
        {
            if (this.CurrentFrame.LastRow() > 1)
            {
                this.CurrentFrame.RemoveRowBottom();
            }

            
        }

        /// <summary>
        /// Removes the last column.
        /// </summary>
        public void RemoveColumnLeft()
        {
            if (this.CurrentFrame.LastColumn() > 1)
            {
                this.CurrentFrame.RemoveColumnLeft();
            }

            
        }

        /// <summary>
        /// Removes the column right.
        /// </summary>
        public void RemoveColumnRight()
        {
            if (this.CurrentFrame.LastColumn() > 1)
            {
                this.CurrentFrame.RemoveColumnRight();
            }

            
        }

        /// <summary>
        /// Crops the images for the shapes in the current asset.
        /// </summary>
        public void CropAndAlignAnchors()
        {
            if (this.CurrentAsset != null)
            {
                foreach (var shape in this.CurrentAsset.Shapes)
                {
                    if (shape.Blocks.All(b => b.Color.R == 0 && b.Color.G == 0 && b.Color.B == 0) == false)
                    {
                        shape.CropImage();
                    }
                }

                var anchorBlocks = this.CurrentAsset.Shapes.SelectMany(s => s.Blocks).Where(b => b.Anchor);
                var maxColumn = anchorBlocks.Max(b => b.Column);
                var maxRow = anchorBlocks.Max(b => b.Row);
                this.AlignAnchors(maxColumn, maxRow);

                // Make images same size
                maxColumn = this.CurrentAsset.Shapes.Max(s => s.LastColumn());
                maxRow = this.CurrentAsset.Shapes.Max(s => s.LastRow());
                this.MakeShapesSameSize(maxColumn, maxRow);
            }
        }

        /// <summary>
        /// Loads the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void LoadByName(string assetName)
        {
            this.SetByName(assetName);
            
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void LoadAssets()
        {
            this.SetupAssets();
        }

        /// <summary>
        /// Move blocks in frame to the left.
        /// </summary>
        public void MoveLeft()
        {
            this.CurrentFrame.MoveLeft();
            
        }

        /// <summary>
        /// Move blocks in frame up
        /// </summary>
        public void MoveUp()
        {
            this.CurrentFrame.MoveUp();
            
        }

        /// <summary>
        /// Move blocks in frame right.
        /// </summary>
        public void MoveRight()
        {
            this.CurrentFrame.MoveRight();
            
        }

        /// <summary>
        /// Move blocks in frame down.
        /// </summary>
        public void MoveDown()
        {
            this.CurrentFrame.MoveDown();
            
        }

        /// <summary>
        /// Sets the bitmap for the asset named in the AssetBitmapModel
        /// </summary>
        /// <param name="assetBitmapModel">The asset bitmap model.</param>
        public void SetBitmap(AssetBitmapModel assetBitmapModel)
        {
            var asset = this.Assets.Where(a => a.Name == assetBitmapModel.Name).Single();
            asset.Bitmaps = assetBitmapModel.Bitmaps;
        }

        /// <summary>
        /// Sets the bitmaps for all the Assets in the list.
        /// </summary>
        /// <param name="assetBitmapModels">The asset bitmap models.</param>
        public void SetBitmaps(IEnumerable<AssetBitmapModel> assetBitmapModels)
        {
            foreach (var assetBitmapModel in assetBitmapModels)
            {
                this.SetBitmap(assetBitmapModel);
            }
        }

        /// <summary>
        /// Sets up assets. If there are none, we'll create a new list we can add too.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        private void SetupAssets()
        {
            if (File.Exists(this.assetFile))
            {
                var fileContent = File.ReadAllText(this.assetFile);
                this.Assets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AssetModel>>(fileContent);
            }
            else
            {
                this.Assets = new List<AssetModel>();
            }
        }

        /// <summary>
        /// Loads the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        private void SetByName(string assetName)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                return;
            }

            var asset = this.Assets.Single(a => a.Name == assetName);
            this.CurrentAsset = asset;
            this.CurrentFrame = asset.Shapes.First();
        }

        /// <summary>
        /// Makes the size of the shapes same.
        /// </summary>
        /// <param name="maxColumn">The maximum column.</param>
        /// <param name="maxRow">The maximum row.</param>
        private void MakeShapesSameSize(int maxColumn, int maxRow)
        {
            foreach (var shape in this.CurrentAsset.Shapes)
            {
                var colDiff = maxColumn - shape.LastColumn();
                var rowDiff = maxRow - shape.LastRow();

                for (int col = 0; col < colDiff; col++)
                {
                    shape.AddColumnRight();
                }

                for (int row = 0; row < rowDiff; row++)
                {
                    shape.AddRowBottom();
                }
            }
        }

        /// <summary>
        /// Aligns the anchors.
        /// </summary>
        /// <param name="maxColumn">The maximum column.</param>
        /// <param name="maxRow">The maximum row.</param>
        private void AlignAnchors(int maxColumn, int maxRow)
        {
            foreach (var shape in this.CurrentAsset.Shapes)
            {
                var anchorBlock = shape.GetAnchorBlock();
                if (anchorBlock != null)
                {
                    var colDiff = maxColumn - anchorBlock.Column;
                    var rowDiff = maxRow - anchorBlock.Row;

                    for (int col = 0; col < colDiff; col++)
                    {
                        shape.AddColumnLeft();
                    }

                    for (int row = 0; row < rowDiff; row++)
                    {
                        shape.AddRowTop();
                    }
                }
            }
        }
    }
}
