using System;

namespace DataSetChangeDetectionPatterns.Interfaces.Contracts
{
    public interface ISaveDateModifiedDateContract
    {
        DateTime SaveDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
