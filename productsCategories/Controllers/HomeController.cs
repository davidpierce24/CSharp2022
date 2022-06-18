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
    [HttpGet("product/show/{ProductId}")]
    public IActionResult ShowProduct(int ProductId)
    {
        ViewBag.Product = _context.Products.Include(t => t.ProductCategories).ThenInclude(x => x.Category).FirstOrDefault(d => d.ProductId == ProductId);
        ViewBag.ExtraCategories = _context.Categories.Include(d => d.ProductsInCategory).Where(d => d.ProductsInCategory.All(x => x.ProductId != ProductId)).ToList();
        return View();
    }

    // route to process adding a category to a product
    [HttpPost("product/category/process")]
    public IActionResult ProcessCategory(Group newGroup)
    {
        _context.Add(newGroup);
        _context.SaveChanges();
        return RedirectToAction("ShowProduct", new{ProductId = newGroup.ProductId});
    }


    // route to render a specific category page
    [HttpGet("category/show/{CategoryId}")]
    public IActionResult ShowCategory(int CategoryId)
    {
        ViewBag.Category = _context.Categories.Include(t => t.ProductsInCategory).ThenInclude(x => x.Product).FirstOrDefault(d => d.CategoryId == CategoryId);
        ViewBag.ExtraProducts = _context.Products.Include(d => d.ProductCategories).Where(d => d.ProductCategories.All(x => x.CategoryId != CategoryId)).ToList();
        return View();
    }

    // route to process adding a product to a category
    [HttpPost("category/product/process")]
    public IActionResult ProcessProduct(Group newGroup)
    {
        _context.Add(newGroup);
        _context.SaveChanges();
        return RedirectToAction("ShowCategory", new{CategoryId = newGroup.CategoryId});
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
