namespace CRM.Domain.Enums
{
    public enum AddressType
    {
        Other = 0,
        Billing = 1,   // Fatura Adresi (Muhasebe için kritik)
        Shipping = 2,  // Teslimat/Sevk Adresi (Lojistik için kritik)
        HeadOffice = 3, // Genel Merkez
        Branch = 4      // Şube
    }
}
