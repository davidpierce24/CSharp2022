using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using loginRegLecture.Models;

namespace loginRegLecture.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Success");
        } else {
            return View("Index");
        }
    }

    [HttpGet("success")]
    public IActionResult Success()
    {
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
