using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BirdAndBrewMVC.Models;

namespace BirdAndBrewMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "About Bird & Brew";
        ViewData["Description"] = "Learn more about Bird & Brew – our story, our passion for food, and our love for craft beer.";
        ViewData["Keywords"] = "about Bird & Brew, restaurant story, craft beer, chicken sandwiches";

        return View();
    }
    

    public IActionResult Privacy()
    {
        ViewData["Title"] = "About Bird & Brew";
        ViewData["Description"] = "Learn more about Bird & Brew – our story, our passion for food, and our love for craft beer.";
        ViewData["Keywords"] = "about Bird & Brew, restaurant story, craft beer, chicken sandwiches";

        return View();
    }

    
    public IActionResult About()
    {
        ViewData["Title"] = "About Bird & Brew";
        ViewData["Description"] = "Learn more about Bird & Brew – our story, our passion for food, and our love for craft beer.";
        ViewData["Keywords"] = "about Bird & Brew, restaurant story, craft beer, chicken sandwiches";

        return View();
    }

    public IActionResult Error404()
    {
        return View();
    }
    
    
}