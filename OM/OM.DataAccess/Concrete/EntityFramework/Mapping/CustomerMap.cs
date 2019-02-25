using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class CustomerMap : MapBase<Customer>
    {
        public CustomerMap()
        {
            ToTable(@"Customer", @"dbo");

            Property(x => x.CompanyName)
               .HasColumnName("CompanyName")
               .HasColumnType("nvarchar")
               .IsMaxLength()
               .IsRequired();

            Property(x => x.Contact)
               .HasColumnName("Contact")
               .HasColumnType("nvarchar")
               .HasMaxLength(100)
               .IsRequired();

            Property(x => x.Caption)
               .HasColumnName("Caption")
               .HasColumnType("nvarchar")
               .HasMaxLength(50)
               .IsRequired();

            Property(x => x.City)
               .HasColumnName("City")
               .HasColumnType("nvarchar")
               .HasMaxLength(50)
               .IsRequired();


            Property(x => x.District)
               .HasColumnName("District")
               .HasColumnType("nvarchar")
               .HasMaxLength(50)
               .IsRequired();

            Property(x => x.Phone)
               .HasColumnName("Phone")
               .HasColumnType("nvarchar")
               .HasMaxLength(50)
               .IsRequired();

            Property(x => x.Email)
               .HasColumnName("Email")
               .HasColumnType("nvarchar")
               .HasMaxLength(50)
               .IsRequired();
            
            Property(x => x.Description)
               .HasColumnName("Description")
               .HasColumnType("nvarchar")
               .IsMaxLength()
               .IsOptional();

            Property(x => x.CompanyId)
               .HasColumnName("CompanyId")
               .HasColumnType("int")
               .IsOptional();
        }
    }
}