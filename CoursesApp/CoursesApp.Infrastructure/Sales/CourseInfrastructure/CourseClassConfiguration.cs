using CoursesApp.Domain.Sales.CourseAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Sales.CourseInfrastructure;
internal class CourseClassConfiguration
{
    internal CourseClassConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<CourseClass> entity = modelBuilder.Entity<CourseClass>();

        // Mapear tabla y esquema
        entity.ToTable("CourseClasses", "Sales");

        // Crear atributos de tabla

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.CourseLessonId)
            .HasColumnName("CourseLessonId")
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

        entity.Property(p => p.MediaType)
            .HasColumnName("MediaType")
            .HasColumnType("int")
            .IsRequired();

        entity.Property(p => p.UrlMedia)
            .HasColumnName("UrlMedia")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        // Crear relaciones foráneas

        entity.HasRequired(r => r.CourseLesson);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => p.Title).IsUnique();
        entity.HasIndex(p => p.MediaType);
        entity.HasIndex(p => new { p.CourseLessonId, p.OrderPosition }).IsUnique();
    }
}