using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.Entities;

namespace Relationships.Data.Configurations;

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