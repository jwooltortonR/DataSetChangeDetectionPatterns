using System;
using DataSetChangeDetectionPatterns.Interfaces.Entities;

namespace DataSetChangeDetectionPatterns.Entities
{
    public class RawData : IRawData
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
