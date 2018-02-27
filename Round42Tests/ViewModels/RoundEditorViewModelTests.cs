// <copyright file="RoundEditorViewModelTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests.ViewModels
{
    using System.Collections.ObjectModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Models.Enumerators;
    using Round42.Models.Rounds;
    using Round42.ViewModels.Rounds;

    /// <summary>
    /// Providers tests for <see cref="RoundEditorViewModel"/>
    /// </summary>
    [TestClass]
    public class RoundEditorViewModelTests : TestBase
    {
        /// <summary>
        /// Tests the round name list.
        /// </summary>
        [TestMethod]
        public void TestRoundNameList()
        {
            // Arrange
            var viewModel = this.Get<RoundEditorViewModel>();

            // Act
            var roundList = viewModel.Rounds;

            // Assert
            Assert.IsNotNull(roundList);
            Assert.AreEqual(42, roundList.Count);
        }

        /// <summary>
        /// Tests the round name list.
        /// </summary>
        [TestMethod]
        public void TestAddRound()
        {
            // Arrange
            var viewModel = this.Get<RoundEditorViewModel>();

            // Act
            viewModel.AddRound(new Round { LevelType = RoundTypes.AsteroidField, Name = "TestName", RoundActors = new ObservableCollection<RoundActor>() });

            // Assert
            var roundList = viewModel.Rounds;
            Assert.IsNotNull(roundList);
            Assert.AreEqual(43, roundList.Count);
            Assert.AreEqual(roundList[42].Name, "TestName");
        }
    }
}