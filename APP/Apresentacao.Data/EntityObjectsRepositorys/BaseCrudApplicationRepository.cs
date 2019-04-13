using Apresentacao.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Apresentacao.Data.EntityObjectsRepositorys
{
    public abstract class BaseCrudApplicationRepository<T> : ApplicationDbContextBase, IBaseCrudApplicationRepository<T> where T : class, new()
    {
        public BaseCrudApplicationRepository(ApplicationDbContext context) : base(context) { }

        public void Insert(T entity)
        {
            Context.Add<T>(entity);
            Context.SaveChanges();
        }

        public ICollection<T> Read()
        {
            return Context.Set<T>().ToList();
        }
        public T Read(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Update(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public void Update(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entiity)
        {
            Context.Remove(entiity);
            Context.SaveChanges();
        }
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var entity = Context.Set<T>().Where(predicate).FirstOrDefault();
            if (entity == null) return;
            Context.Remove(entity);
            Context.SaveChanges();
        }
    }
}
