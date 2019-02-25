using System;
using OIT.Core.Model;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace OIT.Core.DataAccess.Abstract
{
    public interface IRepository<T> where T : BaseDomain, new()
    {
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeList);

        T Get(Expression<Func<T, bool>> filter, params string[] includeList);

        T GetById(int id, params string[] includeList);

        T Insert(T entity);

        T Update(T entity);

        void Delete(T entity);

        void Delete(int id);
    }
}