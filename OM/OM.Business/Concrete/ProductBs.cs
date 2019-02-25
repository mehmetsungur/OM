using OM.Entity.Domain;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class ProductBs : BusinessBase<Product>, IProductBs
    {
        private readonly IProductRepo _repo;
        public ProductBs(IProductRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}