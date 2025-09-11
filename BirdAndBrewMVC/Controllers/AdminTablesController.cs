using BirdAndBrewMVC.Models;
using BirdAndBrewMVC.ViewModels;
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
        
        return View(tables);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddTableVM table)
    {
        if (!ModelState.IsValid)
            return View(table);

        await _client.PostAsJsonAsync("tables",table);
        
        return RedirectToAction("Index");
    }
    
}