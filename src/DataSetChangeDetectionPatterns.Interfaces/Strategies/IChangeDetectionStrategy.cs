using System.Data;

namespace DataSetChangeDetectionPatterns.Interfaces.Strategies
{
    public interface IChangeDetectionStrategy
    {
        bool Process(DataTable dataTable);
    }
}
