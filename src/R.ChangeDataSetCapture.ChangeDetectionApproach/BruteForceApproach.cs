using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using R.ChangeDataSetCapture.Interfaces;

namespace R.ChangeDataSetCapture.ChangeDetectionApproach
{
    public class BruteForceApproach : IChangeDetectionApproach
    {
        private readonly IPersistenceStore _persistenceStore;
        private readonly string _persistanceStoreCollectionName;
        private readonly string _keyColumnName;
        private readonly IList<string> _changeColumns;

        public BruteForceApproach(IPersistenceStore persistenceStore, string persistanceStoreCollectionName, string keyColumnName, IList<string> changeColumns)
        {
            _persistenceStore = persistenceStore;
            _persistanceStoreCollectionName = persistanceStoreCollectionName;
            _keyColumnName = keyColumnName;
            _changeColumns = changeColumns;
        }

        public bool Process(DataTable dataTable)
        {
            foreach (var lookup in from DataRow dataRow in dataTable.Rows select dataRow[_keyColumnName])
            {
                var resval = _persistenceStore.FindByKey(lookup);
                if (resval == null)
                {
                    //It's new
                }

                var hash = GetHash();

                if (resval.hash != hash)
                {
                    
                }
            }

            return true;
        }

        internal Guid GetHash()
        {
            var s = "asdasd";
            return new Guid(s);
        }
    }
}
