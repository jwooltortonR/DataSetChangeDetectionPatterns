using System.Collections.Generic;
using DataSetChangeDetectionPatterns.Interfaces.Persistence;

namespace DataSetChangeDetectionPatterns.Interfaces
{
    public interface IChangingStatusConfiguration<T, U> 
    {
        IPersistenceStore<T> PersistenceStore { get; set; }
        INotificationStrategy<U> NotificationStrategy { get; set; }
        string TableKeyColumnName { get; set; }
        IList<string> ColumnList { get; set; }
        string PersistenceStoreCollectionName { get; set; }

    }
}
