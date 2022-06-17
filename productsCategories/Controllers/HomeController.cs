using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using productsCategories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace productsCategories.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // route to render the homepage with products
    public IActionResult Index()
    {
        ViewBag.Products = _context.Products.ToList();
        return View();
    }

    // route to process adding a product
    [HttpPost("product/add")]
    public IActionResult AddProduct(Product newProduct)
    {
        if(ModelState.IsValid){
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            ViewBag.Products = _context.Products.ToList();
            return View("Index");
        }
    }

    // route to render the categories page
    [HttpGet("category")]
    public IActionResult Category()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    // route to process adding a category
    [HttpPost("category/add")]
    public IActionResult AddCategory(Category newCategory)
    {
        if(ModelState.IsValid){
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Category");
        } else {
            ViewBag.Categories = _context.Categories.ToList();
            return View("Category");
        }
    }

    // route to render a specific product page

    // route to process adding a category to a product

    // route to render a specific category page

    // route to process adding a product to a category



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
