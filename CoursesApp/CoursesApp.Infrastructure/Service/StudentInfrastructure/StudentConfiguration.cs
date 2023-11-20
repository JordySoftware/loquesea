using CoursesApp.Domain.Service.StudentAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Service.StudentInfrastructure;
internal class StudentConfiguration
{
    internal StudentConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<Student> entity = modelBuilder.Entity<Student>();

        // Mapear tabla y esquema
        entity.ToTable("Students", "Service");

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

        entity.HasMany(r => r.StudentCourses);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => p.Status);
    }
}