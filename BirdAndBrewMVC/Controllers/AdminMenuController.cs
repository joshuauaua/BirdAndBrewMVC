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
    public async Task<IActionResult> Create(CreateMenuItemVM menuItem)
    {
        if (!ModelState.IsValid)
        {
            return View(menuItem);
        }
        
        await _client.PostAsJsonAsync("menuitem", menuItem);
        
        return RedirectToAction("Index");
    }
    
    
    //First get by ID
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var item = await _client.GetFromJsonAsync<MenuItem>($"menuitem/{id}");
        
        return View(item);
    }
    
    [HttpPost]
    public async Task <IActionResult> Update(int id,  MenuItem item)
    {
        if (!ModelState.IsValid)
            return View(item);

        await _client.PutAsJsonAsync($"menuitem/{id}", item);
        
        return RedirectToAction("Index");
    }

    
    //First get by ID
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _client.GetFromJsonAsync<MenuItem>($"menuitem/{id}");

        return View(item);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeletePost(int id)
    {
        
        var response = await _client.DeleteAsync($"menuitem?id={id}");
        
        if (!response.IsSuccessStatusCode)
        {
            // Optional: handle failure
            ModelState.AddModelError(string.Empty, "Failed to delete the menu item.");
            return RedirectToAction("Index");
        }
        
        return RedirectToAction("Index");    }
    
    
    
    
}