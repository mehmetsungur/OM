using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class RoleMap : MapBase<Role>
    {
        public RoleMap()
        {
            ToTable(@"Role", @"dbo");

            Property(x => x.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(50)
                    .IsRequired();

            HasMany(x => x.Users)
                .WithOptional(y => y.Role)
                .HasForeignKey(x => x.RoleId)
                .WillCascadeOnDelete(false);
        }
    }
}