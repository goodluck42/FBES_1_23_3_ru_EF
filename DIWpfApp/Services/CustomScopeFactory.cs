using Microsoft.Extensions.DependencyInjection;

namespace DIWpfApp.Services;

public class CustomScopeFactory : IServiceScopeFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CustomScopeFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public IServiceScope CreateScope()
    {
        return _serviceProvider.CreateScope();
    }
}