using DIWpfApp.ViewModels;

namespace DIWpfApp.Services.Factory;

public interface IViewModelFactory
{
    BaseViewModel Create<T>()
        where T : BaseViewModel;
}