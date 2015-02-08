using System;

namespace DataSetChangeDetectionPatterns.Interfaces.Entities
{
    public interface IChangingStatusContractEntity
    {        
        Guid Id { get; set; }
        string Key { get; set; }
        object Value { get; set; }
    }
}
