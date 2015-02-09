using System.Data;

namespace DataSetChangeDetectionPatterns.Interfaces.Strategies
{
    public interface INotificationStrategy
    {
        void Insert(DataRow dataRow);
        void Amend(DataRow dataRow);
        void Cancel(DataRow dataRow);
        void NoChange(DataRow dataRow);
    }
}
