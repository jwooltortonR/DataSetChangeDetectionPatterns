namespace R.ChangeDataSetCapture.Interfaces.Contracts
{
    public interface IFullTableStoreContract
    {
        string KeyExpression { get; set; }
        string CollectionName { get; set; }
    }
}
