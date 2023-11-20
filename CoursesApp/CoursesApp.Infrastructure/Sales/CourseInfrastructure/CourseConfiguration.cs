using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Sales.CourseInfrastructure;
internal class CourseConfiguration
{
    internal CourseConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<Domain.Sales.CourseAggregate.Course> entity = modelBuilder.Entity<Domain.Sales.CourseAggregate.Course>();

        // Mapear tabla y esquema
        entity.ToTable("Courses", "Sales");

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

        entity.Property(p => p.Title)
            .HasColumnName("Title")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(p => p.UnitAmount)
            .HasColumnName("UnitAmount")
            .HasColumnType("decimal")
            .HasPrecision(18,2)
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

        entity.HasMany(r => r.CourseLessons);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => p.Title).IsUnique();
        entity.HasIndex(p => p.Status);
    }
}