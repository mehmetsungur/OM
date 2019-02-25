using OM.Entity.Domain;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class TaskMap : MapBase<Task>
    {
        public TaskMap()
        {
            ToTable(@"Task", @"dbo");

            Property(x => x.FromAss)
                .HasColumnName("FromAss")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.ToAss)
                .HasColumnName("ToAss")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("bit")
                .IsOptional();

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.UserId)
               .HasColumnName("UserId")
               .HasColumnType("int")
               .IsOptional();
        }
    }
}