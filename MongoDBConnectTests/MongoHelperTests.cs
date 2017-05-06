using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDBConnect.Tests
{
    [TestClass()]
    public class MongoHelperTests
    {
        [TestMethod()]
        public void SelectOneTest()
        {
            var result = new MongoHelper("zhang").SelectOne<BsonDocument>("info", Builders<BsonDocument>.Filter.Eq("name", "zhangmeng"));
            Console.WriteLine(result.Count());
            Assert.IsNotNull(result);
        }
    }
}