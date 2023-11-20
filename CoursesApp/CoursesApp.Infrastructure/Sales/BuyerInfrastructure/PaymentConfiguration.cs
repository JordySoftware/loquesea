using CoursesApp.Domain.Sales.BuyerAggregate;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CoursesApp.Infrastructure.Sales.BuyerInfrastructure;
internal class PaymentConfiguration
{
    internal PaymentConfiguration(DbModelBuilder modelBuilder)
    {
        // Obtener entidad
        EntityTypeConfiguration<Payment> entity = modelBuilder.Entity<Payment>();

        // Mapear tabla y esquema
        entity.ToTable("Payments", "Sales");

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

        entity.Property(p => p.Code)
            .HasColumnName("Code")
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(p => p.DateExecution)
            .HasColumnName("DateExecution")
            .HasColumnType("datetime")
            .IsRequired();

        entity.Property(p => p.Method)
            .HasColumnName("Method")
            .HasColumnType("int")
            .IsRequired();

        entity.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(500);

        // Crear relaciones foráneas

        entity.HasRequired(r => r.Order);

        // Crear índices

        entity.HasIndex(p => p.OrderId).IsUnique();
        entity.HasIndex(p => p.Code).IsUnique();
        entity.HasIndex(p => p.DateExecution);
        entity.HasIndex(p => p.Method);
    }
}