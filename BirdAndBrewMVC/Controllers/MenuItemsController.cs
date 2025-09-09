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
        var menuItems = await _client.GetFromJsonAsync<List<MenuItem>>("api/menuitem");
        return View(menuItems);    
    }
    
}