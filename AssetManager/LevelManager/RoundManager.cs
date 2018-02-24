// <copyright file="RoundManager.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Managers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Round42.Models.Rounds;

    /// <summary>
    /// Level manager
    /// </summary>
    public class RoundManager
    {
        /// <summary>
        /// The round file
        /// </summary>
        private readonly string roundFile;

        /// <summary>
        /// The rounds
        /// </summary>
        private List<Round> rounds;

        /// <summary>
        /// The current round
        /// </summary>
        /// <value>
        /// The current round.
        /// </value>
        public Round CurrentRound { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoundManager"/> class.
        /// </summary>
        /// <param name="roundFile">The level file.</param>
        public RoundManager(string roundFile)
        {
            this.roundFile = roundFile;
        }

        /// <summary>
        /// Gets or sets the on rounds loaded action.
        /// </summary>
        /// <value>
        /// The on rounds loaded.
        /// </value>
        public Action<IEnumerable<string>> OnRoundsLoaded { get; set; }

        /// <summary>
        /// Gets or sets the on round selected.
        /// </summary>
        /// <value>
        /// The on round selected.
        /// </value>
        public Action<Round> OnRoundSelected { get; set; }

        /// <summary>
        /// Loads the rounds.
        /// </summary>
        public void LoadRounds()
        {
            if (File.Exists(this.roundFile))
            {
                this.rounds = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Round>>(this.roundFile);
            }
            else
            {
                this.rounds = new List<Round>();
                Enumerable.Range(1, 42).ToList().ForEach(i => this.rounds.Add(new Round { Name = $"Round {i.ToString()}" }));
            }

            this.OnRoundsLoaded?.Invoke(this.rounds.Select(r => r.Name));
        }

        /// <summary>
        /// Loads the name of the by.
        /// </summary>
        /// <param name="roundName">Name of the round.</param>
        public void LoadByName(string roundName)
        {
            this.CurrentRound = this.rounds.Single(r => r.Name == roundName);
            this.OnRoundSelected?.Invoke(this.CurrentRound);
        }
    }
}
