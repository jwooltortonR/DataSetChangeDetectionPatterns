using System;
using System.Linq;
using System.Linq.Expressions;

namespace R.ChangeDataSetCapture.Interfaces
{
    public interface IPersistenceStore<T>
    {
        T Insert(T document);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        T GetByKey(string key);
    }
}
