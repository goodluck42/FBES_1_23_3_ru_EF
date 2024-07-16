using System.Windows.Documents;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DIWpfApp.Services;
using DIWpfApp.Services.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace DIWpfApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly IViewModelFactory _viewModelFactory;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    [ObservableProperty] private BaseViewModel? _currentViewModel;

    public MainViewModel(IViewModelFactory viewModelFactory, IServiceScopeFactory serviceScopeFactory)
    {
        _viewModelFactory = viewModelFactory;
        _serviceScopeFactory = serviceScopeFactory;
    }

    [RelayCommand]
    private void OpenCounterView()
    {
        CurrentViewModel = _viewModelFactory.Create<CounterViewModel>();
    }

    [RelayCommand]
    private void OpenFormatterView()
    {
        CurrentViewModel = _viewModelFactory.Create<FormatterViewModel>();
    }
}