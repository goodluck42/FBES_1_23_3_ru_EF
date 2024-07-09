using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Entities;

[Index(nameof(Login))]
public class Account
{
    [Key] public int Id { get; set; }
    [MaxLength(450)] public string Login { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public bool IsBlocked { get; set; }
}