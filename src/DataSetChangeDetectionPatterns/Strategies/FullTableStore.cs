using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataSetChangeDetectionPatterns.Entities;
using DataSetChangeDetectionPatterns.Interfaces;

namespace DataSetChangeDetectionPatterns.Strategies
{
    public class FullTableStore //: IChangeDetectionStrategy<FullTableStoreContract>
    {
        private readonly IChangingStatusConfiguration<RawData, IList<RawData>> _config;

        private string configKeyExpression;
        private string configCollectionName;

        public FullTableStore(IChangingStatusConfiguration<RawData, IList<RawData>> config)
        {
            _config = config;
        }

        public void Execute(string sql, string datasource, string dataTableName)
        {
            var start = DateTime.Now;
            // _logger.Info(string.Format("{0} Start Time:{1}", dataTableName, start));

            //var server = MongoServer.Create(_configurationManager.AppSettings["MongoDbConnectionString"].Value);
            //var db = server.GetDatabase(datasource);
            //var sddb = server.GetDatabase("SourceData");

            //var sourceDataCollection = _config.PersistenceStore.Find()

            //var sourceDataCollection = db.GetCollection<SourceData>(dataTableName);
            //var sourceDataNewCollection = sddb.GetCollection<SourceDataNew>("SourceDataNew");
            //var sourceDataAmendCollection = sddb.GetCollection<SourceDataAmend>("SourceDataAmend");

            //var dbh = new DbHelper(_configurationManager, "Database");
            //System.Data.Common.DbCommand cmd = dbh.GetSqlStringCommand(sql);
            //System.Data.Common.DbDataReader reader = dbh.ExecuteReader(cmd);

            ////var objects = new List<object>();
            //if (reader.HasRows)
            //{
            //    int rowCounter = 1;
            //    while (reader.Read())
            //    {
            //        var columnKey = reader["key"].ToString();
            //        var mongoQuery = Query<SourceData>.Where(w => w._id == columnKey);
            //        var results = sourceDataCollection.FindOne(mongoQuery);
            //        //var nv = new Dictionary<string, string>();
            //        if (results == null)
            //        {
            //            var sourceData = new SourceData { _id = columnKey, ScanDate = start };
            //            var currentData = new List<CurrentData>();
            //            for (var i = 0; i < reader.FieldCount; i++)
            //            {
            //                if (reader.GetName(i) != "KEY")
            //                {
            //                    currentData.Add(new CurrentData() { Name = reader.GetName(i), Value = reader.GetValue(i).ToString(), ValidFrom = start });
            //                }
            //            }
            //            sourceData.CurrentData = currentData;
            //            sourceDataCollection.Insert(sourceData);
            //            sourceDataNewCollection.Insert(new SourceDataNew() { Key = sourceData._id, DataSource = datasource, DataType = dataTableName, SaveDate = start });
            //            //ConvertCurrenty
            //            _logger.Info(string.Format("New: {0}", columnKey));
            //        }
            //        else
            //        {
            //            var amended = false;
            //            for (var i = 0; i < reader.FieldCount; i++)
            //            {
            //                if (reader.GetName(i) != "KEY")
            //                {
            //                    var value = reader.GetValue(i).ToString();
            //                    var name = reader.GetName(i);

            //                    var currentDatas = results.CurrentData.Where(w => w.Name == name);
            //                    if (!currentDatas.Any())
            //                    {
            //                        results.CurrentData.Add(new CurrentData() { Name = reader.GetName(i), Value = reader.GetValue(i).ToString(), ValidFrom = start });
            //                        sourceDataAmendCollection.Insert(new SourceDataAmend() { Key = columnKey, DataSource = datasource, DataType = dataTableName, SaveDate = start, Name = name, CurrentValue = value, PreviousValue = "" });
            //                        amended = true;
            //                    }
            //                    else if (currentDatas.Select(s => s.Value).First() != value)
            //                    {
            //                        var currentData = currentDatas.First();
            //                        var historicData = new HistoricData()
            //                        {
            //                            Name = currentData.Name,
            //                            Value = currentData.Value,
            //                            ValidFrom = currentData.ValidFrom,
            //                            ValidTo = start
            //                        };
            //                        if (results.HistoricData == null)
            //                            results.HistoricData = new List<HistoricData>();
            //                        results.HistoricData.Add(historicData);
            //                        sourceDataAmendCollection.Insert(new SourceDataAmend()
            //                        {
            //                            Key = columnKey,
            //                            DataSource = datasource,
            //                            DataType = dataTableName,
            //                            SaveDate = start,
            //                            Name = name,
            //                            CurrentValue = value,
            //                            PreviousValue = currentData.Value
            //                        });
            //                        results.CurrentData.First(w => w.Name == name).Value = value;
            //                        amended = true;
            //                    }
            //                }
            //            }
            //            results.ScanDate = start;
            //            sourceDataCollection.Save(results);
            //            if (amended)
            //            {
            //                //ConvertAmend()
            //                //_notificationStrategy.Amend();
            //                _logger.Info(string.Format("Amended: {0}", columnKey));
            //            }
            //        }
            //        rowCounter++;
            //    }
            //}
            //else
            //{
            //    //_logger.Info("No rows found.");
            //}
            //reader.Close();
            //dbh.Dispose();
            //_logger.Info(string.Format("Done! : {0}", DateTime.Now - start));
        }

