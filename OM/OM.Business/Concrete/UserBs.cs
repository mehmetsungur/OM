using OM.Entity.Domain;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class UserBs : BusinessBase<User>, IUserBs
    {
        private readonly IUserRepo _repo;
        public UserBs(IUserRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}