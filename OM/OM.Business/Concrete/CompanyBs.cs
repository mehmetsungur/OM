using OM.Entity.Domain;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class CompanyBs : BusinessBase<Company>, ICompanyBs
    {
        private readonly ICompanyRepo _repo;
        public CompanyBs(ICompanyRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}