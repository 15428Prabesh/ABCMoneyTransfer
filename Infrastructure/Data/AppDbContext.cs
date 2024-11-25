using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
		
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Transfer> Transfers { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id)
					  .ValueGeneratedOnAdd();
				entity.Property(e => e.UserName).IsRequired();
				entity.Property(e => e.FirstName).IsRequired();
				entity.Property(e => e.LastName).IsRequired();
				entity.Property(e => e.Email).IsRequired();
				entity.Property(e => e.UserRole).HasDefaultValue("admin");
			});
            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();
                entity.Property(e => e.ReceiverFirstName).IsRequired();
                entity.Property(e => e.ReceiverLastName).IsRequired();
                entity.Property(e => e.BankName).IsRequired();
                entity.Property(e => e.AccountNumber).IsRequired();
                entity.Property(e => e.TransferAmountMYR).IsRequired();
                entity.Property(e => e.TransferDate).IsRequired();
            });
        }

	}
}
