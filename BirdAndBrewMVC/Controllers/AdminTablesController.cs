using System.Net.Http.Headers;
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

        var token = HttpContext.Request.Cookies["jwtToken"];
        
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _client.GetAsync("/tables");

      if (!response.IsSuccessStatusCode)
        {
            return Unauthorized();
        }

        var tables = await response.Content.ReadFromJsonAsync<List<Table>>();
        
        return View(tables);
    }
    
    //CREATE TABLE
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTableVM table)
    {
        if (!ModelState.IsValid)
            return View(table);

        await _client.PostAsJsonAsync("tables",table);
        
        return RedirectToAction("Index");
    }
    
    
    //DELETE TABLE
    //First get by ID
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var table = await _client.GetFromJsonAsync<Table>($"tables/{id}");

        
        return View(table);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeletePost(int id)
    {
        
        var response = await _client.DeleteAsync($"tables?id={id}");
        
        if (!response.IsSuccessStatusCode)
        {
            // Optional: handle failure
            ModelState.AddModelError(string.Empty, "Failed to delete the table.");
            return RedirectToAction("Index");
        }

        
        return RedirectToAction("Index");    }

    
    //Edit TABLE
    //First get by ID
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var table = await _client.GetFromJsonAsync<Table>($"tables/{id}");
        
        return View(table);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePost(int id, ReadTableVM table)
    {
        
        var response = await _client.PutAsJsonAsync($"tables/{id}", table);

        
        if (!response.IsSuccessStatusCode)
        {
            // Optional: handle failure
            ModelState.AddModelError(string.Empty, "Failed to edit the table.");
            return RedirectToAction("Index");
        }
        
        return RedirectToAction("Index");    }


    
}