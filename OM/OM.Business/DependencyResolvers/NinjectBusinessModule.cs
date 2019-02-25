using Ninject.Modules;
using OM.Business.Concrete;
using OM.Business.Abstract;
using OM.DataAccess.Abstract;
using OM.DataAccess.Concrete.EntityFramework.Repositories;

namespace OM.Business.DependencyResolvers
{
    public class NinjectBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITaskBs>().To<TaskBs>();
            Bind<ITaskRepo>().To<EfTaskRepo>();

            Bind<ICategoryBs>().To<CategoryBs>();
            Bind<ICategoryRepo>().To<EfCategoryRepo>();

            Bind<ICompanyBs>().To<CompanyBs>();
            Bind<ICompanyRepo>().To<EfCompanyRepo>();

            Bind<ICustomerBs>().To<CustomerBs>();
            Bind<ICustomerRepo>().To<EfCustomerRepo>();

            Bind<IMeetBs>().To<MeetBs>();
            Bind<IMeetRepo>().To<EfMeetRepo>();

            Bind<IProductBs>().To<ProductBs>();
            Bind<IProductRepo>().To<EfProductRepo>();

            Bind<IRoleBs>().To<RoleBs>();
            Bind<IRoleRepo>().To<EfRoleRepo>();

            Bind<IUserBs>().To<UserBs>();
            Bind<IUserRepo>().To<EfUserRepo>();
                       
            Bind<IWorkBs>().To<WorkBs>();
            Bind<IWorkRepo>().To<EfWorkRepo>();

            Bind<IExpenseBs>().To<ExpenseBs>();
            Bind<IExpenseRepo>().To<EfExpenseRepo>();
        }
    }
}