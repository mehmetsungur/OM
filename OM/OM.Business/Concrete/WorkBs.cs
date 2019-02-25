using OM.Entity.Domain;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class WorkBs : BusinessBase<Work>, IWorkBs
    {
        private readonly IWorkRepo _repo;
        public WorkBs(IWorkRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}