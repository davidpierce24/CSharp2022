using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Route to display home page with list of dishes
    public IActionResult Index()
    {
        ViewBag.AllDishes = _context.Dishes.OrderByDescending(x => x.CreatedAt).ToList();
        return View();
    }

    // Route to take user to page for adding a dish
    [HttpGet("new/dish")]
    public IActionResult NewDish()
    {
        return View();
    }

    // Route to process added dishes
    [HttpPost("dish/add")]
    public IActionResult AddDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View("NewDish");
        }
    }

    // route to show a specific dish
    [HttpGet("dish/show/{DishId}")]
    public IActionResult ShowDish(int DishId)
    {
        Dish dishToShow = _context.Dishes.FirstOrDefault(x => x.DishId == DishId);
        return View(dishToShow);
    }

    // route to take a user to a dish's page to make edits
    [HttpGet("dish/edit/{DishId}")]
    public IActionResult EditDish(int DishId)
    {
        Dish dishToEdit = _context.Dishes.FirstOrDefault(x => x.DishId == DishId);
        return View(dishToEdit);
    }

    // route to process dish edits
    [HttpPost("dish/update/{DishId}")]
    public IActionResult UpdateDish(int DishId, Dish changeDish)
    {
        Dish oldDish = _context.Dishes.FirstOrDefault(x => x.DishId == DishId);
        oldDish.Name = changeDish.Name;
        oldDish.Chef = changeDish.Chef;
        oldDish.Description = changeDish.Description;
        oldDish.Calories = changeDish.Calories;
        oldDish.Tastiness = changeDish.Tastiness;
        oldDish.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("ShowDish", oldDish);
    }

    // route to destroy a dish
    [HttpGet("dish/destroy/{DishId}")]
    public IActionResult DestroyDish(int DishId)
    {
        Dish dishToDestroy = _context.Dishes.SingleOrDefault(d => d.DishId == DishId);
        _context.Dishes.Remove(dishToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // we have achieved CRUD
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
