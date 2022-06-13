using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using linqEruption.Models;

namespace linqEruption.Controllers;

public class HomeController : Controller
{
    List<Eruption> eruptions = new List<Eruption>()
    {
        new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
        new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
        new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
        new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
        new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
        new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
        new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
        new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
        new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
        new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
        new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
        new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
        new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
    };

    // Example Query - Prints all Stratovolcano eruptions
    // IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
    // PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
    // Execute Assignment Tasks here!
    
    // Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
    static void PrintEach(IEnumerable<dynamic> items, string msg = "")
    {
        Console.WriteLine("\n" + msg);
        foreach (var item in items)
        {
            Console.WriteLine(item.ToString());
        }
    }

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // find first eruption in Chile
        Eruption firstChile = eruptions.FirstOrDefault(d => d.Location == "Chile");
        ViewBag.firstChile = firstChile;

        // first eruption in hawaii
        Eruption firstHawaiian = eruptions.FirstOrDefault(d => d.Location == "Hawaiian Is");
        ViewBag.firstHawaiian = firstHawaiian;

        // first eruption after 1900 and in New Zealand
        Eruption firstNewZealand = eruptions.FirstOrDefault(d => d.Location == "New Zealand" && d.Year > 1900);
        ViewBag.firstNewZealand = firstNewZealand;

        // all eruptions where volcano elevation is over 2000m
        List<Eruption> highElevation = eruptions.Where(d => d.ElevationInMeters > 2000).ToList();
        ViewBag.highElevation = highElevation;

        // all eruptions that start with Z
        List<Eruption> startsWithZ = eruptions.Where(d => d.Volcano.StartsWith("K")).ToList();
        ViewBag.startsWithZ = startsWithZ;

        // highest elevation
        int highest = eruptions.Max(d => d.ElevationInMeters);
        ViewBag.highest = highest;

        // find volcano with highest elevation
        Eruption tallestVolcano = eruptions.FirstOrDefault(d => d.ElevationInMeters == highest);
        ViewBag.tallestVolcano = tallestVolcano;

        // all volcanos alphabetically
        List<Eruption> allVolcanos = eruptions.OrderBy(d => d.Volcano).ToList();
        ViewBag.allVolcanos = allVolcanos;

        // all eruptions before 1000 CE alphabetically by volcano name
        List<Eruption> eruptionsBefore1000 = eruptions.Where(d => d.Year < 1000).OrderBy(d => d.Volcano).ToList();
        ViewBag.eruptionsBefore1000 = eruptionsBefore1000;

        // all eruptions before 1000 CE alphabetically by volcano name
        List<string> eruptionsBefore1000Better = eruptions.Where(d => d.Year < 1000).OrderBy(d => d.Volcano).Select(d => d.Volcano).ToList();
        ViewBag.eruptionsBefore1000Better = eruptionsBefore1000Better;

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
