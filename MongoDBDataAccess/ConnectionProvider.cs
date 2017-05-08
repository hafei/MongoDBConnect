using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBDataAccess.Interface;

namespace MongoDBDataAccess
{
    public class ConnectionProvider<T> : IConnectionProvider
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        private IMongoClient client;
        private IMongoDatabase database;
        private MongoUrl mongoUrl;
        private IMongoCollection<T> collection;
        public IMongoDatabase Database
        {
            get
            {
                return database;
            }

            set
            {
                database = value;
            }
        }

        public IMongoClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        public MongoUrl MongoUrl
        {
            get
            {
                return mongoUrl;
            }

            set
            {
                mongoUrl = value;
            }
        }

        public IMongoCollection<T> Collection
        {
            get
            {
                return collection;
            }

            set
            {
                collection = value;
            }
        }

        public ConnectionProvider()
        {
            MongoUrl = new MongoUrl(_connectionString);
            Client = new MongoClient();
            Database = Client.GetDatabase(MongoUrl.DatabaseName);
            Collection = Database.GetCollection<T>(typeof(T).ToString());
        }

        public ConnectionProvider(string collectionName)
        {
            MongoUrl = new MongoUrl(_connectionString);
            Client = new MongoClient();
            Database = Client.GetDatabase(MongoUrl.DatabaseName);
            Collection = Database.GetCollection<T>(collectionName);
        }
    }
}
