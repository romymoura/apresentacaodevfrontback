using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Apresentacao.Domain.Interfaces.Base
{
    public interface IBaseCrud<T>
    {
        void Insert(T entity);
        T Read(Expression<Func<T, bool>> predicate);
        ICollection<T> Read();
        void Update(T entity);
        void Update(Expression<Func<T, bool>> predicate);
        void Delete(T entiity);
        void Delete(Expression<Func<T, bool>> predicate);
    }
}
