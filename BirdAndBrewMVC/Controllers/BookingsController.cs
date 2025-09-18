using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;

public class BookingsController : Controller
{

    private readonly HttpClient _client;
    
    public BookingsController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "About Bird & Brew";
        ViewData["Description"] = "Learn more about Bird & Brew – our story, our passion for food, and our love for craft beer.";
        ViewData["Keywords"] = "about Bird & Brew, restaurant story, craft beer, chicken sandwiches";

        return View();
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "About Bird & Brew";
        ViewData["Description"] = "Learn more about Bird & Brew – our story, our passion for food, and our love for craft beer.";
        ViewData["Keywords"] = "about Bird & Brew, restaurant story, craft beer, chicken sandwiches";

        return View();
    }
    
    
}