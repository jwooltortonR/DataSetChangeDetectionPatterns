using System;

namespace R.ChangeDataSetCapture.Interfaces.Contracts
{
    public interface ISaveDateModifiedDateContract
    {
        DateTime SaveDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
