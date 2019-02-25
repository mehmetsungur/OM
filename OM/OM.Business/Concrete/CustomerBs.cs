using OM.Entity.Domain;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class CustomerBs : BusinessBase<Customer>, ICustomerBs
    {
        private readonly ICustomerRepo _repo;
        public CustomerBs(ICustomerRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}