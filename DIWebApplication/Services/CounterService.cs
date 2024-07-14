using System.Diagnostics;

namespace DIWebApplication.Services;

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