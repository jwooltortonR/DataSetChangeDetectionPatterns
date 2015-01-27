using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace R.DataSetChangeDetection.Strategies.Interfaces
{
    public interface IPersistenceStore<T>
    {
        T Insert(string collection, T entity);
        T Update(string collection, T entity);
        void Delete(string collection, Expression<Func<T, bool>> expression);

        T FindOne(string collection, Expression<Func<T, bool>> expression);
        IEnumerable<T> Find(string collection, Expression<Func<T, bool>> predicate);
    }
}
