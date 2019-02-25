using System;
using System.Linq;
using OIT.Core.Model;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using OIT.Core.DataAccess.Abstract;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfRepositoryBase<TContext, TEntity> : IRepository<TEntity>
        where TEntity : BaseDomain, new()
        where TContext : DbContext, new()
    {

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> query = ctx.Set<TEntity>();

                if (includeList != null)
                {
                    for (int i = 0; i < includeList.Length; i++)
                    {
                        query = query.Include(includeList[i]);
                    }
                }

                return query.SingleOrDefault(filter);
            }
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> query = filter == null
                    ? ctx.Set<TEntity>()
                    : ctx.Set<TEntity>().Where(filter);

                if (includeList != null)
                {
                    for (int i = 0; i < includeList.Length; i++)
                    {
                        query = query.Include(includeList[i]);
                    }
                }

                return query.ToList();
            }
        }

        public TEntity Insert(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                TEntity addedEntity = ctx.Set<TEntity>().Add(entity);
                ctx.SaveChanges();

                return addedEntity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<TEntity>().Attach(entity);
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();

                return entity;
            }
        }

        public void Delete(int id)
        {
            using (TContext ctx = new TContext())
            {
                TEntity entity = this.Get(x => x.Id == id);
                this.Update(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                if (ctx.Entry(entity).State == EntityState.Detached)
                    ctx.Set<TEntity>().Attach(entity);

                ctx.Set<TEntity>().Remove(entity);
                ctx.SaveChanges();
            }
        }

        public TEntity GetById(int id, params string[] includeList)
        {
            return Get(x => x.Id == id, includeList);
        }
    }
}