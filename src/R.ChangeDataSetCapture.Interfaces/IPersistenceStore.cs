using System;
using System.Collections.Generic;

namespace R.ChangeDataSetCapture.Interfaces
{
    public interface IPersistenceStore
    {
        void Insert(string key, Guid guid);        
        IDictionary<string, Guid> FindByKey(string key);
    }
}
