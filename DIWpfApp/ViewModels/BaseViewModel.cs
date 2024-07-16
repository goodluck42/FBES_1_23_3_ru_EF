using CommunityToolkit.Mvvm.ComponentModel;
using DIWpfApp.Services.Factory;

namespace DIWpfApp.ViewModels;

public abstract class BaseViewModel : ObservableObject
{
    protected readonly IViewModelFactory? ViewModelFactory;

    public BaseViewModel()
    {
    }

    public BaseViewModel(IViewModelFactory viewModelFactory)
    {
        ViewModelFactory = viewModelFactory;
    }
}