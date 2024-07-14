using System.Diagnostics;

namespace DIWpfApp.Services;

public class CounterFormatter : ICounterFormatter
{
    public readonly ICounterService _counterService;

    public CounterFormatter(ICounterService counterService)
    {
        Debug.WriteLine("CounterFormatter::CounterFormatter()");
        _counterService = counterService;
    }
    
    public string GetCountAndFormat()
    {
        return $"Count: {_counterService.GetCount()}";
    }
}