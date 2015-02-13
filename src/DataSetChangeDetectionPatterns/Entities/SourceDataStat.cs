using System;

namespace DataSetChangeDetectionPatterns.Entities
{
    public class SourceDataStat
    {
        public DateTime Date { get; set; }
        public string DataSource { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public string Stat { get; set; }
        public double Value { get; set; }
    }
}
