using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;
using MongoDBDataAccess.Interface;

namespace MongoDBDataAccess
{
    class Mongo:IMongo
    {
        //private readonly string _options;
        private IConnection _connection;
        private bool _disposed;
        public Mongo(IConnectionProvider connectionProvider, IMongoDatabase database)
        {
            ConnectionProvider = connectionProvider;
            Database = database;
        }



        public IConnectionProvider ConnectionProvider { get; }
        public IMongoDatabase Database { get; }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
        }

    }
}
