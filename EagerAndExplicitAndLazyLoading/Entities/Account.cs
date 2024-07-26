namespace EagerAndExplicitAndLazyLoading.Entities;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = [];
    public DateTime RegistrationDate { get; set; }
    public bool IsBlocked { get; set; }
    
    // one-to-many (#2)
    public virtual ICollection<Profile> Profiles { get; set; } = [];
}