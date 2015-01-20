using System.Collections.Generic;

namespace R.ChangeDataSetCapture.Interfaces
{
    public interface IPersistenceStore
    {
        void Insert(string key, string guid);
        void Update(string key, string guid);
        IDictionary<string, string> FindByKey(string key);
    }
}
