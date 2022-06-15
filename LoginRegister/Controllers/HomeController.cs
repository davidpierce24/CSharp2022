using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegister.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginRegister.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Route to the home login / register page
    public IActionResult Index()
    {
        HttpContext.Session.Clear();
        return View();
    }

    // route to process a user registration
    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid){
            // validation for unique email
            if(_context.Users.Any(d => d.Email == newUser.Email)){
                // user email already in db
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");
            }
            // validation for unique username
            if(_context.Users.Any(d => d.Username == newUser.Username)){
                // username already in db
                ModelState.AddModelError("Username", "Username is already in use!");
                return View("Index");
            }
            // password hasing
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("user", newUser.UserId);
            return RedirectToAction("Success");
        } else {
            return View("Index");
        }
    }


    // route to process a user login
    [HttpPost("user/login")]
    public IActionResult Login(LogUser loginUser)
    {
        if(ModelState.IsValid){
            return RedirectToAction("Success");
        } else {
            return View("Index");
        }
    }


    // route for successful login/register page
    [HttpGet("success")]
    public IActionResult Success()
    {
        if(HttpContext.Session.GetInt32("user") == null){
            return RedirectToAction("Index");
        }
        User loggedInUser = _context.Users.FirstOrDefault(x => x.UserId == HttpContext.Session.GetInt32("user"));
        return View();
    }



    // route for a privacy meme
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
