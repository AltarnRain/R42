// <copyright file="RoundEditor.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace LevelEditor
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Round42.Factories;
    using Round42.Managers;
    using Round42.Models.Rounds;
    using Round42.Providers;

    /// <summary>
    /// Level Editor
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LevelEditor : Form
    {
        /// <summary>
        /// The file location provider
        /// </summary>
        private readonly FileLocationProvider fileLocationProvider;

        /// <summary>
        /// The round manager factory
        /// </summary>
        private readonly RoundManagerFactory roundManagerFactory;
        private readonly AssetManagerFactory assetManagerFactory;
        private readonly AssetManager assetManager;

        /// <summary>
        /// The round manager
        /// </summary>
        private readonly RoundManager roundManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelEditor" /> class.
        /// </summary>
        /// <param name="fileLocationProvider">The file location provider.</param>
        /// <param name="roundManagerFactory">The round manager factory.</param>
        /// <param name="assetManagerFactory">The asset manager factory.</param>
        public LevelEditor(FileLocationProvider fileLocationProvider, RoundManagerFactory roundManagerFactory, AssetManagerFactory assetManagerFactory)
        {
            this.InitializeComponent();
            this.fileLocationProvider = fileLocationProvider;
            this.roundManagerFactory = roundManagerFactory;
            this.assetManagerFactory = assetManagerFactory;

            this.assetManager = this.assetManagerFactory.Get(this.fileLocationProvider.AssetFile, false);
            this.roundManager = this.roundManagerFactory.Get(this.fileLocationProvider.RoundFile);

            this.LoadComboboxData();
            this.SetupEvents();

            this.roundManager.LoadRounds();
        }

        private void LoadComboboxData()
        {
            foreach (var asset in this.assetManager.GetAssets())
            {
                this.Asset.Items.Add(asset.Name);
            }

            

        }

        private void SetupEvents()
        {
            this.roundManager.OnRoundsLoaded = (IEnumerable<string> roundNames) =>
            {
                foreach (var round in roundNames)
                {
                    this.Rounds.Items.Add(round);
                }
            };

            this.roundManager.OnRoundSelected = (Round round) =>
            {

            };
        }

        private void Rounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            this.roundManager.LoadByName(listBox.SelectedItem as string);
        }
    }
}
