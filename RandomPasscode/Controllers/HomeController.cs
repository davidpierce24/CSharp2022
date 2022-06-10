using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.Clear();
        return View();
    }

    [HttpGet("passcode")]
    public IActionResult Passcode()
    {
        if(HttpContext.Session.GetInt32("Count") == null){
            HttpContext.Session.SetInt32("Count", 1);
        } else {
            int? original = HttpContext.Session.GetInt32("Count");
            HttpContext.Session.SetInt32("Count", (int)original + 1);
        }
        List<char> pass = new List<char>();
        string what = "ABCDEFGHIJKLMPNOQRSTUVWXYZ1234567890";
        Random rand = new Random();
        for(int i = 0; i < 14; i++){
            pass.Add(what[rand.Next(0,what.Length)]);
        }
        string result = string.Join("", pass.ToArray());
        HttpContext.Session.SetString("Result", result);
        return View("Index");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
