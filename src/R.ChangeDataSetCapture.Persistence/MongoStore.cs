using System;
using System.Collections.Concurrent;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Persistence.Model;

namespace R.ChangeDataSetCapture.Persistence
{
    /// <summary>
    /// Mongo implementation of <see cref="IPersistenceStore"/>
    /// </summary>
    public class MongoStore : IPersistenceStore<ChangeDataSetCaptureStoreEntity>
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

        public ChangeDataSetCaptureStoreEntity Insert(ChangeDataSetCaptureStoreEntity docment)
        {
            var collection = GetCollection<ChangeDataSetCaptureStoreEntity>();
            collection.Insert(docment);
            return docment;
        }

        public IQueryable<ChangeDataSetCaptureStoreEntity> SearchFor(Expression<Func<ChangeDataSetCaptureStoreEntity, bool>> predicate)
        {
            var collection = GetCollection<ChangeDataSetCaptureStoreEntity>();
            return collection.AsQueryable<ChangeDataSetCaptureStoreEntity>().Where(predicate);
        }

        public ChangeDataSetCaptureStoreEntity GetByKey(string key)
        {
            var collection = GetCollection<ChangeDataSetCaptureStoreEntity>();
            return collection.AsQueryable<ChangeDataSetCaptureStoreEntity>().FirstOrDefault(x=>x.Key == key);
        }

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
