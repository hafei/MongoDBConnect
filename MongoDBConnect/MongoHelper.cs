using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MongoDBConnect
{

    public class MongoHelper : IDisposable
    {

        protected static IMongoClient Client;
        protected static IMongoDatabase Database;

        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                _connectionString = "mongodb://localhost:27017";
                return _connectionString;
            }

            set
            {
                _connectionString = "mongodb://localhost:27017";
            }
        }

        //public static IMongoClient GetMongoClient()
        //{
        //    if (Client == null)
        //    {
        //        Console.WriteLine(ConnectionString);
        //        Client = new MongoClient(new MongoUrl(ConnectionString));
        //    }
        //    return Client;
        //}


        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //    }
        //}


        public MongoHelper(string dbName)
        {
            Client = new MongoClient(new MongoUrl(ConnectionString));
            Database = Client.GetDatabase(dbName);
        }
        public T SelectOne<T>(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = Database.GetCollection<BsonDocument>(collectionName);
            var result = collection.Find(filter).ToList();
            if (result.Count > 1)
            {
                throw new Exception("To many results");
            }
            return BsonSerializer.Deserialize<T>(result.ElementAt(0));
        }


        public bool Insert(string collectionName, BsonDocument doc)
        {
            try
            {
                var collection = Database.GetCollection<BsonDocument>(collectionName);
                collection.InsertOne(doc);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
