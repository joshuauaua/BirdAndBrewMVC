using BirdAndBrewMVC.Models;
using BirdAndBrewMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;


public class AdminController : Controller
{
    private readonly HttpClient _client;
    
    public AdminController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LogIn()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    
    
   
    
    
}