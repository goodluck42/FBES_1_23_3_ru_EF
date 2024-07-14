using DIWpfApp.ViewModels;

namespace DIWpfApp;

public interface IViewModelCollection : IEnumerable<BaseViewModel>
{
    BaseViewModel Get(Type type);
}