// <copyright file="MainWindow.xaml.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RoundEditor
{
    using System.Windows;
    using Round42.ViewModels.Rounds;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        /// <param name="roundEditorViewModel">The round editor view model.</param>
        public MainWindow(RoundEditorViewModel roundEditorViewModel)
        {
            this.InitializeComponent();
            this.DataContext = roundEditorViewModel;
        }
    }
}
