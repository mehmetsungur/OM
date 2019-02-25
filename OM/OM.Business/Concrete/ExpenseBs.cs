using OM.Entity.Domain;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;

namespace OM.Business.Concrete
{
    public class ExpenseBs : BusinessBase<Expense>, IExpenseBs
    {
        private readonly IExpenseRepo _repo;
        public ExpenseBs(IExpenseRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}