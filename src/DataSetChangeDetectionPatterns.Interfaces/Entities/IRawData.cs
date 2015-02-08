using System;

namespace DataSetChangeDetectionPatterns.Interfaces.Entities
{
    public interface IRawData
    {
        Guid Id { get; set; }
        string Key { get; set; }
        string Name { get; set; }
        string Value { get; set; }
        DateTime ValidFrom { get; set; }
        DateTime ValidTo { get; set; }
    }
}
