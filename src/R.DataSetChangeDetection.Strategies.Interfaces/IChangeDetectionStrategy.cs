using System.Data;

namespace R.DataSetChangeDetection.Strategies.Interfaces
{
    public interface IChangeDetectionStrategy<in T>
    {
        bool Process(DataTable dataTable, T contract);
    }
}
