using CoursesApp.Domain.Service.StudentAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Service.StudentInfrastructure;
internal class StudentProgressConfiguration
{
    internal StudentProgressConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<StudentProgress> entity = modelBuilder.Entity<StudentProgress>();

        // Mapear tabla y esquema
        entity.ToTable("StudentsProgress", "Service");

        // Crear atributos de tabla

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.StudentCourseId)
            .HasColumnName("StudentCourseId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.CourseLessonId)
            .HasColumnName("CourseLessonId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.CourseClassId)
            .HasColumnName("CourseClassId")
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

        entity.HasRequired(r => r.StudentCourse);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => new { p.StudentCourseId, p.CourseLessonId, p.CourseClassId }).IsUnique();
    }
}