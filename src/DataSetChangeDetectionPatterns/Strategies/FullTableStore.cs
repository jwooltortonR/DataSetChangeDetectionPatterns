using System;
using System.Data;
using System.Linq;
using DataSetChangeDetectionPatterns.Entities;
using DataSetChangeDetectionPatterns.Interfaces;

namespace DataSetChangeDetectionPatterns.Strategies
{
    public class FullTableStore //: IChangeDetectionStrategy<FullTableStoreContract>
    {
        private readonly IChangingStatusConfiguration<RawData> _config;

        private string configKeyExpression;
        private string configCollectionName;

        public FullTableStore()
        {
            
        }

        public FullTableStore(IChangingStatusConfiguration<RawData> config)
        {
            _config = config;
        }


        public bool Process(DataTable dataTable)
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
                    Expression = configKeyExpression,
                    DataType = Type.GetType("System.String")
                };
            dataTable.Columns.Add(dataColumn);
            
            foreach (DataRow dr in dataTable.Rows)
            {
                var key = dr["key"].ToString();
                var lookup = _config.PersistenceStore.FindOne(configCollectionName, x => x.Key == key);

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
                        _config.PersistenceStore.Insert(configCollectionName, rawDataEntity);                          
                    }
                    _config.NotificationStrategy.Insert(dr);                      
                }
                else
                {
                    var r1 = _config.PersistenceStore.Find(configCollectionName, data => data.Key == key && data.ValidTo > start).ToList();

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
                            _config.PersistenceStore.Insert(configCollectionName, rd);                                                        
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

                            _config.PersistenceStore.Update(configCollectionName, rd);

                        }
                        _config.NotificationStrategy.Amend(dr);
                    }
                }                
            }            
            return true;
        }
    }
}
