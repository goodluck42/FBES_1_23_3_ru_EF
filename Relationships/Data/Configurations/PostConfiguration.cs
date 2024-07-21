using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.Entities;

namespace Relationships.Data.Configurations;

public class PostConfiguration : Configuration<PostConfiguration>, IEntityTypeConfiguration<Post>
{
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.Property(p => p.Text).HasMaxLength(1000);
	}
}