using BirdAndBrewMVC.Models;
using BirdAndBrewMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;

public class AdminCustomersController : Controller
{
    
    private readonly HttpClient _client;

    public AdminCustomersController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }


    
    //Get all
    public async Task <IActionResult> Index()
    {
        var customers = await _client.GetFromJsonAsync<List<Customer>>("customers");
        return View(customers);
    }
    
    
    
    
    
    
    
    
    
}