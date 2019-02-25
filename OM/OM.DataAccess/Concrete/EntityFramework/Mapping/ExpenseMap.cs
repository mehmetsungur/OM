using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ExpenseMap : MapBase<Expense>
    {
        public ExpenseMap()
        {
            ToTable(@"Expense", @"dbo");
            
            Property(x => x.Type)
                .HasColumnName("Type")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.ProcessDate)
                .HasColumnName("ProcessDate")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.Process)
                .HasColumnName("Process")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.PayDate)
                .HasColumnName("PayDate")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("money")
                .IsRequired();
        }
    }
}