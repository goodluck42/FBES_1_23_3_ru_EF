using System.Collections;
using System.Windows;
using DIWpfApp.ViewModels;

namespace DIWpfApp;

public class ViewModelCollection : IViewModelCollection
{
    private readonly List<BaseViewModel> _viewModels;

    public ViewModelCollection(IEnumerable<BaseViewModel> viewModels)
    {
        _viewModels = new(viewModels);
    }

    public IEnumerator<BaseViewModel> GetEnumerator()
    {
        return _viewModels.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public BaseViewModel Get(Type type)
    {
        return _viewModels.First(w => w.GetType() == type);
    }
}