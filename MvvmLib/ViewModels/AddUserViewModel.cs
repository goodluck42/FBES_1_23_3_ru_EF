using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MvvmLib.Messages;
using MvvmLib.Services;
using Microsoft.Extensions.DependencyInjection;
using MvvmLib.Models;

namespace MvvmLib.ViewModels;

[INotifyPropertyChanged]
public partial class AddUserViewModel : BaseViewModel
{
    private readonly ViewModelFactory _factory;

    public AddUserViewModel()
    {
        _factory = App.ServiceProvider.GetService<ViewModelFactory>()!;
        User = new();
    }
    [RelayCommand]
    private void Back()
    {
        WeakReferenceMessenger.Default.Send(new ChangeViewModelMessage(_factory.Create(typeof(UserListViewModel))));
    }

    [RelayCommand]
    private void Add()
    {
        WeakReferenceMessenger.Default.Send(new UserAddedMessage(User));
        Back();
    }

    [ObservableProperty]
    private User _user;
}