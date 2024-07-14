using System.Windows;
using DIWpfApp.Services;
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

        serviceCollection.AddSingleton<MainViewModel>();
        serviceCollection.AddTransient<BaseViewModel, CounterViewModel>();
        serviceCollection.AddTransient<BaseViewModel, FormatterViewModel>();
        serviceCollection.AddSingleton<IViewModelCollection, ViewModelCollection>();
        serviceCollection.AddTransient<ICounterService, CounterService>();
        
        var provider = serviceCollection.BuildServiceProvider();

        MainWindow = new MainView
        {
            DataContext = provider.GetRequiredService<MainViewModel>()
        };

        MainWindow.ShowDialog();
    }
}