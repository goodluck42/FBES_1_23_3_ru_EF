using System.Windows;

namespace DIWpfApp.Services;

public class DisplayCounterService : IDisplayCounterService
{
    private readonly ICounterService _counterService;

    public DisplayCounterService(ICounterService counterService)
    {
        _counterService = counterService;
    }
    
    public void DisplayCounter()
    {
        MessageBox.Show($"Counter: {_counterService.GetCount()}");
    }
}