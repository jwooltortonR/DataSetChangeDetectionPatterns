using System.Collections.Generic;
using R.ChangeDataSetCapture.Interfaces.Contracts;

namespace R.DataSetChangeDetection.Strategies.Contracts
{
    public class BruteForceContract : IBruteForceContract
    {
        public string KeyColumnName { get; set; }
        public IList<string> ChangeColumns { get; set; }
        public string CollectionName { get; set; }
    }
}
