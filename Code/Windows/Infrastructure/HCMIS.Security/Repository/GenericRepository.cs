using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace HCMIS.Security.Repository
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

        public virtual void DeleteBy(System.Linq.Expressions.Expression<Func<TEntity,bool>> predicate)
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>().Where(predicate);
            foreach (var entity in query)
            {
                _entities.Set<TEntity>().Remove(entity);
            }
            _entities.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                _entities.Configuration.LazyLoadingEnabled = false;
                _entities.Entry(entity).State = System.Data.EntityState.Modified;
                _entities.SaveChanges();
                _entities.Configuration.LazyLoadingEnabled = true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
