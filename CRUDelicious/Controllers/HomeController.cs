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

    public IActionResult Index()
    {
        ViewBag.AllDishes = _context.Dishes.OrderByDescending(x => x.CreatedAt).ToList();
        return View();
    }

    [HttpGet("new/dish")]
    public IActionResult NewDish()
    {
        return View();
    }

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

    [HttpGet("dish/show/{DishId}")]
    public IActionResult ShowDish(int DishId)
    {
        Dish dishToShow = _context.Dishes.FirstOrDefault(x => x.DishId == DishId);
        return View(dishToShow);
    }

    [HttpGet("dish/edit/{DishId}")]
    public IActionResult EditDish(int DishId)
    {
        Dish dishToEdit = _context.Dishes.FirstOrDefault(x => x.DishId == DishId);
        return View(dishToEdit);
    }

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
