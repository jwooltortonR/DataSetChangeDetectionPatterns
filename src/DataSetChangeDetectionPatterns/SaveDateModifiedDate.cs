using System.Data;
using DataSetChangeDetectionPatterns.Interfaces;
using DataSetChangeDetectionPatterns.Interfaces.Contracts;

namespace DataSetChangeDetectionPatterns
{
    public class SaveDateModifiedDate : IChangeDetectionStrategy<ISaveDateModifiedDateContract>
    {
        public SaveDateModifiedDate()
        {
            
        }

        public bool Process(DataTable dataTable, ISaveDateModifiedDateContract contract)
        {
            throw new System.NotImplementedException();
        }
    }
}
