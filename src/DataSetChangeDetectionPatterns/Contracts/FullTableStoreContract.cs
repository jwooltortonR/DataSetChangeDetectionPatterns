using DataSetChangeDetectionPatterns.Interfaces.Contracts;

namespace DataSetChangeDetectionPatterns.Contracts
{
    public class FullTableStoreContract : IFullTableStoreContract
    {
        public string KeyExpression { get; set; }
        public string CollectionName { get; set; }
    }
}
