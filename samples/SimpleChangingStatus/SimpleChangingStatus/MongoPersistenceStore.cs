using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataSetChangeDetectionPatterns.Entities;
using DataSetChangeDetectionPatterns.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace SimpleChangingStatus
{
    public class MongoPersistenceStore : IPersistenceStore<ChangingStatusContractEntity>
    {
        private MongoDatabase _database;

        public MongoPersistenceStore(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            _database = server.GetDatabase(databaseName);

        }
        public ChangingStatusContractEntity Insert(string collectionName, ChangingStatusContractEntity entity)
        {
            var collection = _database.GetCollection<ChangingStatusContractEntity>(collectionName);
            collection.Insert(entity);
            return entity;
        }

        public ChangingStatusContractEntity Update(string collection, ChangingStatusContractEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string collection, Expression<Func<ChangingStatusContractEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ChangingStatusContractEntity FindOne(string collectionName, Expression<Func<ChangingStatusContractEntity, bool>> predicate)
        {            
            var collection = _database.GetCollection<ChangingStatusContractEntity>(collectionName);
            var resval = collection.AsQueryable().FirstOrDefault(predicate);
            return resval;
        }

        public IEnumerable<ChangingStatusContractEntity> Find(string collectionName, Expression<Func<ChangingStatusContractEntity, bool>> predicate)
        {
            var collection = _database.GetCollection<ChangingStatusContractEntity>(collectionName);
            var resval = collection.AsQueryable().Where(predicate);
            return resval;
        }
    }
}
