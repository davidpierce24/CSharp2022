using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using loginRegLecture.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

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
        HttpContext.Session.Clear();
        return View();
    }

    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(_context.Users.Any(x => x.Email == newUser.Email))
            {
                // problem user is already in db
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");
            }
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

    [HttpPost("user/login")]
    public IActionResult Login(LogUser loginUser)
    {
        if (ModelState.IsValid)
        {
            // find email and throw error if we can't
            User userInDb = _context.Users.FirstOrDefault(a => a.Email == loginUser.LogEmail);
            if (userInDb == null)
            {
                // there was no email in the database
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
            var result = Hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);

            if(result == 0)
            {
                // password wasn't correct
                ModelState.AddModelError("LogEmail", "Invalid Login attempt");
                return View("Index");
            }
            HttpContext.Session.SetInt32("user", userInDb.UserId);
            return RedirectToAction("Success");
        } else {
            return View("Index");
        }
    }

    [HttpGet("success")]
    public IActionResult Success()
    {
        User loggedInUser = _context.Users.FirstOrDefault(x => x.UserId == HttpContext.Session.GetInt32("user"));
        if(HttpContext.Session.GetInt32("user") == null)
        {
            return RedirectToAction("Index");
        }
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
