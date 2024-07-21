using Relationships.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Relationships.Data.Configurations;

public class ProfileConfiguration : Configuration<ProfileConfiguration>, IEntityTypeConfiguration<Profile>
{
	public void Configure(EntityTypeBuilder<Profile> builder)
	{
		builder.HasKey(e => e.Id);
		builder.Property(p => p.FirstName).HasMaxLength(64).IsUnicode(false);
		builder.Property(p => p.LastName).HasMaxLength(64).IsUnicode(false);

		// one-to-one (#1)
		builder.HasOne(p => p.ProfileSubscription).WithOne(ps => ps.Profile)
			.HasForeignKey<ProfileSubscription>(ps => ps.ProfileId)
			.IsRequired();
	}
}