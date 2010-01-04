﻿//-----------------------------------------------------------------------
// <copyright file="ShopWindowViewModel.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.WpfUI.Windows.Shop
{
    using System.Windows.Input;

    using Main;

    using Netsy.DataModel;
    using Netsy.UI.ViewModels;
    using Netsy.UI.ViewModels.Shops;

    /// <summary>
    /// View model for the shop window
    /// </summary>
    public class ShopWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// Command to load the shop
        /// </summary>
        private readonly ICommand shopWindowLoadShopCommand;

        /// <summary>
        /// The shop listings being displayed
        /// </summary>
        private readonly ShopListingsViewModel shopListingsViewModel;

        /// <summary>
        /// The user's favorite shops 
        /// </summary>
        private readonly FavoriteShopsOfUserViewModel favoriteShopsOfUserViewModel;

        /// <summary>
        /// The user's favorite shops 
        /// </summary>
        private readonly FavoriteListingsOfUserViewModel favoriteListingsOfUserViewModel;

        /// <summary>
        /// the shop being diplayed
        /// </summary>
        private ShopViewModel shopViewModel;

        /// <summary>
        /// the shop id used
        /// </summary>
        private int userId;

        /// <summary>
        /// Initializes a new instance of the ShopWindowViewModel class
        /// </summary>
        /// <param name="shopListingsViewModel">viewmodel for the listings</param>
        /// <param name="favoriteShopsOfUserViewModel">viewmodel for the favorite shops</param>
        /// <param name="favoriteListingsOfUserViewModel">viewmodel for the favorite listings</param>
        /// <param name="shopWindowLoadShopCommand">Command to load the shop</param>
        /// <param name="showListingWindowCommand">Command to show the listing window for a shop</param>
        public ShopWindowViewModel(
            ShopListingsViewModel shopListingsViewModel, 
            FavoriteShopsOfUserViewModel favoriteShopsOfUserViewModel,
            FavoriteListingsOfUserViewModel favoriteListingsOfUserViewModel,
            ShopWindowLoadShopCommand shopWindowLoadShopCommand,
            ShowListingWindowCommand showListingWindowCommand)
        {
            this.shopListingsViewModel = shopListingsViewModel;
            this.favoriteShopsOfUserViewModel = favoriteShopsOfUserViewModel;
            this.favoriteListingsOfUserViewModel = favoriteListingsOfUserViewModel;

            this.shopListingsViewModel.ShowListingCommand = showListingWindowCommand;
            this.FavoriteShopsOfUserViewModel.ShowListingCommand = showListingWindowCommand;

            this.shopWindowLoadShopCommand = shopWindowLoadShopCommand;
        }

        /// <summary>
        /// Gets or sets the user id used 
        /// </summary>
        public int UserId
        {
            get
            {
                return this.userId;
            }

            set
            {
                this.userId = value;
                this.ShopListingsViewModel.ShopId = value;
                this.FavoriteListingsOfUserViewModel.UserId = value;
                this.FavoriteShopsOfUserViewModel.UserId = value;
            }
        }

        /// <summary>
        /// Gets or sets the viewmodel of the shop being displayed
        /// </summary>
        public ShopViewModel Shop
        {
            get
            {
                return this.shopViewModel;
            }

            set
            {
                if (this.shopViewModel != value)
                {
                  this.shopViewModel = value;
                  this.OnPropertyChanged("Shop");
                  this.OnPropertyChanged("ShopData");
              }
            }
        }

        /// <summary>
        /// Gets the data of the shop being displayed
        /// </summary>
        public Shop ShopData
        {
            get
            {
                if (this.shopViewModel == null)
                {
                    return null;
                }

                return this.shopViewModel.Shop;
            }
        }

        /// <summary>
        /// Gets the command to load the shop
        /// </summary>
        public ICommand ShopWindowLoadShopCommand
        {
            get
            {
                return this.shopWindowLoadShopCommand;
            }
        }

        /// <summary>
        /// Gets the shop listings being displayed
        /// </summary>
        public ShopListingsViewModel ShopListingsViewModel
        {
            get
            {
                return this.shopListingsViewModel;
            }
        }

        /// <summary>
        /// Gets the viewmodel for the user's favorite shops 
        /// </summary>
        public FavoriteShopsOfUserViewModel FavoriteShopsOfUserViewModel
        {
            get
            {
                return this.favoriteShopsOfUserViewModel;
            }
        }

        /// <summary>
        /// Gets the viewmodel for the user's favorite shops 
        /// </summary>
        public FavoriteListingsOfUserViewModel FavoriteListingsOfUserViewModel
        {
            get
            {
                return this.favoriteListingsOfUserViewModel;
            }
        }
    }
}
