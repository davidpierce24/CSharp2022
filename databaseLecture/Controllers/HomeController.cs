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

    [HttpGet("/item/delete/{itemId}")]
    public IActionResult DeleteItem(int itemId)
    {
        Item itemToDelete = _context.Items.SingleOrDefault(a => a.ItemId == itemId);
        _context.Items.Remove(itemToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("item/edit/{itemId}")]
    public IActionResult EditItem(int itemId)
    {
        // we need to find the item
        Item itemToEdit = _context.Items.FirstOrDefault(a => a.ItemId == itemId);
        return View(itemToEdit);
    }

    [HttpPost("item/update/{itemId}")]
    public IActionResult UpdateItem(int itemId, Item newVersionOfItem)
    {
        Item oldItem = _context.Items.FirstOrDefault(a => a.ItemId == itemId);
        oldItem.Name = newVersionOfItem.Name;
        oldItem.Description = newVersionOfItem.Description;
        oldItem.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
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
