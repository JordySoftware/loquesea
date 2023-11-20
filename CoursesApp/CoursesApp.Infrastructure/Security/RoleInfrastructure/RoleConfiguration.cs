using CoursesApp.Domain.Security.RoleAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Security.RoleInfrastructure
{
    internal class RoleConfiguration
    {
        internal RoleConfiguration(DbModelBuilder modelBuilder)
        {
            // Obtener entidad
            EntityTypeConfiguration<Role> entity = modelBuilder.Entity<Role>();

            // Mapear tabla y esquema
            entity.ToTable("Roles", "Security");

            // Crear atributos de tabla

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            entity.Property(p => p.Code)
                .HasColumnName("Code")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(p => p.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

            entity.Property(p => p.Status)
                .HasColumnName("Status")
                .HasColumnType("int")
                .IsRequired();

            // Crear relaciones foraneas

            entity.HasMany(p => p.Users);

            // Crear indices

            entity.HasIndex(p => p.Code).IsUnique();

            entity.HasIndex(p => p.Name).IsUnique();

            entity.HasIndex(p => p.Status);
        }
    }
}
