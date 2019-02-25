using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class WorkMap : MapBase<Work>
    {
        public WorkMap()
        {
            ToTable(@"Work", @"dbo");

            Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.BillDate)
                .HasColumnName("BillDate")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.BillNumber)
                .HasColumnName("BillNumber")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Model)
                .HasColumnName("Model")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("money")
                .IsRequired();

            Property(x => x.IsPay)
                .HasColumnName("IsPay")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.Personnel)
                .HasColumnName("Personnel")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.WorkTypeId)
                .HasColumnName("WorkTypeId")
                .HasColumnType("int")
                .IsOptional();

            Property(x => x.CompanyId)
                .HasColumnName("CompanyId")
                .HasColumnType("int")
                .IsOptional();

            HasMany(x => x.Products)
                .WithOptional(y => y.Work)
                .HasForeignKey(x => x.WorkId)
                .WillCascadeOnDelete(false);
        }
    }
}