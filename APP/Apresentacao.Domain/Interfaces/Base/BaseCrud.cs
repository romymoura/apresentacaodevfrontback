using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Apresentacao.Domain.Interfaces.Base
{
    public abstract class BaseCrud<T> : IBaseCrud<T>
    {
        public void Delete(T entiity)
        {
            
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T Read(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
