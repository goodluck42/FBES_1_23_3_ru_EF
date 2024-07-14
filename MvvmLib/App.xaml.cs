using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MvvmLib.Services;
using MvvmLib.ViewModels;
using MvvmLib.Views;

namespace MvvmLib;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private static ServiceCollection? _serviceCollection;
    private static ServiceProvider? _serviceProvider;

    public static ServiceProvider ServiceProvider => _serviceProvider!;
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _serviceCollection = new ServiceCollection();

        _serviceCollection.AddSingleton<MainView>();
        _serviceCollection.AddSingleton<MainViewModel>();
        _serviceCollection.AddTransient<BaseViewModel, AddUserViewModel>();
        _serviceCollection.AddSingleton<BaseViewModel, UserListViewModel>();
        _serviceCollection.AddTransient<ViewModelFactory>();
        
        _serviceProvider = _serviceCollection.BuildServiceProvider();

        var view = _serviceProvider.GetService<MainView>()!;

        view.ShowDialog();
    }
    
     
}