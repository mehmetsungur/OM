using OIT.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OM.DataAccess.Concrete.EntityFramework.Mapping
{
    public class MapBase<T> : EntityTypeConfiguration<T> where T : BaseDomain
    {
        public MapBase()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Created)
                .HasColumnName("Created")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Modified)
                .HasColumnName("Modified")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}