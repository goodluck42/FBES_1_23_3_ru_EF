using System.Windows;
using DIWpfApp.Services;
using DIWpfApp.Services.Factory;
using DIWpfApp.ViewModels;
using DIWpfApp.Views;
using Microsoft.Extensions.DependencyInjection;

namespace DIWpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IServiceProvider>(provider => provider);
        serviceCollection.AddSingleton<MainViewModel>();
        
        serviceCollection.AddTransient<BaseViewModel, CounterViewModel>();
        serviceCollection.AddTransient<BaseViewModel, FormatterViewModel>();
        
        serviceCollection.AddSingleton<IViewModelFactory, ViewModelFactory>();

        serviceCollection.AddTransient<IDisplayCounterService, DisplayCounterService>();
        serviceCollection.AddScoped<ICounterService, CounterService>();

        var provider = serviceCollection.BuildServiceProvider();

        MainWindow = new MainView
        {
            DataContext = provider.GetRequiredService<MainViewModel>()
        };

        MainWindow.ShowDialog();
    }
}