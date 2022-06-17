using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsNDishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace chefsNDishes.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // route to render home page with all chefs
    public IActionResult Index()
    {
        ViewBag.Chefs = _context.Chefs.ToList();
        return View();
    }

    // route to render all dishes
    [HttpGet("dishes/show")]
    public IActionResult Dishes()
    {
        ViewBag.Dishes = _context.Dishes.ToList();
        return View();
    }

    // route to display add a chef form
    [HttpGet("chef/add")]
    public IActionResult AddChef()
    {
        return View();
    }

    // route to process added chef
    [HttpPost("chef/add/process")]
    public IActionResult ProcessChef(Chef newChef)
    {
        if(ModelState.IsValid){
            _context.Add(newChef);
            _context.SaveChanges();
            ViewBag.Chefs = _context.Chefs.ToList();
            return RedirectToAction("Index");
        } else {
            return View("AddChef");
        }
    }

    // route to display added

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
