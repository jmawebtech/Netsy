﻿//-----------------------------------------------------------------------
// <copyright file="NetsyData.cs" company="AFS">
// Copyright (c) AFS. All rights reserved.
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.IntegrationTest
{
    using Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Helpers on integration tests
    /// Input data and output inspection
    /// </summary>
    public static class NetsyData
    {
        /// <summary>
        /// how long to wait before timing out - 100 seconds
        /// </summary>
        public const int WaitTimeout = 100000;

        /// <summary>
        /// The API key to use for testing
        /// </summary>
        public const string EtsyApiKey = "rfc35bh98q3a9hvccfsxe4cc";

        /// <summary>
        /// the user to test on
        /// </summary>
        public const int TestUserId = 7394192;

        /// <summary>
        /// Check that the result was sucessfull
        /// </summary>
        /// <typeparam name="T">the type of result data</typeparam>
        /// <param name="result">the data to inspect</param>
        public static void CheckResultSuccess<T>(ResultEventArgs<T> result)
        {
            Assert.IsNotNull(result, "Result is null");
            Assert.IsNotNull(result.ResultStatus, "Result Status is null");
            Assert.IsTrue(result.ResultStatus.Success, "Call failed");
            Assert.IsNotNull(result.ResultValue, "Result value is null");
        }

        /// <summary>
        /// Check that the result was a failure
        /// </summary>
        /// <typeparam name="T">the type of result data</typeparam>
        /// <param name="result">the data to inspect</param>
        public static void CheckResultFailure<T>(ResultEventArgs<T> result)
        {
            Assert.IsNotNull(result, "Result is null");
            Assert.IsNotNull(result.ResultStatus, "Result Status is null");
            Assert.IsFalse(result.ResultStatus.Success, "Call was expected to fail");
        }
    }
}
