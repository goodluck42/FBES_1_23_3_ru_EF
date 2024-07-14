using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MvvmLib.Messages;
using MvvmLib.Services;

namespace MvvmLib.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel : BaseViewModel
{
    private readonly ViewModelFactory _factory;

    public MainViewModel(ViewModelFactory factory)
    {
        _factory = factory;

        ViewModel = factory.Create(typeof(UserListViewModel));

        WeakReferenceMessenger.Default.Register<ChangeViewModelMessage>(this,
            (sender, message) => { ViewModel = message.ViewModel; });
    }

    [ObservableProperty] private BaseViewModel _viewModel;
}