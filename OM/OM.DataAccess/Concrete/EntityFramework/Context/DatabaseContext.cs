using OM.Entity.Domain;
using System.Data.Entity;
using OM.DataAccess.Concrete.EntityFramework.Mapping;

namespace OM.DataAccess.Concrete.EntityFramework.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(null);

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Meet> Meets { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Work> Works { get; set; }
        DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new TaskMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new MeetMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new WorkMap());
            modelBuilder.Configurations.Add(new ExpenseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}