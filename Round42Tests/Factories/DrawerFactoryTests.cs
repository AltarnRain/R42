﻿// <copyright file="DrawerFactoryTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.Tests
{
    using System;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Round42.Factories;
    using Round42.Factories.Factories;

    /// <summary>
    /// Tests fo the <see cref="AssetManagerFactory"/>
    /// </summary>
    /// <seealso cref="Round42.Tests.TestBase" />
    [TestClass]
    public class DrawerFactoryTests : TestBase
    {
        /// <summary>
        /// Creates the factory.
        /// </summary>
        [TestMethod]
        public void CreateFactory()
        {
            var factory = this.Get<DrawerFactory>();
            Assert.IsNotNull(factory);
        }

        /// <summary>
        /// Creates the asset manager.
        /// </summary>
        [TestMethod]
        public void CreateAssetManager()
        {
            var factory = this.Get<DrawerFactory>();

            var drawer = factory.Get(new Panel());
            Assert.IsNotNull(drawer);
        }
    }
}