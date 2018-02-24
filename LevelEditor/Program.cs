// <copyright file="Program.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace LevelEditor
{
    using System;
    using System.Windows.Forms;
    using Ninject;

    /// <summary>
    /// Main program loop of the level editor
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var kernel = new StandardKernel())
            {
                Application.Run(kernel.Get<LevelEditor>());
            }
        }
    }
}
