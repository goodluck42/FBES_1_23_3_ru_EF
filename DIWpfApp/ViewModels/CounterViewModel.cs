using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DIWpfApp.Services;

namespace DIWpfApp.ViewModels;

public partial class CounterViewModel : BaseViewModel
{
    private readonly ICounterService _counterService;

    public CounterViewModel(ICounterService counterService)
    {
        _counterService = counterService;
    }

    [ObservableProperty] private string? _currentValue;

    [RelayCommand]
    private void IncreaseCounter()
    {
        CurrentValue = _counterService.GetCount().ToString();
    }

    [RelayCommand]
    private void DecreaseCounter()
    {
    }
}