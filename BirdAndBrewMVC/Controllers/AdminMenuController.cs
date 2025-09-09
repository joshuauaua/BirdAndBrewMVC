using BirdAndBrewMVC.Models;
using BirdAndBrewMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;

public class AdminMenuController : Controller
{
    
    private readonly HttpClient _client;

    public AdminMenuController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }


    public IActionResult Index()
    {
        return View();
    }
    
    
    public async Task <IActionResult> Read()
    {
        var menuItems = await _client.GetFromJsonAsync<List<MenuItem>>("api/menuitem");
        return  View(menuItems);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(AddMenuItemVM menuItem)
    {
        if (!ModelState.IsValid)
        {
            return View(menuItem);
        }
        
        var response= await _client.PostAsJsonAsync("menuitem", menuItem);

        return RedirectToAction("Index");

    }


    
    public IActionResult Update()
    {
        return View();
    }

    

    public IActionResult Delete()
    {
        return View();
    }
    
    
}