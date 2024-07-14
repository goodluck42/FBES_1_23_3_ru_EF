using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DIWpfApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly IViewModelCollection _viewModelCollection;

    [ObservableProperty]
    private BaseViewModel? _currentViewModel;

    public MainViewModel(IViewModelCollection viewModelCollection)
    {
        _viewModelCollection = viewModelCollection;
    }
    
    [RelayCommand]
    private void OpenCounterView()
    {
        CurrentViewModel = _viewModelCollection.Get(typeof(CounterViewModel));
    }
    
    [RelayCommand]
    private void OpenFormatterView()
    {
        CurrentViewModel = _viewModelCollection.Get(typeof(FormatterViewModel));
    }
}