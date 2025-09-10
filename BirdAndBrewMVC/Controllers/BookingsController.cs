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
        return View();
    }
    
    
}