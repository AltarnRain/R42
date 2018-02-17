using Round42.Factories;
using Round42.Factories.Factories;
using Round42.Managers;
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

        StackPanel palet;
        AssetManager assetManager;
        Grid drawer;

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

            this.ButtonSize.Value = Settings.Default.ZoomLevel;

            // Event handler setup must precede loading assets but happen after the asset manager is created
            this.SetupEventHandlers();

            // Load assets and trigger events.
            this.assetManager.LoadAssets();
        }

        private void AddFrame(object sender, RoutedEventArgs e)
        {

        }

        private void ZoomLevel(object sender, ManipulationCompletedEventArgs e)
        {

        }

        private void AddColumnLeft(object sender, RoutedEventArgs e)
        {

        }

        private void AddColumnRight(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveColumnRight(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveRowTop(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveRowBottom(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveColumnLeft(object sender, RoutedEventArgs e)
        {

        }

        private void AddRowTop(object sender, RoutedEventArgs e)
        {

        }

        private void AddRowBottom(object sender, RoutedEventArgs e)
        {

        }

        private void MoveUp(object sender, RoutedEventArgs e)
        {

        }

        private void MoveRight(object sender, RoutedEventArgs e)
        {

        }

        private void MoveDown(object sender, RoutedEventArgs e)
        {

        }

        private void MoveLeft(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveFrame(object sender, RoutedEventArgs e)
        {

        }
    }
}
