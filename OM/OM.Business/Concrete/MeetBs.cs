using OM.Entity.Domain;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class MeetBs : BusinessBase<Meet>, IMeetBs
    {
        private readonly IMeetRepo _repo;
        public MeetBs(IMeetRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}