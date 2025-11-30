using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRM.Persistence.Context
{
	public class CrmDbContext : DbContext
	{
		public CrmDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Address> Addresses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Bulunduğumuz Assembly'deki (Persistence projesi) 
			// tüm IEntityTypeConfiguration implementasyonlarını bul ve uygula.
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}
	}
}
