using System.Data;

namespace R.ChangeDataSetCapture.Interfaces
{
    public interface INotifier
    {
        void Insert(DataRow dataRow);
        void Amend(DataRow dataRow);
        void Cancel(DataRow dataRow);
    }
}
