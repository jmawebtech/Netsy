﻿//-----------------------------------------------------------------------
// <copyright file="UserParseTest.cs" company="AFS">
// Copyright (c) AFS. All rights reserved.
// </copyright>
//----------------------------------------------------------------------- 
namespace Netsy.DataModel.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Netsy.DataModel.UserData;
    using Netsy.Helpers;

    /// <summary>
    /// Test parsing string Json data into user details
    /// </summary>
    [TestClass]
    public class UserParseTest
    {
        /// <summary>
        /// Data for one user
        /// </summary>
        private const string UserDetails = @"{""user_name"":""Fred"",""user_id"":1234,""url"":""http:\/\/www.etsy.com\/shop.php?user_id=1234"",""image_url_25x25"":""http:\/\/ny-image2.etsy.com\/iusa_25x25.6043378.jpg"",""image_url_30x30"":""http:\/\/ny-image2.etsy.com\/iusa_30x30.6043378.jpg"",""image_url_50x50"":""http:\/\/ny-image2.etsy.com\/iusa_50x50.6043378.jpg"",""image_url_75x75"":""http:\/\/ny-image2.etsy.com\/iusa_75x75.6043378.jpg"",""join_epoch"":142567472.16,""city"":""London""}";

        /// <summary>
        /// A sample response text containing one user, low detail level
        /// </summary>
        private const string UsersLowDetailResponse = @"{""count"":1,""results"":[{""user_name"":""Fred"",""user_id"":1234,""url"":""http:\/\/www.etsy.com\/shop.php?user_id=1234"",""image_url_25x25"":""http:\/\/ny-image2.etsy.com\/iusa_25x25.6043378.jpg"",""image_url_30x30"":""http:\/\/ny-image2.etsy.com\/iusa_30x30.6043378.jpg"",""image_url_50x50"":""http:\/\/ny-image2.etsy.com\/iusa_50x50.6043378.jpg"",""image_url_75x75"":""http:\/\/ny-image2.etsy.com\/iusa_75x75.6043378.jpg"",""join_epoch"":142567472.16,""city"":""London""}],""params"":{""user_id"":1234,""detail_level"":""low""},""type"":""user""}";

        /// <summary>
        /// A sample response text containing one user, medium detail level
        /// </summary>
        private const string UsersMediumDetailResponse = @"{""count"":1,""results"":[{""user_name"":""Fred"",""user_id"":1234,""url"":""http:\/\/www.etsy.com\/shop.php?user_id=7394192"",""image_url_25x25"":""http:\/\/ny-image2.etsy.com\/iusa_25x25.6043378.jpg"",""image_url_30x30"":""http:\/\/ny-image2.etsy.com\/iusa_30x30.6043378.jpg"",""image_url_50x50"":""http:\/\/ny-image2.etsy.com\/iusa_50x50.6043378.jpg"",""image_url_75x75"":""http:\/\/ny-image2.etsy.com\/iusa_75x75.6043378.jpg"",""join_epoch"":1242567472.15,""city"":""London"",""gender"":""private"",""lat"":51.4985,""lon"":-0.1318,""transaction_buy_count"":1,""transaction_sold_count"":2,""is_seller"":true,""was_featured_seller"":false,""materials"":[""Fabric"",""buttons"",""cogs"",""brass"",""lace"",""satin"",""cotton""],""last_login_epoch"":1248902764.22}],""params"":{""user_id"":1234,""detail_level"":""medium""},""type"":""user""}";

        /// <summary>
        /// A sample response text containing one user, high detail level
        /// </summary>
        private const string UsersHighDetailResponse = @"{""count"":1,""results"":[{""user_name"":""Fred"",""user_id"":1234,""url"":""http:\/\/www.etsy.com\/shop.php?user_id=7394192"",""image_url_25x25"":""http:\/\/ny-image2.etsy.com\/iusa_25x25.6043378.jpg"",""image_url_30x30"":""http:\/\/ny-image2.etsy.com\/iusa_30x30.6043378.jpg"",""image_url_50x50"":""http:\/\/ny-image2.etsy.com\/iusa_50x50.6043378.jpg"",""image_url_75x75"":""http:\/\/ny-image2.etsy.com\/iusa_75x75.6043378.jpg"",""join_epoch"":1242567472.15,""city"":""London"",""gender"":""private"",""lat"":51.4985,""lon"":-0.1318,""transaction_buy_count"":1,""transaction_sold_count"":2,""is_seller"":true,""was_featured_seller"":false,""materials"":[""Fabric"",""buttons"",""cogs"",""brass"",""lace"",""satin"",""cotton""],""last_login_epoch"":1248902764.22,""feedback_count"":""1"",""feedback_percent_positive"":""100"",""referred_user_count"":0,""birth_day"":null,""birth_month"":null,""bio"":""Fred was here""}],""params"":{""user_id"":1234,""detail_level"":""high""},""type"":""user""}";

        /// <summary>
        /// Test parsing a user details
        /// </summary>
        [TestMethod]
        public void UserLowDetailParseTest()
        {
            User user = UserDetails.Deserialize<User>();

            Assert.IsNotNull(user);
            Assert.AreEqual("Fred", user.UserName);
            Assert.AreEqual(1234, user.UserId);

            Assert.AreEqual(@"http://www.etsy.com/shop.php?user_id=1234", user.Url);
            Assert.AreEqual(@"http://ny-image2.etsy.com/iusa_25x25.6043378.jpg", user.ImageUrl25x25);
            Assert.AreEqual(@"http://ny-image2.etsy.com/iusa_30x30.6043378.jpg", user.ImageUrl30x30);
            Assert.AreEqual(@"http://ny-image2.etsy.com/iusa_50x50.6043378.jpg", user.ImageUrl50x50);
            Assert.AreEqual(@"http://ny-image2.etsy.com/iusa_75x75.6043378.jpg", user.ImageUrl75x75);

            Assert.AreEqual(142567472.16, user.JoinEpoch);
            Assert.AreEqual("London", user.City);
        }

        /// <summary>
        /// Test parsing a users low details response
        /// </summary>
        [TestMethod]
        public void UsersLowDetailResponseParse()
        {
            Users users = UsersLowDetailResponse.Deserialize<Users>();

            Assert.IsNotNull(users);
            Assert.AreEqual(1, users.Count);

            User user1 = users.Results[0];

            Assert.IsNotNull(user1);
            Assert.AreEqual("Fred", user1.UserName);
            Assert.AreEqual("London", user1.City);
            Assert.AreEqual(1234, user1.UserId);

            QueryParams queryParams = users.Params;
            Assert.IsNotNull(queryParams);
            Assert.AreEqual(DetailLevel.Low, queryParams.DetailLevelEnum);
            Assert.AreEqual(1234, queryParams.UserId);
        }

        /// <summary>
        /// Test parsing a users medium detail response
        /// </summary>
        [TestMethod]
        public void UsersMediumDetailResponseParse()
        {
            Users users = UsersMediumDetailResponse.Deserialize<Users>();

            Assert.IsNotNull(users);
            Assert.AreEqual(1, users.Count);

            User user1 = users.Results[0];

            Assert.IsNotNull(user1);
            Assert.AreEqual("Fred", user1.UserName);
            Assert.AreEqual("London", user1.City);
            Assert.AreEqual(1234, user1.UserId);

            QueryParams queryParams = users.Params;
            Assert.IsNotNull(queryParams);
            Assert.AreEqual(DetailLevel.Medium, queryParams.DetailLevelEnum);
            Assert.AreEqual(1234, queryParams.UserId);
        }

        /// <summary>
        /// Test parsing a users high detail response
        /// </summary>
        [TestMethod]
        public void UsersHighDetailResponseParse()
        {
            Users users = UsersHighDetailResponse.Deserialize<Users>();

            Assert.IsNotNull(users);
            Assert.AreEqual(1, users.Count);

            User user1 = users.Results[0];

            Assert.IsNotNull(user1);
            Assert.AreEqual("Fred", user1.UserName);
            Assert.AreEqual("London", user1.City);
            Assert.AreEqual(1234, user1.UserId);

            QueryParams queryParams = users.Params;
            Assert.IsNotNull(queryParams);
            Assert.AreEqual(DetailLevel.High, queryParams.DetailLevelEnum);
            Assert.AreEqual(1234, queryParams.UserId);
        }
    }
}
