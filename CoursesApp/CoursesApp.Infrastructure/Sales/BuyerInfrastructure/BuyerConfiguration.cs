using CoursesApp.Domain.Sales.BuyerAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Sales.BuyerInfrastructure;
internal class BuyerConfiguration
{
    internal BuyerConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<Buyer> entity = modelBuilder.Entity<Buyer>();

        // Mapear tabla y esquema
        entity.ToTable("Buyers", "Sales");

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

        entity.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        entity.Property(p => p.Status)
            .HasColumnName("Status")
            .HasColumnType("int")
            .IsRequired();

        // Crear relaciones foráneas

        entity.HasMany(r => r.CartCourses);
        entity.HasMany(r => r.Orders);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => p.Status);
    }
}