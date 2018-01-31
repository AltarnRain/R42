// <copyright file="MainForm.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetEditor.Forms
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using AssetEditor.Properties;
    using Round42;

    /// <summary>
    /// Editor for assets
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        /// <summary>
        /// The asset manager
        /// </summary>
        private readonly AssetManager assetManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            this.assetManager = AssetManager.Create(Settings.Default.AssetFile);
        }
    }
}
