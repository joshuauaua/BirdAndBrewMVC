using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;

public class TablesController : Controller
{

    private readonly HttpClient _client;

    public TablesController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }
    
    public IActionResult Index()
    {
        return View();
    }

    
    
}