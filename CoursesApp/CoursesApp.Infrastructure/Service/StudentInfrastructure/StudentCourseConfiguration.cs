using CoursesApp.Domain.Service.StudentAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Service.StudentInfrastructure;
internal class StudentCourseConfiguration
{
    internal StudentCourseConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<StudentCourse> entity = modelBuilder.Entity<StudentCourse>();

        // Mapear tabla y esquema
        entity.ToTable("StudentCourses", "Service");

        // Crear atributos de tabla

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.StudentId)
            .HasColumnName("StudentId")
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

        entity.Property(p => p.CourseTitle)
            .HasColumnName("CourseTitle")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        // Crear relaciones foráneas

        entity.HasRequired(r => r.Student);
        entity.HasMany(r => r.StudentsProgress);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => new { p.StudentId, p.CourseId }).IsUnique();
    }
}