using Relationships.Data;
using Relationships.Entities;

namespace Relationships.Services;

public class DbAccountManager : IAccountManager
{
    private readonly ApplicationDbContext _dbContext;

    public DbAccountManager(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(Account account)
    {
        _dbContext.Accounts.Add(account);

        _dbContext.SaveChanges();
    }

    public void Update(int id, Account newAccount)
    {
        var accountCopy = new Account
        {
            Id = id,
            Login = newAccount.Login,
            PasswordHash = newAccount.PasswordHash,
            RegistrationDate = newAccount.RegistrationDate,
            IsBlocked = newAccount.IsBlocked
        };
        
        Update(accountCopy);
    }
    
    public void Update(Account newAccount)
    {
        _dbContext.Accounts.Update(newAccount);

        _dbContext.SaveChanges();
    }

    public ICollection<Account> GetAccounts()
    {
        return _dbContext.Accounts.ToList();
    }

    public Account? GetAccountById(int id)
    {
        return _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
    }

    public void Remove(int id)
    {
        _dbContext.Accounts.Remove(new()
        {
            Id = id
        });

        _dbContext.SaveChanges();
    }

    public void Remove(Account account)
    {
        Remove(account.Id);
    }
}