namespace CodeFirst.Entities;

public class Profile
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; }  = null!;
    public long Likes { get; set; }
    public long Followers { get; set; }
}