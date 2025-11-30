// Core/Domain/Common/BaseEntity.cs
public abstract class BaseEntity
 {
 public Guid Id { get; set; } = Guid.NewGuid(); // Guid, dağıtık sistemler için int'ten daha iyidir.

 // Audit Logları (Kayıt Tarihçesi)
 public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
 public string? CreatedBy { get; set; } // Kaydı oluşturan personel ID'si
 public DateTime? UpdatedDate { get; set; }
 public string? UpdatedBy { get; set; }

 // Soft Delete (Veriyi fiziksel silmeyiz, bayrakla gizleriz)
 public bool IsDeleted { get; set; } = false;
 public DateTime? DeletedDate { get; set; }
 }