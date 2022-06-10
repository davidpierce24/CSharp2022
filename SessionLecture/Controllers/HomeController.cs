using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionLecture.Models;
using Microsoft.AspNetCore.Http;

namespace SessionLecture.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // create a session variable
        HttpContext.Session.SetString("User", "Ichigo");
        // to get the data
        string? user = HttpContext.Session.GetString("User");
        Console.WriteLine(user);
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
