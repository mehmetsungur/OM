using OM.Entity.Domain;
using OM.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using OM.DataAccess.Concrete.EntityFramework.Context;

namespace OM.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfProductRepo : EfRepositoryBase<DatabaseContext, Product>, IProductRepo
    {
    }
}