using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvclecture.Models;

namespace mvclecture.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(User newUser)
    {
        if(ModelState.IsValid)
        {
            // this means we pass our validations
            // then we would redirect to success
            return RedirectToAction("Success", newUser);
        } else {
            // what to do if validation is triggered
            return View("Index");
        }
        // Console.WriteLine(newUser.Name);
        // Console.WriteLine(newUser.FavColor);
        // Console.WriteLine(newUser.FavNumber);
        
    }

    [HttpGet("Success")]
    public IActionResult Success(User newUser)
    {
        ViewBag.User = newUser;
        return View("Success", newUser);
    }

    


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
