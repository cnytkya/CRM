namespace CRM.Domain.Enums
{
	public enum CustomerType
	{
		Individual = 1, // Bireysel Müşteri
		Corporate = 2 // Kurumsal Müşteri
	}

	// Core/Domain/Enums/CustomerStatus.cs
	public enum CustomerStatus
	{
		Active = 1, // Aktif çalışılan
		Passive = 2, // Artık çalışılmayan
		Lead = 3, // Henüz satış yapılmamış aday
		Blacklisted = 4 // Kara liste (Riskli müşteri)
	}
}
