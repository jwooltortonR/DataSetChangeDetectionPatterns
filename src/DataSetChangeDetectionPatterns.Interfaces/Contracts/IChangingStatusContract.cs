using System.Collections.Generic;

namespace DataSetChangeDetectionPatterns.Interfaces.Contracts
{
    public interface IChangingStatusContract
    {
        string KeyColumnName { get; set; }
        IList<string> ChangeColumns { get; set; }
        string CollectionName { get; set; }
    }
}
