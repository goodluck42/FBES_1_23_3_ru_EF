using Microsoft.Extensions.DependencyInjection;
using MvvmLib.ViewModels;

namespace MvvmLib.Services;

public class ViewModelFactory
{
    public BaseViewModel Create(Type type)
    {
        var viewModels = App.ServiceProvider.GetServices(typeof(BaseViewModel)).Cast<BaseViewModel>();
        var viewModel = viewModels.FirstOrDefault(vm => vm.GetType() == type);

        if (viewModel == null)
        {
            throw new ArgumentException(null, nameof(type));
        }
        
        return viewModel;
    }
}