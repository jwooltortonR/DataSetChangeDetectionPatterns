using R.ChangeDataSetCapture.Interfaces.Contracts;

namespace R.DataSetChangeDetection.Strategies.Contracts
{
    public class FullTableStoreContract : IFullTableStoreContract
    {
        public string KeyExpression { get; set; }
        public string CollectionName { get; set; }
    }
}
