﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Driver;
using Norm;
using IMongoDatabase = Norm.IMongoDatabase;

namespace Repository
{
    public class MongoRepository : IRepository
    {
        private IMongo _provider;

        public MongoRepository()
        {
            _provider = Mongo.Create(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        private Norm.IMongoDatabase _db { get { return this._provider.Database; } }

        public void Add<T>(T item) where T : class, new()
        {
            _db.GetCollection<T>().Save(item);
        }

        public void Add<T>(IEnumerable<T> items) where T : class, new()
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public void Insert<T>(T item) where T : class, new()
        {
            _db.GetCollection<T>().Insert(item);
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            return _db.GetCollection<T>().AsQueryable();
        }

        public IQueryable<T> All<T>(int page, int pageSize) where T : class, new()
        {
            return PagingExtensions.Page(All<T>(), page, pageSize);
        }

        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new()
        {
            var items = All<T>().Where(expression);
            foreach (T item in items)
            {
                Delete(item);
            }
        }

        public void Delete<T>(T item) where T : class, new()
        {
            // Remove the object.
            _db.GetCollection<T>().Delete(item);
        }

        public void DeleteAll<T>() where T : class, new()
        {
            _db.DropCollection(typeof(T).Name);
        }

        public void Dispose()
        {
            _provider.Dispose();
        }

        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new()
        {
            return All<T>().Where(expression).SingleOrDefault();
        }
    }
}