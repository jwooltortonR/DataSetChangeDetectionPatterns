using System;
using DataSetChangeDetectionPatterns.Interfaces.Entities;

namespace DataSetChangeDetectionPatterns.Entities
{
    public class ChangingStatusContractEntity : IChangingStatusContractEntity
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
