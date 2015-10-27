using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace HCMIS.Logging.Repository
{
    public abstract class GenericRepository<TContext, TEntity> : IRepository<TEntity> where TEntity : class where TContext : DbContext , new()
    {
        private TContext _entities = new TContext();

        public TContext Context
        {
            get { return this._entities; }
            set { this._entities = value; }
        }
        
        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>();
            return query;
        }

        public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>().Where(predicate);
            return query;
        }
        
        public virtual void Add(TEntity entity)
        {
            _entities.Set<TEntity>().Add(entity);
            _entities.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Set<TEntity>().Remove(entity);
            _entities.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Entry(entity).State = System.Data.EntityState.Modified;
            _entities.SaveChanges();
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
