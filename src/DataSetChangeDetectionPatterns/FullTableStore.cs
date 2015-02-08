using System;
using System.Data;
using System.Linq;
using DataSetChangeDetectionPatterns.Entities;
using DataSetChangeDetectionPatterns.Interfaces;
using DataSetChangeDetectionPatterns.Interfaces.Contracts;

namespace DataSetChangeDetectionPatterns
{
    public class FullTableStore : IChangeDetectionStrategy<IFullTableStoreContract>
    {
        private IPersistenceStore<RawData> _persistenceStore;
        private readonly INotificationStrategy _notificationStrategy;
        

        public FullTableStore(IPersistenceStore<RawData> persistenceStore, 
                              INotificationStrategy notificationStrategy)
        {
            _persistenceStore = persistenceStore;
            _notificationStrategy = notificationStrategy;        
        }

        public bool Process(DataTable dataTable, IFullTableStoreContract contract)
        {
            var start = DateTime.Now;
            
            for (var j = 0; j < dataTable.Columns.Count; j++)
            {
                dataTable.Columns[j].ColumnName = dataTable.Rows[0][j].ToString();
            }
            dataTable.Rows[0].Delete();

            //Add extra Column
            var dataColumn = new DataColumn
                {
                    ColumnName = "Key",
                    Expression = contract.KeyExpression,
                    DataType = Type.GetType("System.String")
                };
            dataTable.Columns.Add(dataColumn);
            
            foreach (DataRow dr in dataTable.Rows)
            {
                var key = dr["key"].ToString();
                var lookup = _persistenceStore.FindOne(contract.CollectionName, x=>x.Key == key);

                if (lookup == null)
                {
                    foreach (DataColumn c in dataTable.Columns)
                    {                        
                        var rawDataEntity = new RawData
                            {
                                Key = key,
                                Name = c.ColumnName,
                                Value = dr[c.ColumnName].ToString(),
                                ValidFrom = start,
                                ValidTo = DateTime.MaxValue
                            };
                        _persistenceStore.Insert(contract.CollectionName, rawDataEntity);                          
                    }
                    _notificationStrategy.Insert(dr);                      
                }
                else
                {
                    var r1 = _persistenceStore.Find(contract.CollectionName, data => data.Key == key && data.ValidTo > start).ToList();

                    foreach (DataColumn c in dataTable.Columns)
                    {
                        var value = dr[c.ColumnName].ToString();
                        var name = c.ColumnName;

                        if (!r1.Where(w => w.Name == name).Any())
                        {
                            var rd = new RawData
                                {
                                    Key = key,
                                    Name = name,
                                    Value = value,
                                    ValidFrom = start,
                                    ValidTo = DateTime.MaxValue
                                };
                            _persistenceStore.Insert(contract.CollectionName, rd);                                                        
                        }
                        else if (r1.First(w => w.Name == name).Value != value)
                        {
                            var first = r1.Where(w => w.Name == name).First();
                            first.ValidTo = start;
                                                        
                            var rd = new RawData
                                {
                                    Key = key,
                                    Name = name,
                                    Value = value,
                                    ValidFrom = start,
                                    ValidTo = DateTime.MaxValue
                                };

                            _persistenceStore.Update(contract.CollectionName, rd);

                        }
                        _notificationStrategy.Amend(dr);
                    }
                }                
            }            
            return true;
        }
    }
}
