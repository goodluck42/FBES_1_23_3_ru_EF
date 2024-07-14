using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmLib.Models;

public partial class User : ObservableObject
{
    [ObservableProperty]
    private int _id;
    [ObservableProperty]
    private string _login = null!;
    [ObservableProperty]
    private string _password = null!;
}