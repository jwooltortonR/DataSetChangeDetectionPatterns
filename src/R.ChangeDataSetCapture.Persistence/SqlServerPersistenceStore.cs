using System;
using System.Collections.Generic;
using R.ChangeDataSetCapture.Interfaces;

namespace R.ChangeDataSetCapture.Persistence
{
    public class SqlServerPersistenceStore : IPersistenceStore
    {
        public void Insert(string collection, string key, string guid)
        {
            throw new NotImplementedException();
        }

        public void Update(string collection, string key, string guid)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> FindByKey(string collection, string key)
        {
            throw new NotImplementedException();
        }
    }
}
