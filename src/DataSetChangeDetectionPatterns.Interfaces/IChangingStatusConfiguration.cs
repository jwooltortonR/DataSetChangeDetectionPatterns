using System.Collections.Generic;
using DataSetChangeDetectionPatterns.Interfaces.Persistence;
using DataSetChangeDetectionPatterns.Interfaces.Strategies;

namespace DataSetChangeDetectionPatterns.Interfaces
{
    public interface IChangingStatusConfiguration<T> 
    {
        IPersistenceStore<T> PersistenceStore { get; set; }
        INotificationStrategy NotificationStrategy { get; set; }
        string TableKeyColumnName { get; set; }
        IList<string> ColumnList { get; set; }
        string PersistenceStoreCollectionName { get; set; }

    }
}
