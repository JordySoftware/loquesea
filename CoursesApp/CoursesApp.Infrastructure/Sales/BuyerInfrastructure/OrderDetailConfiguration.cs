using CoursesApp.Domain.Sales.BuyerAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Sales.BuyerInfrastructure;
internal class OrderDetailConfiguration
{
    internal OrderDetailConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<OrderDetail> entity = modelBuilder.Entity<OrderDetail>();

        // Mapear tabla y esquema
        entity.ToTable("OrdersDetail", "Sales");

        // Crear atributos de tabla

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.OrderId)
            .HasColumnName("OrderId")
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

        entity.HasRequired(r => r.Order);
        entity.HasRequired(r => r.Course);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => new { p.OrderId, p.CourseId }).IsUnique();
    }
}