using CoursesApp.Domain.Sales.CourseAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Sales.CourseInfrastructure;
internal class CourseLessonConfiguration
{
    internal CourseLessonConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<CourseLesson> entity = modelBuilder.Entity<CourseLesson>();

        // Mapear tabla y esquema
        entity.ToTable("CourseLessons", "Sales");

        // Crear atributos de tabla

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id)
            .HasColumnName("Id")
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

        entity.Property(p => p.OrderPosition)
            .HasColumnName("OrderPosition")
            .HasColumnType("smallint")
            .IsRequired();

        entity.Property(p => p.Title)
            .HasColumnName("Title")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        // Crear relaciones foráneas

        entity.HasRequired(r => r.Course);
        entity.HasMany(r => r.CourseClasses);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => p.Title).IsUnique();
        entity.HasIndex(p => new { p.CourseId, p.OrderPosition }).IsUnique();
    }
}