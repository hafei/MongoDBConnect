using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBDataAccess;
using RepositoryTests;

namespace Repository
{
    public class InfoCollection : ConnectionProvider<Info>
    {
        public InfoCollection() : base()
        {

        }

        public Info GetInfoById(string name)
        {
            return this.Collection.AsQueryable().FirstOrDefault(x => x.name == name);
        }
    }
}
