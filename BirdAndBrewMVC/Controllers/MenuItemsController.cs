using BirdAndBrewMVC.Models;
using Microsoft.AspNetCore.Mvc;
namespace BirdAndBrewMVC.Controllers;

public class MenuItemsController : Controller
{ 
    private readonly HttpClient _client;
    
    public MenuItemsController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }
    
    public async Task<IActionResult> Index()
    {
        
        ViewData["Title"] = "About Bird & Brew";
        ViewData["Description"] = "Learn more about Bird & Brew – our story, our passion for food, and our love for craft beer.";
        ViewData["Keywords"] = "about Bird & Brew, restaurant story, craft beer, chicken sandwiches";

        
        var menuItems = await _client.GetFromJsonAsync<List<MenuItem>>("menuitem");
        return View(menuItems);    
    }
    
}