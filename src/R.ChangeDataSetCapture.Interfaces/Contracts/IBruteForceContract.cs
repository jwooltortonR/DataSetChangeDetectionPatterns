using System.Collections.Generic;

namespace R.ChangeDataSetCapture.Interfaces.Contracts
{
    public interface IBruteForceContract
    {
        string KeyColumnName { get; set; }
        IList<string> ChangeColumns { get; set; }
        string CollectionName { get; set; }
    }
}
