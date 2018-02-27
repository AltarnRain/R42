// <copyright file="Programs.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RoundEditor
{
    using System;
    using Ninject;

    /// <summary>
    /// Main program for Round Editor
    /// </summary>
    internal static class Programs
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            using (var kernel = new StandardKernel())
            {
                var form = kernel.Get<MainWindow>();
                form.ShowDialog();
            }
        }
    }
}
