using CoursesApp.Domain.Security.RoleAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Security.RoleInfrastructure;
internal class UserConfiguration
{
    internal UserConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<User> entity = modelBuilder.Entity<User>();

        // Mapear tabla y esquema
        entity.ToTable("Users", "Security");

        // Crear atributos de tabla

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.RoleId)
            .HasColumnName("RoleId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.Code)
            .HasColumnName("Code")
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(p => p.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        entity.Property(p => p.LastName)
            .HasColumnName("LastName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        entity.Property(p => p.Address.Street)
            .HasColumnName("Street")
            .HasColumnType("varchar")
            .HasMaxLength(200);

        entity.Property(p => p.Address.City)
            .HasColumnName("City")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        entity.Property(p => p.Address.State)
            .HasColumnName("State")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        entity.Property(p => p.Address.Country)
            .HasColumnName("Country")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        entity.Property(p => p.Address.ZipCode)
            .HasColumnName("ZipCode")
            .HasColumnType("varchar")
            .HasMaxLength(10);

        entity.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        entity.Property(p => p.Status)
            .HasColumnName("Status")
            .HasColumnType("int")
            .IsRequired();

        // Crear relaciones foráneas

        entity.HasRequired(u => u.Role);

        // Crear índices

        entity.HasIndex(p => p.RoleId);

        entity.HasIndex(p => p.Code)
                  .IsUnique();

        entity.HasIndex(p => p.Status);
    }
}