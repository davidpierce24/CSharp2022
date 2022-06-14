using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using databaseLecture.Models;

namespace databaseLecture.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // this establishes the connection to our database
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.AllItems = _context.Items.OrderBy(d => d.Name).ToList();
        return View();
    }

    [HttpPost("item/add")]
    public IActionResult AddItem(Item newItem)
    {
        // we add this to db as long as it's valid
        if(ModelState.IsValid)
        {
            // we can add to db
            _context.Add(newItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View("Index");
        }
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
