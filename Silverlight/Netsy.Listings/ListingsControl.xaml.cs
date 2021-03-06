﻿//-----------------------------------------------------------------------
// <copyright file="ListingsControl.xaml.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.Listings
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Display Listings
    /// </summary>
    public partial class ListingsControl : UserControl
    {
        /// <summary>
        /// Storyboard for control entry
        /// </summary>
        private Storyboard controlEnterStoryboard;

        /// <summary>
        /// Storyboard for control exit
        /// </summary>
        private Storyboard controlLeaveStoryboard;

        /// <summary>
        /// Storyboard for pulsing the bar visiblity 
        /// </summary>
        private Storyboard pulseStoryboard;

        /// <summary>
        /// True when the mouse is inside
        /// </summary>
        private bool mouseIn;

        /// <summary>
        /// Initializes a new instance of the ListingsControl class
        /// </summary>
        public ListingsControl()
        {
            InitializeComponent();
            this.InitializeStoryBoards();
        }

        /// <summary>
        /// Event handler for animations when listings have been loaded
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event params</param>
        public void ListingsLoaded(object sender, EventArgs e)
        {
            if (! this.mouseIn)
            {
                this.pulseStoryboard.Begin();
            }
        }

        /// <summary>
        /// set up the storyboards
        /// </summary>
        private void InitializeStoryBoards()
        {
            this.controlEnterStoryboard = (Storyboard)this.Resources["controlEnter"];

            this.controlLeaveStoryboard = (Storyboard)this.Resources["controlLeave"];
            this.controlLeaveStoryboard.Completed += (s, e) => this.HidePanelWhenOut();

            this.pulseStoryboard = (Storyboard)this.Resources["pulse"];
            this.pulseStoryboard.Completed += (s, e) => this.HidePanelWhenOut();
        }

        /// <summary>
        /// Action at the end of a fade-out animation - hide the panel 
        /// unless the mouse has already moved back in
        /// </summary>
        private void HidePanelWhenOut()
        {
            if (!this.mouseIn)
            {
                this.NavigationPanel.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Move to previous page
        /// </summary>
        /// <param name="sender">the event page</param>
        /// <param name="e">the event params</param>
        private void PrevButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ListingsControlViewModel viewModel = this.DataContext as ListingsControlViewModel;
            if (viewModel == null)
            {
                return;
            }

            if (viewModel.PreviousPageCommand.CanExecute(viewModel))
            {
                viewModel.PreviousPageCommand.Execute(viewModel);
            }
        }

        /// <summary>
        /// Move to next page
        /// </summary>
        /// <param name="sender">the event page</param>
        /// <param name="e">the event params</param>
        private void NextButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ListingsControlViewModel viewModel = this.DataContext as ListingsControlViewModel;
            if (viewModel == null)
            {
                return;
            }

            if (viewModel.NextPageCommand.CanExecute(viewModel))
            {
                viewModel.NextPageCommand.Execute(viewModel);
            }
        }

        /// <summary>
        /// Mouse focus enters the control
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">the event params</param>
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.mouseIn = true;
            this.NavigationPanel.Visibility = System.Windows.Visibility.Visible;
            this.controlEnterStoryboard.Begin();
        }

        /// <summary>
        /// Mouse focus leaves the control
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">the event params</param>
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            this.mouseIn = false;
            this.controlLeaveStoryboard.Begin();
        }
    }
}
