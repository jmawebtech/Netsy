﻿//-----------------------------------------------------------------------
// <copyright file="TagCategoryServiceTest.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.Test.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Netsy.DataModel;
    using Netsy.Interfaces;
    using Netsy.Requests;
    using Netsy.Services;
    using Netsy.Test.Requests;

    [TestClass]
    public class TagCategoryServiceTest
    {
        [TestMethod]
        public void CreateWithMockRequestTest()
        {
            EtsyContext etsyContext = new EtsyContext(string.Empty);
            IRequestGenerator requestGenerator = new MockFixedDataRequestGenerator(string.Empty);
            DataRetriever dataRetriever = new DataRetriever(new NullDataCache(), requestGenerator);
            ITagCategoryService service = new TagCategoryService(etsyContext, dataRetriever);

            Assert.IsNotNull(service);
        }
    }
}