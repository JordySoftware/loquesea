using CoursesApp.Domain.Sales.BuyerAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Sales.BuyerInfrastructure;
internal class CartCourseConfiguration
{
    internal CartCourseConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<CartCourse> entity = modelBuilder.Entity<CartCourse>();

        // Mapear tabla y esquema
        entity.ToTable("CartCourses", "Sales");

        // Crear atributos de tabla

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.BuyerId)
            .HasColumnName("BuyerId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.CourseId)
            .HasColumnName("CourseId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.Code)
            .HasColumnName("Code")
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        // Crear relaciones foráneas

        entity.HasRequired(r => r.Buyer);
        entity.HasRequired(r => r.Course);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => new { p.BuyerId, p.CourseId }).IsUnique();
    }
}