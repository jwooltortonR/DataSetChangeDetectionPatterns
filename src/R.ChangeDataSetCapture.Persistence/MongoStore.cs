using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Interfaces.Entities;
using R.ChangeDataSetCapture.Persistence.Model;

namespace R.ChangeDataSetCapture.Persistence
{
    /// <summary>
    /// Mongo implementation of <see cref="IPersistenceStore"/>
    /// </summary>
    public class MongoStore : IPersistenceStore
    {
        private readonly string _collectionName;
        private readonly ConcurrentDictionary<Type, MongoCollection> _collections = new ConcurrentDictionary<Type, MongoCollection>();
        private readonly MongoDatabase _database;

        public MongoStore(string connectionString, string databaseName, string collectionName)
        {
            _collectionName = collectionName;
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            _database = server.GetDatabase(databaseName);
        }

        public void Insert(string key, Guid guid)
        {
            var document = new ChangeDataSetCaptureStoreEntity()
                {
                    Key = key,
                    Hash = guid
                };

            var collection = GetCollection<ChangeDataSetCaptureStoreEntity>();
            collection.Insert(document);
            //return document;
        }

        public IDictionary<string, Guid> FindByKey(string key)
        {
            var collection = GetCollection<ChangeDataSetCaptureStoreEntity>();
            var resval = collection.AsQueryable<ChangeDataSetCaptureStoreEntity>().FirstOrDefault(x => x.Key == key);
            if (resval == null) return null;
            var retval = new Dictionary<string, Guid> {{resval.Key, resval.Hash}};
            return retval;

        }

        public IQueryable<IChangeDataSetCaptureStoreEntity> SearchFor(Expression<Func<IChangeDataSetCaptureStoreEntity, bool>> predicate)
        {
            var collection = GetCollection<ChangeDataSetCaptureStoreEntity>();
            return collection.AsQueryable<IChangeDataSetCaptureStoreEntity>().Where(predicate);
        }

        //public IChangeDataSetCaptureStoreEntity FindByKey(string key)
        //{
        //    var collection = GetCollection<ChangeDataSetCaptureStoreEntity>();
        //    return collection.AsQueryable<ChangeDataSetCaptureStoreEntity>().FirstOrDefault(x => x.Key == key);
        //}

        private MongoCollection GetCollection<T>()
        {
            if (!_collections.ContainsKey(typeof(T)))
            {
                var pluralizer = PluralizationService.CreateService(new CultureInfo("en-GB"));
                //_collections.TryAdd(typeof(T), _database.GetCollection<T>(pluralizer.Pluralize(typeof(T).Name)));
                _collections.TryAdd(typeof(T), _database.GetCollection<T>(pluralizer.Pluralize(_collectionName)));
            }

            return _collections[typeof(T)];
        }
    }
}
