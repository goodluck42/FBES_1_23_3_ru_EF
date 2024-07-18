namespace FluentAPI.Entities;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsPremium { get; set; }
    public DateTime? PremiumEnds { get; set; }
}