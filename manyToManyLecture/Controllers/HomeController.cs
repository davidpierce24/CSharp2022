using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using manyToManyLecture.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace manyToManyLecture.Controllers;

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
        ViewBag.Actors = _context.Actors.ToList();
        return View();
    }

    // route to process actor addition
    [HttpPost("actor/add")]
    public IActionResult AddActor(Actor newActor)
    {
        if(ModelState.IsValid){
            _context.Add(newActor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            ViewBag.Actors = _context.Actors.ToList();
            return View("Index");
        }
    }

    // route to render movies page
    [HttpGet("movies")]
    public IActionResult Movies()
    {
        ViewBag.Movies = _context.Movies.ToList();
        return View();
    }

    // route to process movie addition
    [HttpPost("movie/add")]
    public IActionResult AddMovie(Movie newMovie)
    {
        if(ModelState.IsValid){
            _context.Add(newMovie);
            _context.SaveChanges();
            return RedirectToAction("Movies");
        } else {
            ViewBag.Movies = _context.Movies.ToList();
            return View("Movies");
        }
    }

    // route to render add to cast page
    [HttpGet("")]



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
