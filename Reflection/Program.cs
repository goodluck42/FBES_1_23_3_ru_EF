using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

{
    object account = new Account
    {
        Id = 1,
        Login = "MyLogin",
        Password = "MyPassword"
    };

    Type compileType = typeof(object);
    Type runtimeType = account.GetType();

    // Console.WriteLine(compileType.Name);
    // Console.WriteLine(runtimeType.Name);
}


{
    Type accountStorageType = typeof(AccountStorage);

    AccountStorage _this = Activator.CreateInstance<AccountStorage>();
    var fieldInfo = accountStorageType.GetField("_accounts", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);

    if (fieldInfo != null)
    {
        if (fieldInfo.FieldType == typeof(List<Account>))
        {
            fieldInfo.SetValue(_this, new List<Account>());
        }
    }
    
    var addAccountMethodInfo = accountStorageType.GetMethod("AddAccount", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod)!;
    var attribute = addAccountMethodInfo.GetCustomAttribute(typeof(DisplayTextAttribute));
    var accToAdd = new Account
    {
        Id = 1,
        Login = "MyLogin",
        Password = "MyPassword"
    };
    
    if (attribute != null)
    {
        DisplayTextAttribute displayTextAttribute = (attribute as DisplayTextAttribute)!;

        Console.WriteLine($"{displayTextAttribute.WrapSymbol}{displayTextAttribute.Text}{displayTextAttribute.WrapSymbol}");
    }
    
    addAccountMethodInfo.Invoke(_this, [accToAdd]);
    
    var displayMethodInfo = accountStorageType.GetMethod("Display", BindingFlags.Instance | BindingFlags.NonPublic |  BindingFlags.InvokeMethod)!;
    
    displayMethodInfo.Invoke(_this, null);
}


[AttributeUsage(AttributeTargets.Method)]
public class DisplayTextAttribute : Attribute
{
    public DisplayTextAttribute(string wrapSymbol, string text)
    {
        WrapSymbol = wrapSymbol;
        Text = text;
    }

    public string WrapSymbol { get; }
    public string Text { get; }
}


public class Account
{
    public required int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}

public class AccountStorage
{
    private List<Account> _accounts;

    public AccountStorage()
    {
        Console.WriteLine("AccountStorage::AccountStorage()");
    }

    [DisplayText("\"", "Hello method")]
    private void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    private void Display()
    {
        foreach (var account in _accounts)
        {
            Console.WriteLine(account.Id);
            Console.WriteLine(account.Login);
            Console.WriteLine(account.Password);
        }
    }
}