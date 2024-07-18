using FluentAPI.Entities;

namespace FluentAPI.Services;

public interface IAccountManager
{
    void Add(Account account);
    void Update(int id, Account newAccount);
    void Update(Account newAccount);
    ICollection<Account> GetAccounts();
    Account? GetAccountById(int id);
    void Remove(int id);
    void Remove(Account account);
}