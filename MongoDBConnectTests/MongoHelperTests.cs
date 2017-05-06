using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDBConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBConnect.Tests
{
    [TestClass()]
    public class MongoHelperTests
    {
        [TestMethod()]
        public void SelectOneTest()
        {
            var result = new MongoHelper("zhang").SelectOne<BsonDocument>("info", Builders<BsonDocument>.Filter.Eq("name","zhangmeng"));
            Console.WriteLine(result.Count());
            Assert.IsNotNull(result);
        }
    }
}