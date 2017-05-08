using System;
using MongoDB.Driver;

namespace MongoDBDataAccess.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMongo : IDisposable
    {
        IConnectionProvider ConnectionProvider { get; }

        IMongoDatabase Database { get; }

        IMongoCollection<T> GetCollection<T>(string collectionName);

        IMongoCollection<T> GetCollection<T>();
    }
}