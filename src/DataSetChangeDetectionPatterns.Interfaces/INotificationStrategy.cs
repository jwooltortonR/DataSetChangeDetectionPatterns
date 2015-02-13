namespace DataSetChangeDetectionPatterns.Interfaces
{
    public interface INotificationStrategy<in T>
    {
        void Insert(T document);
        void Amend(T document);
        void Cancel(T document);
        void NoChange(T document);
    }
}
