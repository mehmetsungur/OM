using OM.Business.Abstract;
using OM.DataAccess.Abstract;
using OM.Entity.Domain;

namespace OM.Business.Concrete
{
    public class TaskBs : BusinessBase<Task>, ITaskBs
    {
        private readonly ITaskRepo _repo;
        public TaskBs(ITaskRepo repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}