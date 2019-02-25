using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ProductMap : MapBase<Product>
    {
        public ProductMap()
        {
            ToTable(@"Product", @"dbo");

            Property(x => x.Serial)
                .HasColumnName("Serial")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.BrandName)
                .HasColumnName("BrandName")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Model)
               .HasColumnName("Model")
               .HasColumnType("nvarchar")
               .HasMaxLength(100)
               .IsRequired();

            Property(x => x.State)
              .HasColumnName("State")
              .HasColumnType("nvarchar")
              .HasMaxLength(100)
              .IsRequired();

            Property(x => x.Periodic)
              .HasColumnName("Periodic")
              .HasColumnType("nvarchar")
              .HasMaxLength(100)
              .IsRequired();

            Property(x => x.WorkHeight)
              .HasColumnName("WorkHeight")
              .HasColumnType("nvarchar")
              .HasMaxLength(50)
              .IsRequired();
            
            Property(x => x.WorkCapacity)
              .HasColumnName("WorkCapacity")
              .HasColumnType("nvarchar")
              .HasMaxLength(50)
              .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();
            
            Property(x => x.CategoryId)
              .HasColumnName("CategoryId")
              .HasColumnType("int")
              .IsOptional();

            Property(x => x.WorkId)
              .HasColumnName("WorkId")
              .HasColumnType("int")
              .IsOptional();
        }
    }
}