using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;

public class AdminBookingsController : Controller
{

    private readonly HttpClient _client;

    public AdminBookingsController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }

    public IActionResult Index()
    {
        return View();
    }
    
    
    
}