using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DIWpfApp.Services;
using DIWpfApp.Services.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace DIWpfApp.ViewModels;

public partial class CounterViewModel : BaseViewModel
{
    private readonly IServiceProvider _provider;
    private readonly ICounterService _counterService;
    private readonly IDisplayCounterService _displayCounterService;

    public CounterViewModel(IViewModelFactory viewModelFactory, IServiceProvider provider) : base(viewModelFactory)
    {
        _provider = provider;

        using (var scope = provider.CreateScope())
        {
            _counterService = scope.ServiceProvider.GetRequiredService<ICounterService>();
            _displayCounterService = scope.ServiceProvider.GetRequiredService<IDisplayCounterService>();
        }
    }

    [ObservableProperty] private string? _currentValue;

    [RelayCommand]
    private void IncreaseCounter()
    {
        CurrentValue = _counterService.GetCount().ToString();
        _displayCounterService.DisplayCounter();
    }

    [RelayCommand]
    private void DecreaseCounter()
    {
    }
}