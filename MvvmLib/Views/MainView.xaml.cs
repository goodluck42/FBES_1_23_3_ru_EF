using System.Windows;
using MvvmLib.Services;
using MvvmLib.ViewModels;

namespace MvvmLib.Views;

public partial class MainView : Window
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}