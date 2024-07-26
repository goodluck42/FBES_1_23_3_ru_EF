namespace EagerAndExplicitAndLazyLoading.Entities;

public class PostProfile
{
	public int PostId { get; set; }
	public virtual Post Post { get; set; }
	public int ProfileId { get; set; }
	public virtual Profile Profile { get; set; }
}