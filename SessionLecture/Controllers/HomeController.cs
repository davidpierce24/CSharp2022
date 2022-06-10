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
        // // create a session variable
        // HttpContext.Session.SetString("User", "Ichigo");
        // // to get the data
        // string? user = HttpContext.Session.GetString("User");
        // Console.WriteLine(user);
        // // HttpContext.Session.Clear();
        // // we can check if there's anythin in session and do stuff accordingly
        if (HttpContext.Session.GetInt32("Sum") == null)
        {
            HttpContext.Session.SetInt32("Sum", 0);
        }
        return View();
    }

    [HttpPost("setName")]
    public IActionResult setName(string Name, int Num)
    {
        HttpContext.Session.SetString("User", Name);
        int? original = HttpContext.Session.GetInt32("Sum");
        HttpContext.Session.SetInt32("Sum", (int)original + Num);
        return RedirectToAction("Index");
    }

    [HttpGet("delete")]
    public IActionResult deleteSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
