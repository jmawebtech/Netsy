﻿//-----------------------------------------------------------------------
// <copyright file="GetAllListingsTest.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.Test.Services.ListingsTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Netsy.DataModel;
    using Netsy.Helpers;
    using Netsy.Interfaces;

    /// <summary>
    /// Test the GetAllListings function on the listings service
    /// </summary>
    [TestClass]
    public class GetAllListingsTest
    {
        /// <summary>
        /// Test missing API key
        /// </summary>
        [TestMethod]
        public void GetAllListingsApiKeyMissingTest()
        {
            // ARRANGE
            IListingsService listingsService = ServiceCreationHelper.MakeListingsService(string.Empty);
            ResultEventArgs<Listings> result = null;
            listingsService.GetAllListingsCompleted += (s, e) => result = e;

            // ACT
            listingsService.GetAllListings(SortField.Created, SortOrder.Down, 0, 10, DetailLevel.Low);

            // check the data
            TestHelpers.CheckResultFailure(result, Constants.EmptyApiKeyErrorMessage);
        }

        /// <summary>
        /// Test a negative offset
        /// </summary>
        [TestMethod]
        public void GetAllListingsNegativeOffsetTest()
        {
            // ARRANGE
            IListingsService listingsService = ServiceCreationHelper.MakeListingsService(Constants.DummyEtsyApiKey);
            ResultEventArgs<Listings> result = null;
            listingsService.GetAllListingsCompleted += (s, e) => result = e;

            // ACT
            listingsService.GetAllListings(SortField.Created, SortOrder.Down, -1, 10, DetailLevel.Low);

            // check the data
            TestHelpers.CheckResultFailure(result, "Negative offset of -1");
        }

        /// <summary>
        /// Test a negative offset
        /// </summary>
        [TestMethod]
        public void GetAllListingsZeroLimitTest()
        {
            // ARRANGE
            IListingsService listingsService = ServiceCreationHelper.MakeListingsService(Constants.DummyEtsyApiKey);
            ResultEventArgs<Listings> result = null;
            listingsService.GetAllListingsCompleted += (s, e) => result = e;

            // ACT
            listingsService.GetAllListings(SortField.Created, SortOrder.Down, 0, 0, DetailLevel.Low);

            // check the data
            TestHelpers.CheckResultFailure(result, "Bad limit of 0");
        }
    }
}
