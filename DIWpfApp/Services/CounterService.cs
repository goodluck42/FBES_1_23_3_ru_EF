using System.Diagnostics;

namespace DIWpfApp.Services;

public class CounterService : ICounterService
{
    private int _currentCount;

    public CounterService()
    {
        Debug.WriteLine("CounterService::CounterService()");
        _currentCount = 1;
    }
    
    public int GetCount()
    {
        return _currentCount++;
    }
}