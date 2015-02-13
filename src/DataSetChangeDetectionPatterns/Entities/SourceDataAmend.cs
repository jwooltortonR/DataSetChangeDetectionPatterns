using System;

namespace DataSetChangeDetectionPatterns.Entities
{
    public class SourceDataAmend
    {
        //public BsonObjectId _id { get; set; }
        public string Key { get; set; }
        public string DataSource { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public string PreviousValue { get; set; }
        public string CurrentValue { get; set; }
        public DateTime SaveDate { get; set; }
    }
}
