﻿//-----------------------------------------------------------------------
// <copyright file="WebRequestGeneratorTest.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.IntegrationTest.Requests
{
    using System;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Netsy.Requests;
    using Netsy.Test;

    /// <summary>
    /// Test the WebRequestGenerator class
    /// </summary>
    [TestClass]
    public class WebRequestGeneratorTest
    {
        /// <summary>
        /// Test simple creation
        /// </summary>
        [TestMethod]
        public void RequestGeneratorCreateTest()
        {
            IRequestGenerator requestGenerator = new WebRequestGenerator();

            Assert.IsNotNull(requestGenerator);
        }

        /// <summary>
        /// Test retrieval
        /// </summary>
        [TestMethod]
        public void RequestGeneratorRetrieveTest()
        {
            IRequestGenerator requestGenerator = new WebRequestGenerator();
            const string TestUri = "http://beta-api.etsy.com/v1/listings/featured/front?offset=0&limit=10&detail_level=low&api_key=" +
                NetsyData.EtsyApiKey;

            string resultString = string.Empty;
            Exception ex = null;

            using (AutoResetEvent waitEvent = new AutoResetEvent(false))
            {
                Action<string> successAction = s =>
                     {
                        resultString = s;
                        waitEvent.Set();
                     };

                Action<Exception> errorAction = e =>
                    {
                        ex = e;
                        waitEvent.Set();
                    };

                requestGenerator.StartRequest(new Uri(TestUri), successAction, errorAction);
                bool signalled = waitEvent.WaitOne(Constants.WaitTimeout);

                Assert.IsTrue(signalled);
                Assert.IsFalse(string.IsNullOrEmpty(resultString));
                Assert.IsNull(ex);
            }
        }
    }
}

