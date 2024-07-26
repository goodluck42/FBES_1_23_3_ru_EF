namespace EagerAndExplicitAndLazyLoading.Entities;

public class ProfileSubscription
{
	public int Id { get; set; }
	public DateTime SubscribeBegins { get; set; }
	public DateTime SubscribeEnds { get; set; }

	// one-to-one (#1)
	public int ProfileId { get; set; }
	public virtual Profile Profile { get; set; } = null!;
}