using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class UserMap : MapBase<User>
    {
        public UserMap()
        {
            ToTable(@"User", @"dbo");

            Property(x => x.FName)
                .HasColumnName("FName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.LName)
                .HasColumnName("LName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.FullName)
                .HasColumnName("FullName")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();
            
            Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Photo)
                .HasColumnName("Photo")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            Property(x => x.RoleId)
               .HasColumnName("RoleId")
               .HasColumnType("int")
               .IsOptional();

            HasMany(x => x.Tasks)
                .WithOptional(y => y.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}