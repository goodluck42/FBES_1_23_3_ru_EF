using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DIWebApplication.Models;
using DIWebApplication.Services;

namespace DIWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ICounterService _counterService;
    private readonly ICounterFormatter _counterFormatter;

    // new HomeController(service.Instance); -- Singleton
    // new HomeController(new CounterService()); -- Transient
    public HomeController(ICounterService counterService, ICounterFormatter counterFormatter) 
    {
        _counterService = counterService;
        _counterFormatter = counterFormatter;

        Debug.WriteLine("HomeController::HomeController()");
    }

    public IActionResult Index()
    {
        ViewData["CurrentFormattedCounter"] = _counterFormatter.GetCountAndFormat();
        ViewData["CurrentCounter"] = _counterService.GetCount();
        ViewData["AreServicesEqual"] = _counterService == ((CounterFormatter)_counterFormatter)._counterService;
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}