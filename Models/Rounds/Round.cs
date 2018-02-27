// <copyright file="Round.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Models.Rounds
{
    using System.Collections.ObjectModel;
    using Round42.Models.Enumerators;

    /// <summary>
    /// Represents a level.
    /// </summary>
    public class Round
    {
        /// <summary>
        /// Gets or sets the type of the level.
        /// </summary>
        /// <value>
        /// The type of the level.
        /// </value>
        public RoundTypes LevelType { get; set; }

        /// <summary>
        /// Gets or sets the round actors.
        /// </summary>
        /// <value>
        /// The round actors.
        /// </value>
        public ObservableCollection<RoundActor> RoundActors { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
