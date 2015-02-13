using System;
using System.Collections.Generic;

namespace DataSetChangeDetectionPatterns.Entities
{
    public class SourceData
    {
        public string _id { get; set; } //Primary key for source data
        public DateTime ScanDate { get; set; } //Updated for each scanned source data - used to detect hard deletes
        public List<CurrentData> CurrentData { get; set; } //Stores only latest copy of data. Quicker to query and no need for validTo date
        public List<HistoricData> HistoricData { get; set; }  //Stores only historic data copied from CurrentData validTo date added
    }
}
