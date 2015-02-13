using System.Collections.Generic;
using DataSetChangeDetectionPatterns.Interfaces;
using DataSetChangeDetectionPatterns.Interfaces.Persistence;
using DataSetChangeDetectionPatterns.Interfaces.Strategies;

namespace DataSetChangeDetectionPatterns
{
    public class ChangingStatusConfiguration<T, U> : IChangingStatusConfiguration<T, U>       
    {
        private IPersistenceStore<T> _persistenceStore;
        private INotificationStrategy<U> _notificationStrategy;
        private string _tableKeyColumnName;
        private string _persistenceStoreCollectionName = "StatusCollection";
        private IList<string> _hashColumnNames;

        public IPersistenceStore<T> PersistenceStore
        {
            get { return _persistenceStore; }
            set { _persistenceStore = value; }
        }

        public INotificationStrategy<U> NotificationStrategy
        {
            get { return _notificationStrategy; }
            set { _notificationStrategy = value; }
        }

        public string TableKeyColumnName            
        {
            get { return _tableKeyColumnName; }
            set { _tableKeyColumnName = value; }
        }

        public IList<string> ColumnList
        {
            get { return _hashColumnNames; }
            set { _hashColumnNames = value; }
        }

        public string PersistenceStoreCollectionName
        {
            get { return _persistenceStoreCollectionName; }
            set { _persistenceStoreCollectionName = value; }
        }

  
    }
}
