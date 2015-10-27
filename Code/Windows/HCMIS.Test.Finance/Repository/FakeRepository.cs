using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using EntityFramework.Patterns;


namespace HCMIS.Test.Finance
{
    class FakeRepository<T> : IRepository<T> where T : class
    {
        Dictionary<int, T> list = new Dictionary<int,T>();

       
        public IQueryable<T> AsQueryable()
        {
            return list.Values.AsQueryable();
        }

        public void Delete(T entity)
        {
            var property = entity.GetType().GetProperty("ID");
            int id = Convert.ToInt32(property.GetValue(entity, null));
            list.Remove(id);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> where, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            return this.AsQueryable().Where(where);
        }

        public T First(System.Linq.Expressions.Expression<Func<T, bool>> where, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            return this.Find(where, includeProperties).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            return list.Values;
        }

        public void Insert(T entity)
        {
            PropertyInfo property = entity.GetType().GetProperty("ID");
            var id = list.Count + 1;
            property.SetValue(entity, Convert.ChangeType(id,property.PropertyType),null);
            list.Add(list.Count+1,entity);
        }

        public T Single(System.Linq.Expressions.Expression<Func<T, bool>> where, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            return this.AsQueryable().Single(where);
        }

        public void Update(T entity)
        {
            var property = entity.GetType().GetProperty("ID");
            int id = Convert.ToInt32(property.GetValue(entity,null));
            list[id] = entity;
        }
    }
}
