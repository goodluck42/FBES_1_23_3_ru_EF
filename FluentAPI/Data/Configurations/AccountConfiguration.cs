using FluentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentAPI.Data.Configurations;

public interface ISingleton<out T>
    where T : class
{
    static abstract T Instance { get; }
}

public abstract class Configuration<T>
    where T : new()
{
    private static T? _instance;
    public static T Instance => _instance ??= new T();
}

public class AccountConfiguration : Configuration<AccountConfiguration>, IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");
        builder.HasKey(e => e.Id);
        // builder.HasKey(e => new { e.Id, e.Login });
        builder.Property(e => e.Login).HasMaxLength(128).HasColumnName("user_login");
        builder.HasIndex(e => e.Login);
        builder.Property(e => e.PasswordHash).HasColumnType("VARBINARY(32)");
    }
}