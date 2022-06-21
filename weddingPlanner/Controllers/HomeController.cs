using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using weddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace weddingPlanner.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Route to render home login page
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
            // password hasing
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("user", newUser.UserId);
            return RedirectToAction("Dashboard");
        } else {
            return View("Index");
        }
    }


    // route to process a user login
    [HttpPost("user/login")]
    public IActionResult Login(LogUser loginUser)
    {
        if(ModelState.IsValid){
            // check to see if email is in db
            User userInDb = _context.Users.FirstOrDefault(d => d.Email == loginUser.LogEmail);
            if(userInDb == null){
                // no email in database
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            // check for hashed password
            PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
            var result = Hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);
            // if password was incorrect
            if(result == 0){
                ModelState.AddModelError("LogEmail", "Invalid login attempt");
                return View("Index");
            }
            HttpContext.Session.SetInt32("user", userInDb.UserId);
            return RedirectToAction("Dashboard");
        } else {
            return View("Index");
        }
    }

    // route for successful login/register page
    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetInt32("user") == null){
            return RedirectToAction("Index");
        }
        User loggedInUser = _context.Users.FirstOrDefault(x => x.UserId == HttpContext.Session.GetInt32("user"));

        // display all weddings on dashboard
        ViewBag.Weddings = _context.Weddings.Include(d => d.Attendees).ToList();
        ViewBag.User = loggedInUser;

        return View();
    }

    // route to display add a wedding form
    [HttpGet("wedding/add")]
    public IActionResult AddWedding()
    {
        return View();
    }

    // route to process wedding addition
    [HttpPost("wedding/process")]
    public IActionResult ProcessWedding(Wedding newWedding)
    {
        if(ModelState.IsValid){
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        } else {
            return View("AddWedding");
        }
    }

    // route to rsvp to a wedding
    [HttpPost("/rsvp/process")]
    public IActionResult ProcessRSVP(Connection rsvp)
    {
        _context.Add(rsvp);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // route to unrsvp
    [HttpGet("unrsvp/{WeddingId}/{UserId}")]
    public IActionResult UnRSVP(int WeddingId, int UserId)
    {
        Connection UnRSVP = _context.Connections.FirstOrDefault(x => x.WeddingId == WeddingId && x.UserId == UserId);
        _context.Connections.Remove(UnRSVP);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // route to delete a wedding
    [HttpGet("wedding/delete/{WeddingId}")]
    public IActionResult DeleteWedding(int WeddingId)
    {
        Wedding deleteWedding = _context.Weddings.SingleOrDefault(x => x.WeddingId == WeddingId);
        _context.Weddings.Remove(deleteWedding);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
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
