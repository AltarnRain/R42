using AssetEditor2.Properties;
using Round42.CustomComponents;
using Round42.Factories;
using Round42.Managers;
using System.Windows;

namespace AssetEditor2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AssetManager assetManager;

        public MainWindow(AssetManager assetManager)
        {
            InitializeComponent();
            this.assetManager = assetManager;
            this.DataContext = assetManager;

            this.ZoomLevel.Value = Settings.Default.ZoomLevel;

            // Load assets and trigger events.
            this.assetManager.LoadAssets();
        }
    }
}
