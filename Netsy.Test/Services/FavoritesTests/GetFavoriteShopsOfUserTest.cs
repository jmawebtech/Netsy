﻿//-----------------------------------------------------------------------
// <copyright file="GetFavoriteShopsOfUserTest.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.Test.Services.FavoritesTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Netsy.DataModel;
    using Netsy.Helpers;
    using Netsy.Interfaces;

    /// <summary>
    /// Test the GetFavoriteShopOfUser API function
    /// </summary>
    [TestClass]
    public class GetFavoriteShopsOfUserTest
    {
        /// <summary>
        /// Test missing API key
        /// </summary>
        [TestMethod]
        public void GetFavoriteShopsOfUserMissingApiKeyTest()
        {
            // ARRANGE
            IFavoritesService favoritesService = ServiceCreationHelper.MakeFavouritesService(string.Empty);
            ResultEventArgs<Shops> result = null;
            favoritesService.GetFavoriteShopsOfUserCompleted += (s, e) => result = e;

            // ACT
            favoritesService.GetFavoriteShopsOfUser(Constants.TestId, 0, 10, DetailLevel.Low);

            // check the data
            TestHelpers.CheckResultFailure(result);
        }

        /// <summary>
        /// Test missing API key
        /// </summary>
        [TestMethod]
        public void GetFavoriteShopsOfUserByNameMissingApiKeyTest()
        {
            // ARRANGE
            IFavoritesService favoritesService = ServiceCreationHelper.MakeFavouritesService(string.Empty);
            ResultEventArgs<Shops> result = null;
            favoritesService.GetFavoriteShopsOfUserCompleted += (s, e) => result = e;

            // ACT
            favoritesService.GetFavoriteShopsOfUser(Constants.TestName, 0, 10, DetailLevel.Low);

            // check the data
            TestHelpers.CheckResultFailure(result);
        }
    }
}
