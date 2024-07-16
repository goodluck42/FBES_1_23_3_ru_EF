using DIWpfApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DIWpfApp.Services.Factory;

public class ViewModelFactory : IViewModelFactory
{
    private readonly IServiceProvider _provider;

    public ViewModelFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public BaseViewModel Create<T>()
        where T : BaseViewModel
    {
        var type = typeof(T);

        return _provider.GetRequiredService<IEnumerable<BaseViewModel>>().First(b => b.GetType() == type);
    }
}