using AssetEditor2.Properties;
using Round42.AssetEditor.Forms;
using Round42.CustomComponents;
using Round42.Factories;
using Round42.Factories.Factories;
using Round42.Managers;
using Round42.Models;
using Round42.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssetEditor2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The asset file
        /// </summary>
        private const string AssetFile = "Assets.json";
        private readonly AssetManagerFactory assetManagerFactory;
        private readonly AssetProvider assetProvider;
        private readonly ViewFactory viewFactory;
        private readonly DrawerFactory drawerFactory;
        private readonly PaletFactory paletFactory;
        private readonly RenderFactory renderFactory;

        Palet palet;
        AssetManager assetManager;
        Drawer drawer;

        public MainWindow(AssetManagerFactory assetManagerFactory,
            AssetProvider assetProvider,
            ViewFactory viewFactory,
            DrawerFactory drawerFactory,
            PaletFactory paletFactory,
            RenderFactory renderFactory)

        {
            InitializeComponent();
            this.assetManagerFactory = assetManagerFactory;
            this.assetProvider = assetProvider;
            this.viewFactory = viewFactory;
            this.drawerFactory = drawerFactory;
            this.paletFactory = paletFactory;
            this.renderFactory = renderFactory;

            var mainAssetFile = System.IO.Path.Combine(Directory.GetCurrentDirectory(), AssetFile);
            this.assetManager = assetManagerFactory.Get(mainAssetFile, false);

            this.palet = this.paletFactory.Get(this.Palet);
            this.drawer = this.drawerFactory.Get(this.DrawerGrid);

            this.ZoomLevel.Value = Settings.Default.ZoomLevel;

            // Event handler setup must precede loading assets but happen after the asset manager is created
            this.SetupEventHandlers();

            // Load assets and trigger events.
            this.assetManager.LoadAssets();
        }

        private void SetupEventHandlers()
        {
            this.assetManager.OnNewAsset += (IEnumerable<AssetModel> assets, AssetModel asset) =>
            {
                this.UpdateAssetList(assets);
                this.AssetsList.SelectedIndex = this.AssetsList.Items.IndexOf(asset.Name);    
            };

            this.assetManager.OnAssetsLoaded += (IEnumerable<AssetModel> assets) =>
            {
                this.UpdateAssetList(assets);
            };

            this.assetManager.OnCurrentAssetChanged += (AssetModel asset) =>
            {
                this.UpdateFrameComboBox(asset);
            };

            this.assetManager.OnLoadFrame += (ShapeModel shapeModel) =>
            {
                this.drawer.DrawButtons(shapeModel, (int)this.ZoomLevel.Value);
            };

            this.palet.OnColorSelected += (Brush color) =>
            {
                this.drawer.SetAciveColor(color);
            };
        }
        /// <summary>
        /// Updates the frame ComboBox.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="selectIndex">Index of the select.</param>
        private void UpdateFrameComboBox(AssetModel asset, int selectIndex = 0)
        {
            var frames = Enumerable.Range(1, asset.Shapes.Count()).Select(e => e.ToString());
            this.SelectFrame.Items.Clear();

            frames.ToList().ForEach(f => this.SelectFrame.Items.Add(f));
            this.SelectFrame.SelectedIndex = selectIndex;
        }
        /// <summary>
        /// Updates the asset list.
        /// </summary>
        /// <param name="assets">The assets.</param>
        private void UpdateAssetList(IEnumerable<AssetModel> assets)
        {
            var assetNames = assets.Select(a => a.Name).ToArray();
            this.AssetsList.Items.Clear();

            foreach (var assetName in assetNames)
            {
                this.AssetsList.Items.Add(assetName);
            }

            this.AssetsList.SelectedIndex = 0;
        }

        private void AddFrame(object sender, RoutedEventArgs e)
        {
            this.assetManager.AddShapeToAsset();
            this.SelectFrame.SelectedIndex = this.SelectFrame.Items.Count - 1;
        }

        private void ZoomLevelChanged(object sender, ManipulationCompletedEventArgs e)
        {

        }

        private void AddColumnLeft(object sender, RoutedEventArgs e)
        {
            this.assetManager.AddColumnLeft();
        }

        private void AddColumnRight(object sender, RoutedEventArgs e)
        {
            this.assetManager.AddColumnRight();
        }

        private void RemoveColumnRight(object sender, RoutedEventArgs e)
        {
            this.assetManager.RemoveColumnRight();
        }

        private void RemoveRowTop(object sender, RoutedEventArgs e)
        {
            this.assetManager.RemoveRowTop();
        }

        private void RemoveRowBottom(object sender, RoutedEventArgs e)
        {
            this.assetManager.RemoveRowBottom();
        }

        private void RemoveColumnLeft(object sender, RoutedEventArgs e)
        {
            this.assetManager.RemoveColumnLeft();
        }

        private void AddRowTop(object sender, RoutedEventArgs e)
        {
            this.assetManager.AddRowTop();
        }

        private void AddRowBottom(object sender, RoutedEventArgs e)
        {
            this.assetManager.AddRowBottom();
        }

        private void MoveUp(object sender, RoutedEventArgs e)
        {
            this.assetManager.MoveUp();
        }

        private void MoveRight(object sender, RoutedEventArgs e)
        {
            this.assetManager.MoveRight();
        }

        private void MoveDown(object sender, RoutedEventArgs e)
        {
            this.assetManager.MoveDown();
        }

        private void MoveLeft(object sender, RoutedEventArgs e)
        {
            this.assetManager.MoveLeft();
        }

        private void RemoveFrame(object sender, RoutedEventArgs e)
        {
            this.assetManager.RemoveShapeFromAsset(this.SelectFrame.SelectedIndex);
            this.SelectFrame.SelectedIndex = 0;
        }

        private void CropAndAlign(object sender, RoutedEventArgs e)
        {
            this.assetManager.CropAndAlignAnchors();
        }

        private void RenderAll(object sender, RoutedEventArgs e)
        {
                }

        private void RemoveAsset(object sender, RoutedEventArgs e)
        {
            this.assetManager.Remove();
        }

        private void AddAsset(object sender, RoutedEventArgs e)
        {
            var newAsset = this.viewFactory.Get<NewAssetForm>();
            if (newAsset.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.assetManager.Add(newAsset.AssetName, newAsset.AssetType, newAsset.Frames, newAsset.XBlocks, newAsset.YBlocks);
            }
        }
    }
}
