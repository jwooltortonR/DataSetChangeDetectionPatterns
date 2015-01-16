using System;
using R.ChangeDataSetCapture.Interfaces.Entities;

namespace R.ChangeDataSetCapture.Persistence.Model
{
    public class ChangeDataSetCaptureStoreEntity : IChangeDataSetCaptureStoreEntity
    {
        public string Key { get; set; }
        public Guid Hash { get; set; }
    }
}
