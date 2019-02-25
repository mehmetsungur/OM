using System;
using OIT.Core.Model;
using OM.Business.Abstract;
using System.Linq.Expressions;
using System.Collections.Generic;
using OIT.Core.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class BusinessBase<TEntity> : IBusinessBase<TEntity>
        where TEntity : BaseDomain, new()
    {
        IRepository<TEntity> _repo;

        public BusinessBase(IRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public virtual void Delete(int id)
        {
            _repo.Delete(id);
        }

        public virtual void Delete(TEntity entity)
        {
            _repo.Delete(entity);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            return _repo.Get(filter, includeList);
        }

        public virtual ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetAll(filter, includeList);
        }

        public TEntity GetById(int id, params string[] includeList)
        {
            return Get(x => x.Id == id, includeList);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            return _repo.Insert(entity);

        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repo.Update(entity);
        }
    }
}