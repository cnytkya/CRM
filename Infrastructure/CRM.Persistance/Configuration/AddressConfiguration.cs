using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Persistence.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //object value = builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            // --- Property Ayarları ---

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(50); // "Ev", "İş", "Depo"

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.District)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Neighborhood)
                .HasMaxLength(100);

            builder.Property(a => a.PostalCode)
                .HasMaxLength(10); // Posta kodları kısa olur

            builder.Property(a => a.AddressLine1)
                .IsRequired()
                .HasMaxLength(250); // Ana adres satırı

            builder.Property(a => a.AddressLine2)
                .HasMaxLength(250); // Detay adres satırı

            // Koordinatlar hassas veri olduğu için null olabilir
            // ama tipini veritabanına float/double olarak net belirtiriz.
            builder.Property(a => a.Latitude);
            builder.Property(a => a.Longitude);

            builder.Property(a => a.ContactName)
                .HasMaxLength(100);

            builder.Property(a => a.ContactPhone)
                .HasMaxLength(20);

            // BaseEntity alanları
            builder.Property(a => a.CreatedBy).HasMaxLength(50);
            builder.Property(a => a.UpdatedBy).HasMaxLength(50);

            // Soft Delete Filtresi
            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}

