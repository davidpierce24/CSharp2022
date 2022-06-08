using Microsoft.AspNetCore.Mvc;

namespace webProject1.Controllers;

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string Name, string Species, int Age)
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Species: {Species}");
        Console.WriteLine($"Age: {Age}");
        ViewBag.Name = Name;
        return View("Success");
    }
}