using System;
using DataSetChangeDetectionPatterns.Interfaces.Contracts;

namespace DataSetChangeDetectionPatterns.Contracts
{
    public class SaveDateModifiedDateContract : ISaveDateModifiedDateContract
    {
        public DateTime SaveDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
