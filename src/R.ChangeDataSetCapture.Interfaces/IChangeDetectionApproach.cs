using System.Data;

namespace R.ChangeDataSetCapture.Interfaces
{
    public interface IChangeDetectionApproach
    {
        bool Process(DataTable dataTable);
    }
}
