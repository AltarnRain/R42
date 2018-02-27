// <copyright file="RoundEditorViewModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.ViewModels.Rounds
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using Round42.Models.Rounds;
    using Round42.Providers;
    using Round42.ViewModels.Base;

    /// <summary>
    /// Level manager
    /// </summary>
    public class RoundEditorViewModel : BaseViewModel
    {
        /// <summary>
        /// The round file
        /// </summary>
        private readonly string roundFile;

        /// <summary>
        /// The file location provider
        /// </summary>
        private readonly FileLocationProvider fileLocationProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoundEditorViewModel" /> class.
        /// </summary>
        /// <param name="fileLocationProvider">The file location provider.</param>
        public RoundEditorViewModel(FileLocationProvider fileLocationProvider)
        {
            this.fileLocationProvider = fileLocationProvider;
            this.roundFile = this.fileLocationProvider.RoundFile;
        }

        /// <summary>
        /// Gets or sets the rounds.
        /// </summary>
        /// <value>
        /// The rounds.
        /// </value>
        public ObservableCollection<Round> Rounds { get; set; }

        /// <summary>
        /// Gets the current round.
        /// </summary>
        /// <value>
        /// The current round.
        /// </value>
        public Round CurrentRound { get; private set; }

        /// <summary>
        /// Loads the rounds.
        /// </summary>
        public void LoadRounds()
        {
            if (File.Exists(this.roundFile))
            {
                this.Rounds = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Round>>(this.roundFile);
            }
            else
            {
                this.Rounds = new ObservableCollection<Round>();
                Enumerable.Range(1, 42).ToList().ForEach(i => this.Rounds.Add(new Round { Name = $"Round {i.ToString()}" }));
            }
        }
    }
}
