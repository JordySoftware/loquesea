using CoursesApp.Domain.Sales.BuyerAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Sales.BuyerInfrastructure;
internal class OrderConfiguration
{
    internal OrderConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<Order> entity = modelBuilder.Entity<Order>();

        // Mapear tabla y esquema
        entity.ToTable("Orders", "Sales");

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

        entity.Property(p => p.PaymentId)
            .HasColumnName("PaymentId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        entity.Property(p => p.Code)
            .HasColumnName("Code")
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(p => p.TotalAmount)
            .HasColumnName("TotalAmount")
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        entity.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        // Crear relaciones foráneas

        entity.HasRequired(r => r.Buyer);
        entity.HasMany(r => r.OrdersDetail);
        entity.HasOptional(r => r.Payment);

        // Crear índices

        entity.HasIndex(p => p.Code).IsUnique();
    }
}