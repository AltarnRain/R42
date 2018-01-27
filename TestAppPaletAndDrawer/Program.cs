// <copyright file="Program.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.TestAppPaletAndDrawer
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Main program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestApp());
        }
    }
}
