using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace OM.Business.Abstract
{
    public interface IBusinessBase<TEntity>
    {
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList);

        TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList);

        TEntity GetById(int id, params string[] includeList);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);
    }
}