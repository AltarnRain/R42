// <copyright file="Main.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42
{
    using System;
    using System.Windows.Forms;
    using Round42.Classes.Ship;

    /// <summary>
    /// Main form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Main : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Tick event of the MainTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainTimer_Tick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the MouseClick event of the panel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            var ps = new PlayerShip(e.Location.X, e.Location.Y, this.canvas);
            ps.Draw();
        }
    }
}
