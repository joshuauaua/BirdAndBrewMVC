using BirdAndBrewMVC.Models;
using BirdAndBrewMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;


public class AdminController : Controller
{
    private readonly HttpClient _client;
    
    public AdminController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }
    
    [Authorize]
    public IActionResult Dashboard()
    {
        return View();
    }

    
    
   
    
    
}