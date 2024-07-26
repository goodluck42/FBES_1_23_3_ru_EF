using EagerAndExplicitAndLazyLoading.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagerAndExplicitAndLazyLoading.Data.Configurations;

public class PostProfileConfiguration : Configuration<PostProfileConfiguration>, IEntityTypeConfiguration<PostProfile>
{
	public void Configure(EntityTypeBuilder<PostProfile> builder)
	{
		builder.HasKey(pp => new
		{
			pp.PostId,
			pp.ProfileId
		});
	}
}