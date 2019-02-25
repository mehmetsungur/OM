using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class CategoryMap : MapBase<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Category", @"dbo");

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.TopCategoryId)
                .HasColumnName("TopCategoryId")
                .HasColumnType("int")
                .IsOptional();

            HasOptional(x => x.TopCategory)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.TopCategoryId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Products)
                .WithOptional(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}