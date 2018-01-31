// <copyright file="TestBase.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace TestBase
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Base class for testing.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// The test context instance
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }

        /// <summary>
        /// Gets the out folder in the deploy folder.
        /// </summary>
        /// <returns>Full path to the out folder.</returns>
        public string GetOutFolder()
        {
            return this.TestContext.TestDeploymentDir.EndsWith(@"\") ? this.testContextInstance.TestDeploymentDir : this.TestContext.TestDeploymentDir + @"\";
        }
    }
}