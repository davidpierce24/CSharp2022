using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;

public class SurveyController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string Name, string Dojo, string Language, string Comment)
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Dojo: {Dojo}");
        Console.WriteLine($"Language: {Language}");
        Console.WriteLine($"Comment: {Comment}");
        ViewBag.Name = Name;
        ViewBag.Dojo = Dojo;
        ViewBag.Language = Language;
        ViewBag.Comment = Comment;
        return View("Submit");
    }
}