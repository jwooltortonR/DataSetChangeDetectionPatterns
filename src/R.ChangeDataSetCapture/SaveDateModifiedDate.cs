using System.Data;
using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Interfaces.Contracts;
using R.DataSetChangeDetection.Strategies.Interfaces;

namespace R.DataSetChangeDetection.Strategies
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
