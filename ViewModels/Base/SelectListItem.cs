// <copyright file="SelectListItem.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace ViewModels.Base
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A generic command.
    /// </summary>
    /// <seealso cref="ICommand" />
    public class SelectListItem : ICommand
    {
        /// <summary>
        /// The action
        /// </summary>
        private readonly Action action;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectListItem"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public SelectListItem(Action action)
        {
            this.action = action;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
