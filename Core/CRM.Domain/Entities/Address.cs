using CRM.Domain.Common;

namespace CRM.Domain.Entities;

public class Address : BaseEntity
{
    // --- Bağlantı (Foreign Key) ---
    // Hangi müşteriye ait?
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = default!;

    // --- Başlık ve Tür ---
    // Kullanıcının adresi tanıması için: "Merkez Depo", "Levent Ofis" vb.
    public string Title { get; set; } = default!;

    // Fatura mı, Teslimat adresi mi?
    //public AddressType AddressType { get; set; } = AddressType.Billing;

    // --- Konum Detayları ---
    public string Country { get; set; } = "Türkiye"; // Varsayılan değer
    public string City { get; set; } = default!;      // İl (Örn: İstanbul)
    public string District { get; set; } = default!;  // İlçe (Örn: Kadıköy)
    public string? Neighborhood { get; set; }         // Mahalle (Kargo entegrasyonu için gerekebilir)

    public string AddressLine1 { get; set; } = default!; // Cadde, Sokak, No
    public string? AddressLine2 { get; set; }            // Bina adı, Kat, Daire, Tarif

    public string? PostalCode { get; set; }              // Posta Kodu

    // --- Coğrafi Konum (Saha Satış Ekipleri İçin) ---
    // Google Maps veya Yandex Maps entegrasyonu için koordinatlar.
    // Satış temsilcisi "Yakındaki Müşteriler" özelliğini kullanabilir.
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    // --- İletişim (Opsiyonel) ---
    // Bazen teslimat adresi için müşterinin genel numarasından farklı 
    // bir yetkili (örn: Depo Sorumlusu) olabilir.
    public string? ContactName { get; set; } // "Ahmet Bey - Depo Sorumlusu"
    public string? ContactPhone { get; set; }
}