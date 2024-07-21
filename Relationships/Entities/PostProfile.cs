namespace Relationships.Entities;

public class PostProfile
{
	public int PostId { get; set; }
	public Post Post { get; set; }
	public int ProfileId { get; set; }
	public Profile Profile { get; set; }
}