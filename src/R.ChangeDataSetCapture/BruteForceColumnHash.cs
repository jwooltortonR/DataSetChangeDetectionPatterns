using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Interfaces.Contracts;
using R.DataSetChangeDetection.Strategies.Entities;
using R.DataSetChangeDetection.Strategies.Interfaces;

namespace R.DataSetChangeDetection.Strategies
{
    public class BruteForceColumnHash : IChangeDetectionStrategy<IBruteForceContract>
    {
        private IPersistenceStore<BruteForceEntity> _persistenceStore;
        private readonly INotificationStrategy _notificationStrategy;        

        public BruteForceColumnHash(IPersistenceStore<BruteForceEntity> persistenceStore, 
                                    INotificationStrategy notificationStrategy                                                                                   
            )
        {            
            _persistenceStore = persistenceStore;
            _notificationStrategy = notificationStrategy;            
        }

        public bool Process(DataTable dataTable, IBruteForceContract contract)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var key = dataRow[contract.KeyColumnName].ToString();
                if (string.IsNullOrEmpty(key)) continue;

                var hash = GetHash(contract.ChangeColumns, dataRow);

                var entity = _persistenceStore.FindOne(contract.CollectionName, x => x.Key == key);
                if (entity == null)
                {                    
                    _notificationStrategy.Insert(dataRow);
                    _persistenceStore.Insert(contract.CollectionName, new BruteForceEntity { Key = key, Value = hash });
                    continue;                    
                }

                if (entity.Value.ToString() != hash)
                {
                    if (dataRow["STATUS"].Equals("CANCELLED"))
                    {
                        _notificationStrategy.Cancel(dataRow);
                    }
                    else
                    {
                        _notificationStrategy.Amend(dataRow);                     
                    }
                    entity.Value = hash;                            
                    _persistenceStore.Update(contract.CollectionName, entity);                        
                }
                else
                {
                    _notificationStrategy.NoChange(dataRow);
                }
            }
            return true;
        }

        internal string GetHash(IList<string> columns, DataRow dataRow)
        {
            var s = columns.Aggregate("", (current, column) => current + dataRow[column].ToString());
            return s.GetHashCode().ToString(CultureInfo.InvariantCulture);
        }
    }
}
