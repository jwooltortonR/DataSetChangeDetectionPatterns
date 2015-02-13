using System;

namespace DataSetChangeDetectionPatterns.Entities
{
    public class HistoricData
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
