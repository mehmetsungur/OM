using OM.Business.Abstract;
using OM.DataAccess.Abstract;
using OM.Entity.Domain;

namespace OM.Business.Concrete
{
    public class CategoryBs : BusinessBase<Category>, ICategoryBs
    {
        private readonly ICategoryRepo _repo;
        public CategoryBs(ICategoryRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}