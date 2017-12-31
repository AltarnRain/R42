// <copyright file="PlayerShip.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace BlockEngine.Classes.Ship
{
    using System.Drawing;
    using System.Windows.Forms;
    using BlockEngine.Interfaces;

    /// <summary>
    /// The player ship class
    /// </summary>
    /// <seealso cref="BlockEngine.Interfaces.IGameObject" />
    public class PlayerShip : IGameObject
    {
        private Panel canvas;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerShip" /> class.
        /// </summary>
        /// <param name="screenYPos">The screen y position.</param>
        /// <param name="screenXPos">The screen x position.</param>
        /// <param name="canvas">The canvas.</param>
        public PlayerShip(int screenXPos, int screenYPos, Panel canvas)
        {
            this.ScreenXPos = screenXPos;
            this.ScreenYPos = screenYPos;
            this.canvas = canvas;
        }

        /// <summary>
        /// Gets or sets the screen y position.
        /// </summary>
        /// <value>
        /// The screen y position.
        /// </value>
        public int ScreenYPos { get; set; }

        /// <summary>
        /// Gets or sets the s creen x position.
        /// </summary>
        /// <value>
        /// The s creen x position.
        /// </value>
        public int ScreenXPos { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGameObject" /> is invulnerable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if invulnerable; otherwise, <c>false</c>.
        /// </value>
        public bool Invulnerable { get; set; }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public void Draw()
        {
        }
    }
}