        //public bool Process()
        //{
        //    //var start = DateTime.Now;
            
        //    //for (var j = 0; j < dataTable.Columns.Count; j++)
        //    //{
        //    //    dataTable.Columns[j].ColumnName = dataTable.Rows[0][j].ToString();
        //    //}
        //    //dataTable.Rows[0].Delete();

        //    ////Add extra Column
        //    //var dataColumn = new DataColumn
        //    //    {
        //    //        ColumnName = "Key",
        //    //        Expression = configKeyExpression,
        //    //        DataType = Type.GetType("System.String")
        //    //    };
        //    //dataTable.Columns.Add(dataColumn);
            
        //    //foreach (DataRow dr in dataTable.Rows)
        //    //{
        //    //    var key = dr["key"].ToString();
        //    //    var lookup = _config.PersistenceStore.FindOne(configCollectionName, x => x.Key == key);

        //    //    if (lookup == null)
        //    //    {
        //    //        foreach (DataColumn c in dataTable.Columns)
        //    //        {                        
        //    //            var rawDataEntity = new RawData
        //    //                {
        //    //                    Key = key,
        //    //                    Name = c.ColumnName,
        //    //                    Value = dr[c.ColumnName].ToString(),
        //    //                    ValidFrom = start,
        //    //                    ValidTo = DateTime.MaxValue
        //    //                };
        //    //            _config.PersistenceStore.Insert(configCollectionName, rawDataEntity);    
                      
        //    //        }
        //    //        _config.NotificationStrategy.Insert(rawDataEntity);                  
        //    //    }
        //    //    else
        //    //    {
        //    //        var r1 = _config.PersistenceStore.Find(configCollectionName, data => data.Key == key && data.ValidTo > start).ToList();

        //    //        foreach (DataColumn c in dataTable.Columns)
        //    //        {
        //    //            var value = dr[c.ColumnName].ToString();
        //    //            var name = c.ColumnName;

        //    //            if (!r1.Where(w => w.Name == name).Any())
        //    //            {
        //    //                var rd = new RawData
        //    //                    {
        //    //                        Key = key,
        //    //                        Name = name,
        //    //                        Value = value,
        //    //                        ValidFrom = start,
        //    //                        ValidTo = DateTime.MaxValue
        //    //                    };
        //    //                _config.PersistenceStore.Insert(configCollectionName, rd);                                                        
        //    //            }
        //    //            else if (r1.First(w => w.Name == name).Value != value)
        //    //            {
        //    //                var first = r1.Where(w => w.Name == name).First();
        //    //                first.ValidTo = start;
                                                        
        //    //                var rd = new RawData
        //    //                    {
        //    //                        Key = key,
        //    //                        Name = name,
        //    //                        Value = value,
        //    //                        ValidFrom = start,
        //    //                        ValidTo = DateTime.MaxValue
        //    //                    };

        //    //                _config.PersistenceStore.Update(configCollectionName, rd);

        //    //            }
        //    //            _config.NotificationStrategy.Amend(dr);
        //    //        }
        //    //    }                
        //    //}            
        //    //return true;
        //}
    }
}
