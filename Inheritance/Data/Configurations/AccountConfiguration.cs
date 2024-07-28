using Inheritance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inheritance.Data.Configurations;

public class AccountConfiguration : Configuration<AccountConfiguration>, IEntityTypeConfiguration<Account>
{
	public void Configure(EntityTypeBuilder<Account> builder)
	{
		// builder.UseTphMappingStrategy();
		// builder.UseTptMappingStrategy();

		builder.UseTpcMappingStrategy();
		
		builder.HasKey(e => e.Id);
		builder.Property(e => e.Login).HasMaxLength(128).HasColumnName("user_login");
		builder.HasIndex(e => e.Login).IsClustered(false).IsUnique();
		builder.Property(e => e.PasswordHash).HasColumnType("VARBINARY(32)");

		// one-to-many (#2)
		builder.HasMany(a => a.Profiles)
			.WithOne(p => p.Account)
			.HasForeignKey(p => p.AccountId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}