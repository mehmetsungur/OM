using OM.Entity.Domain;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class RoleBs : BusinessBase<Role>, IRoleBs
    {
        private readonly IRoleRepo _repo;
        public RoleBs(IRoleRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}