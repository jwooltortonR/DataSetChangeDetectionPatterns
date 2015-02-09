using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using DataSetChangeDetectionPatterns.Entities;
using DataSetChangeDetectionPatterns.Interfaces;
using DataSetChangeDetectionPatterns.Interfaces.Strategies;

namespace DataSetChangeDetectionPatterns.Strategies
{
    public class ChangingStatusStrategy : IChangeDetectionStrategy
    {
        private readonly IChangingStatusConfiguration<ChangingStatusContractEntity> _config;

        public ChangingStatusStrategy(IChangingStatusConfiguration<ChangingStatusContractEntity> config)
        {
            _config = config;            
        }

   

        public bool Process(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var key = dataRow[_config.TableKeyColumnName].ToString();
                if (string.IsNullOrEmpty(key)) continue;

                var hash = GetHash(_config.ColumnList, dataRow);

                var entity = _config.PersistenceStore.FindOne(_config.PersistenceStoreCollectionName, x => x.Key == key);
                if (entity == null)
                {                    
                    _config.NotificationStrategy.Insert(dataRow);
                    _config.PersistenceStore.Insert(_config.PersistenceStoreCollectionName, new ChangingStatusContractEntity { Key = key, Value = hash });
                    continue;                    
                }

                if (entity.Value.ToString() != hash)
                {
                    if (dataRow["STATUS"].Equals("CANCELLED"))
                    {
                        _config.NotificationStrategy.Cancel(dataRow);
                    }
                    else
                    {
                        _config.NotificationStrategy.Amend(dataRow);                     
                    }
                    entity.Value = hash;
                    _config.PersistenceStore.Update(_config.PersistenceStoreCollectionName, entity);                        
                }
                else
                {
                    _config.NotificationStrategy.NoChange(dataRow);
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
