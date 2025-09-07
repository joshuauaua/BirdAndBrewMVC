using BirdAndBrewMVC.Models;
using BirdAndBrewMVC.ViewModels;
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

    
    //First get the form for view, showing the VM of AddMenuItemVM
    [HttpGet]
    public IActionResult Add()
    {
        return View(new AddMenuItemVM());
    }


    //Then to post the view
    [HttpPost]
    public async Task<IActionResult> Add(AddMenuItemVM model)
    {
        
        //Check if its valid, otherwise return existing view
        if (!ModelState.IsValid)
            return View(model);
        
        //Map to new items
        var newItem = new MenuItem()
        {
            Name = model.Name,
            Price = model.Price,
            Description = model.Description,
            Image = model.ImageUrl,
        };
        
        await _client.PostAsJsonAsync("menuitem", newItem);
        
        return RedirectToAction("Index");

    }
    
}