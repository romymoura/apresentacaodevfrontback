using Apresentacao.Domain.Interfaces;
using Apresentacao.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Apresentacao.Domain.Services
{
    public abstract class BaseApplicationService<T> : IBaseApplicationService<T>
    {
        protected readonly IBaseCrudApplicationRepository<T> Repository;
        public BaseApplicationService(IBaseCrudApplicationRepository<T> repository)
        {
            Repository = repository;
        }
        public void Delete(T entiity)
        {
            Repository.Delete(entiity);
        }
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            Repository.Delete(predicate);
        }
        public void Insert(T entity)
        {
            Repository.Insert(entity);
        }
        public T Read(Expression<Func<T, bool>> predicate)
        {
            return Repository.Read(predicate);
        }
        public ICollection<T> Read()
        {
            return Repository.Read();
        }
        public void Update(T entity)
        {
            Repository.Update(entity);
        }
        public void Update(Expression<Func<T, bool>> predicate)
        {
            Repository.Update(predicate);
        }
    }
}
