using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
