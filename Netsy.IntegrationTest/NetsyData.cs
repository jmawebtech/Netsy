﻿//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.IntegrationTest
{
    /// <summary>
    /// Input data for integration tests
    /// </summary>
    public static class NetsyData
    {
        /// <summary>
        /// The API key to use for testing
        /// </summary>
        public const string EtsyApiKey = "rfc35bh98q3a9hvccfsxe4cc";

        /// <summary>
        /// the user to test on
        /// </summary>
        public const int TestUserId = 7572146;

        /// <summary>
        /// An invalid listing id for testing
        /// </summary>
        public const int TestBadListingId = 1;

        /// <summary>
        /// The gift guide id to test on
        /// </summary>
        public const int TestGiftGuideId = 168;

        /// <summary>
        /// The bad gift guide id to test on
        /// </summary>
        public const int TestBadGiftGuideId = 1;

        /// <summary>
        /// The feedback id to test on
        /// </summary>
        public const int TestFeedbackId = 1;

        /// <summary>
        /// An Invalid feedback id to test on
        /// </summary>
        public const int TestBadFeedbackId = 123456789;

        /// <summary>
        /// The test category to use for results
        /// </summary>
        public const string TestCategory = "jewelry";

        /// <summary>
        /// The test category to use for no results
        /// </summary>
        public const string TestBadCategory = "04BogusStufzzz";

        /// <summary>
        /// the name of the user to test on
        /// </summary>
        public const string TestUserName = "AUTOMATIEK";

        /// <summary>
        /// an invalid user name
        /// </summary>
        public const string TestBadUserName = "ERTZFZ_BadUserName";

        /// <summary>
        /// an invalid user id
        /// </summary>
        public const int TestBadUserId = 1;
    }
}
