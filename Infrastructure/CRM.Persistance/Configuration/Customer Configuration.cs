using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Persistence.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Tablo Adı
            //builder.ToTable("Customers");

            // Primary Key
            builder.HasKey(c => c.Id);

            // --- Property Ayarları ---

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(60); // İsimler genelde çok uzun olmaz

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(60);

            // FullName veritabanında tutulmaz, C# tarafında hesaplanır.
            // EF Core'un bunu kolon sanıp hata vermesini engelliyoruz.
            builder.Ignore(c => c.FullName);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Email unique (eşsiz) olmalı mı? CRM mantığına göre değişir 
            // ama genelde aynı maille 2. kayıt istenmez.
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(20); // +90 555 ... gibi formatlar için

            builder.Property(c => c.MobileNumber)
                .HasMaxLength(20);

            builder.Property(c => c.IdentityNumber)
                .HasMaxLength(11) // TC No sabit 11 hane
                .IsFixedLength(); // char(11) olarak tutar, performansı artırır.

            builder.Property(c => c.TaxNumber)
                .HasMaxLength(20); // Yabancı vergi noları uzun olabilir

            builder.Property(c => c.CompanyName)
                .HasMaxLength(150);

            // --- Audit & Soft Delete Ayarları ---

            builder.Property(c => c.CreatedBy).HasMaxLength(50);
            builder.Property(c => c.UpdatedBy).HasMaxLength(50);

            // GLOBAL QUERY FILTER (Çok Önemli!)
            // Uygulama genelinde "Select * from Customers" dendiğinde 
            // otomatik olarak "Where IsDeleted = false" ekler.
            builder.HasQueryFilter(c => !c.IsDeleted);

            // --- İlişkiler ---

            // Bir Müşterinin çok adresi olur.
            // Müşteri silinirse (Fiziksel silme) adresleri de silinir.
            builder.HasMany(c => c.Addresses)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
