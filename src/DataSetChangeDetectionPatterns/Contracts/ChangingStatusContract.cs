using System.Collections.Generic;
using DataSetChangeDetectionPatterns.Interfaces.Contracts;

namespace DataSetChangeDetectionPatterns.Contracts
{
    public class ChangingStatusContract : IChangingStatusContract
    {
        public string KeyColumnName { get; set; }
        public IList<string> ChangeColumns { get; set; }
        public string CollectionName { get; set; }
    }
}
