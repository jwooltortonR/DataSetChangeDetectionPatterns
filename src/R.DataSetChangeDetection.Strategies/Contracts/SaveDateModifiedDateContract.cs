using System;
using R.ChangeDataSetCapture.Interfaces.Contracts;

namespace R.DataSetChangeDetection.Strategies.Contracts
{
    public class SaveDateModifiedDateContract : ISaveDateModifiedDateContract
    {
        public DateTime SaveDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
