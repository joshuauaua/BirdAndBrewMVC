using BirdAndBrewMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;

public class AdminTablesController : Controller
{
    private readonly HttpClient _client;

    public AdminTablesController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }
    
    public async Task<IActionResult> Index()
    {
        var tables = await _client.GetFromJsonAsync<List<Table>>("tables");


        Console.WriteLine(tables);
        
        return View(tables);
    }
    
    
}