namespace R.ChangeDataSetCapture.ChangeDetectionApproach
{
    public interface INotificationMethod
    {
        void InsertNotification(int id);
        void AmendNotification(int id);
        void CancelNotification(int id);        
    }
}
