// <copyright file="BaseViewModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Round42.ViewModels.Base
{
    using System.ComponentModel;
    using PropertyChanged;

    /// <summary>
    /// Base view model for all view models.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
