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
    
    
    public async Task <IActionResult> Index()
    {
        var menuItems = await _client.GetFromJsonAsync<List<MenuItem>>("menuitem");
        return  View(menuItems);
    }
    
    
    //Get the form
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    //Send the inputs of the form
    [HttpPost]
    public async Task<IActionResult> Create(AddMenuItemVM menuItem)
    {
        if (!ModelState.IsValid)
        {
            return View(menuItem);
        }
        
        var response= await _client.PostAsJsonAsync("menuitem", menuItem);

        Console.WriteLine(response);

        return RedirectToAction("Index");
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {

        var item = await _client.GetFromJsonAsync<MenuItem>($"menuitem/{id}");
        
        return View(item);
    }
    
    [HttpPost]
    public async Task <IActionResult> Update(int id,  MenuItem model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _client.PutAsJsonAsync($"menuitem/{id}", model);
        
        return RedirectToAction("Index");
    }

    

    public IActionResult Delete()
    {
        return View();
    }
    
    
}