using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Customer
    {
        // --- Temel Kimlik Bilgileri ---
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        // Tam isim (Hesaplanan alan - Veritabanına kaydedilmeyebilir veya Computed Column olabilir)
        public string FullName => $"{FirstName} {LastName}";

        // --- İletişim Bilgileri ---
        public string Email { get; set; } = default!;
        public string? PhoneNumber { get; set; }       // Sabit hat
        public string? MobileNumber { get; set; }      // Cep (SMS gönderimi için kritik)
        public string? WebsiteUrl { get; set; }
        public string? LinkedInUrl { get; set; }       // CRM için önemli bir veri

        // --- Ticari ve Yasal Bilgiler (B2B & Fatura) ---
        public CustomerType CustomerType { get; set; } // Bireysel mi Kurumsal mı?

        // Kurumsal ise Şirket Adı, Bireysel ise boş olabilir
        public string? CompanyName { get; set; }

        // Fatura için Vergi/TCKN detayları
        public string? TaxOffice { get; set; }         // Vergi Dairesi
        public string? TaxNumber { get; set; }         // Vergi No (Şirketler için)
        public string? IdentityNumber { get; set; }    // TCKN (Bireysel fatura kesilecekse)

        // --- Sınıflandırma ve Satış ---
        public CustomerStatus Status { get; set; } = CustomerStatus.Lead;

        // Müşterinin segmenti (A Sınıfı, VIP, Standart vb.)
        public string? Segment { get; set; }

        // Müşteri kaynağı (Google, Referans, LinkedIn vb.)
        public string? Source { get; set; }

        // KVKK / GDPR İzinleri (Pazarlama için çok önemli)
        public bool HasEmailPermission { get; set; } = false;
        public bool HasSmsPermission { get; set; } = false;

        // --- Diğer ---
        public DateTime? DateOfBirth { get; set; }     // Doğum günü kutlamaları için
        public string? Notes { get; set; }             // Genel notlar için basit alan

        // --- İlişkiler (Navigation Properties) ---
        // Bir müşterinin birden fazla adresi olabilir (Fatura, Teslimat)
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        // Bir müşteriye bağlı birden fazla satış fırsatı olabilir
        // public ICollection<Opportunity> Opportunities { get; set; } 

        // Müşteriden sorumlu satış temsilcisi (AppUser / Personel ID'si)
        public Guid? AssignedRepresentativeId { get; set; }
    }
}
