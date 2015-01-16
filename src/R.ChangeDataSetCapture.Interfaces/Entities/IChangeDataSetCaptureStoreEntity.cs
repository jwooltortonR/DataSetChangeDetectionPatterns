using System;

namespace R.ChangeDataSetCapture.Interfaces.Entities
{
    public interface IChangeDataSetCaptureStoreEntity
    {
        string Key { get; set; }
        Guid Hash { get; set; }
    }
}
