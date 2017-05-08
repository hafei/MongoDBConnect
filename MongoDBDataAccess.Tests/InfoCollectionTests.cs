using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests
{
    [TestClass()]
    public class InfoCollectionTests
    {
        [TestMethod()]
        public void GetInfoByIdTest()
        {
            InfoCollection collection = new InfoCollection();
            var info = collection.GetInfoById("STEVEN DUFFY");

            Assert.AreEqual("STEVEN DUFFY", info.name);
        }
    }
}