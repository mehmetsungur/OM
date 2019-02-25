using System.Linq;
using OM.Entity.Domain;
using OM.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using OM.DataAccess.Concrete.EntityFramework.Context;

namespace OM.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfUserRepo : EfRepositoryBase<DatabaseContext, User>, IUserRepo
    {
        //public List<User> GetByRoleId(int roleId)
        //{
        //    return
        //        base.GetAll(x => x.UserRoles.Select(y => y.RoleId).Contains(roleId)).ToList();
        //}
    }
}