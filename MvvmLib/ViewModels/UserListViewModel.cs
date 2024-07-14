using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MvvmLib.Messages;
using MvvmLib.Models;
using MvvmLib.Services;

namespace MvvmLib.ViewModels;

[INotifyPropertyChanged]
public partial class UserListViewModel : BaseViewModel
{
    private readonly ViewModelFactory _factory;

    public UserListViewModel(ViewModelFactory factory)
    {
        _factory = factory;

        Users = new ObservableCollection<User>();

        WeakReferenceMessenger.Default.Register<UserAddedMessage>(this,
            (sender, message) =>
            {
                Users.Add(message.User);
            });
    }

    [RelayCommand]
    private void Add()
    {
        WeakReferenceMessenger.Default.Send<ChangeViewModelMessage>(
            new ChangeViewModelMessage(_factory.Create(typeof(AddUserViewModel))));
    }

    [RelayCommand]
    private void Remove(User? param)
    {
        if (param == null)
        {
            return;
        }

        Users.Remove(param);
    }

    [RelayCommand]
    private void Update(object? param)
    {
        MessageBox.Show("Nothing there (Update)");
    }

    [ObservableProperty] private ObservableCollection<User> _users;
}