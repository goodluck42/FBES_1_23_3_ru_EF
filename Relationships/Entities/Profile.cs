namespace Relationships.Entities;

public class Profile
{
	public int Id { get; set; }
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = null!;
	public long Likes { get; set; }
	public long Followers { get; set; }

	// one-to-many (#2)
	public int AccountId { get; set; }
	public Account Account { get; set; } = null!;


	// one-to-one (#1)
	public int ProfileSubscriptionId { get; set; }
	public ProfileSubscription? ProfileSubscription { get; set; }

	// many-to-many (#3)
	public ICollection<PostProfile> PostProfiles { get; set; } = [];
}