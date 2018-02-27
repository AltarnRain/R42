// <copyright file="RoundEditorViewModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.ViewModels.Rounds
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Input;
    using global::ViewModels.Base;
    using Round42.Models.Enumerators;
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


            // Initialize rounds.
            this.Initialize();
        }


        /// <summary>
        /// Gets or sets the rounds.
        /// </summary>
        /// <value>
        /// The rounds.
        /// </value>
        public ObservableCollection<Round> Rounds { get; set; }

        public int SelectedIndex
        {
            set
            {
                this.SelectedIndex = value;
            }
        }



        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            if (File.Exists(this.roundFile))
            {
                this.Rounds = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Round>>(File.ReadAllText(this.roundFile));
            }
            else
            {
                this.Rounds = new ObservableCollection<Round>(Enumerable.Range(1, 42).Select(n => new Round { LevelType = RoundTypes.Ships, Name = "Round " + n.ToString(), RoundActors = new ObservableCollection<RoundActor>() }));
            }
        }

        /// <summary>
        /// Adds the round.
        /// </summary>
        /// <param name="round">The round.</param>
        public void AddRound(Round round)
        {
            this.Rounds.Add(round);
        }

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
