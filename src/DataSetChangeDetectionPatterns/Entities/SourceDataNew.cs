using System;

namespace DataSetChangeDetectionPatterns.Entities
{
    public class SourceDataNew
    {
        // public BsonObjectId _id { get; set; }
        public string Key { get; set; }
        public string DataSource { get; set; }
        public string DataType { get; set; }
        public DateTime SaveDate { get; set; }    
    }

}
