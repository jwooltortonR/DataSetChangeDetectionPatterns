using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using R.ChangeDataSetCapture.Interfaces;

namespace R.ChangeDataSetCapture.ChangeDetectionApproach
{
    public class BruteForceColumHash : IChangeDetectionApproach
    {
        private readonly IPersistenceStore _persistenceStore;
        private readonly INotifier _notifier;
        //private readonly string _persistanceStoreCollectionName;
        private readonly string _keyColumnName;
        private readonly IList<string> _changeColumns;

        public BruteForceColumHash(IPersistenceStore persistenceStore, 
                                   INotifier notifier,
                                   string keyColumnName, 
                                   IList<string> changeColumns)
        {            
            _persistenceStore = persistenceStore;
            _notifier = notifier;
            //_persistanceStoreCollectionName = persistanceStoreCollectionName;
            _keyColumnName = keyColumnName;
            _changeColumns = changeColumns;
        }

        public bool Process(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var key = dataRow[_keyColumnName].ToString();
                if (string.IsNullOrEmpty(key)) continue;

                var hash = GetHash(_changeColumns, dataRow);

                var resval = _persistenceStore.FindByKey(key);
                if (resval == null)
                {
                    _notifier.Insert(dataRow);
                    _persistenceStore.Insert(key, hash);
                    continue;                    
                }

                if (resval.FirstOrDefault().Value != hash)
                {
                    _notifier.Amend(dataRow);
                    
                    continue;
                }

                //Not sure on cancel yet.
            }

            return true;
        }

        internal Guid GetHash(IList<string> columns, DataRow dataRow)
        {
            string s = "";
            foreach (var column in columns)
            {
                s += dataRow[column].ToString();
            }            
            return new Guid(s);
        }
    }
}
