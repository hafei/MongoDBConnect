using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using RandomNameGenerator;
using RepositoryTests;

namespace Repository.Tests
{
    [TestClass()]
    public class MongoRepositoryTests
    {
        private MongoRepository repository = new MongoRepository();
        [TestMethod()]
        public void AddTest()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //string[] maleNames = new string[10] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
            //string[] femaleNames = new string[4] { "abby", "abigail", "adele", "adrian" };
            //string[] lastNames = new string[5] { "abbott", "acosta", "adams", "adkins", "aguilar" };
            var random = new Random();


            repository.Add(new Info()
            {
                _id = Guid.NewGuid(),
                age = random.Next(15, 24),
                courseName = new string(Enumerable.Repeat(chars, 8)
                    .Select(s => s[random.Next(s.Length)]).ToArray()),
                name = RandomNameGenerator.NameGenerator.GenerateFirstName(Gender.Male) + " " + NameGenerator.GenerateLastName(),
                score = random.Next(40, 100)
            });
            //Assert.Fail();
        }

        [TestMethod()]
        public void AllTest()
        {
            var count = repository.All<Info>().Count(x => x.name == "STEVEN DUFFY");
            Assert.AreEqual(1, count);
        }

        [TestMethod()]
        public void InsertListTest()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000; i++)
            {
                repository.Add(new Info()
                {
                    _id = Guid.NewGuid(),
                    age = random.Next(15, 24),
                    courseName = new string(Enumerable.Repeat(chars, 8)
                        .Select(s => s[random.Next(s.Length)]).ToArray()),
                    name = RandomNameGenerator.NameGenerator.GenerateFirstName(Gender.Male) + " " + NameGenerator.GenerateLastName(),
                    score = random.Next(40, 100),
                    createTime = DateTime.Now
                });
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            //Assert.Fail();
        }


        [TestMethod()]
        public void GeneratrObjectId()
        {
            var objectId = ObjectId.GenerateNewId(DateTime.Now);
            Console.WriteLine(objectId);
        }
    }
}