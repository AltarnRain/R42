// <copyright file="PaletFactoryTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Factories.Factories;

    /// <summary>
    /// Tests for the palet factory.
    /// </summary>
    /// <seealso cref="Round42.Tests.TestBase" />
    public class PaletFactoryTests : TestBase
    {
        /// <summary>
        /// Creates the factory.
        /// </summary>
        [TestMethod]
        public void CreateFactory()
        {
            var factory = this.Get<PaletFactory>();

            Assert.IsNotNull(factory);
        }

        /// <summary>
        /// Creates the palet.
        /// </summary>
        [TestMethod]
        public void CreatePalet()
        {
            var factory = this.Get<PaletFactory>();

            var palet = factory.Get(50);

            Assert.IsNotNull(palet);
            Assert.AreEqual(50, palet.ColorButtons.First().Height);
        }
    }
}
