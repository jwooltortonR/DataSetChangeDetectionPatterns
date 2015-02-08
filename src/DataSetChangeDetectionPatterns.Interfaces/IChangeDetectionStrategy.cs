using System.Data;

namespace DataSetChangeDetectionPatterns.Interfaces
{
    public interface IChangeDetectionStrategy<in T>
    {
        bool Process(DataTable dataTable, T contract);
    }
}
