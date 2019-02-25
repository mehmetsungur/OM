using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class CompanyMap : MapBase<Company>
    {
        public CompanyMap()
        {
            ToTable(@"Company", @"dbo");

            Property(x => x.Logo)
                .HasColumnName("Logo")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();
            
            Property(x => x.District)
                .HasColumnName("District")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();
            
            Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();
            
            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.Description)
               .HasColumnName("Description")
               .HasColumnType("nvarchar")
               .IsMaxLength()
               .IsOptional();

            HasMany(x => x.Meets)
                .WithOptional(y => y.Company)
                .HasForeignKey(x => x.CompanyId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Works)
                .WithOptional(y => y.Company)
                .HasForeignKey(x => x.CompanyId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Customers)
                .WithOptional(y => y.Company)
                .HasForeignKey(x => x.CompanyId)
                .WillCascadeOnDelete(false);
        }
    }
}