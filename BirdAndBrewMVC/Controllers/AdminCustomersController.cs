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
    
    
    //To Create a Customer
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerVM newCustomer)
    {

        if (!ModelState.IsValid)
        {
            return View(newCustomer);
        }

        await _client.PostAsJsonAsync("customers", newCustomer);

        return RedirectToAction("Index");
    }


    
    
    //TO DELETE A CUSTOMER
    //First get by ID
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _client.GetFromJsonAsync<Customer>($"customers/{id}");

        return View(customer);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeletePost(int id)
    {
        
        var response = await _client.DeleteAsync($"customers?id={id}");
        
        if (!response.IsSuccessStatusCode)
        {
            // Optional: handle failure
            ModelState.AddModelError(string.Empty, "Failed to delete the Customer.");
            return RedirectToAction("Index");
        }

        
        return RedirectToAction("Index");    }


    
    
    
    //EDIT A CUSTOMER

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var customer = await _client.GetFromJsonAsync<Customer>($"customers/{id}");
        
        return View(customer);
    }
    
    
    //UPDATE IT WITH POST
    [HttpPost]
    public async Task<IActionResult> UpdatePost(int id, CreateCustomerVM customer)
    {
        
        if (!ModelState.IsValid)
            return View(customer);

        await _client.PutAsJsonAsync($"customers/{id}", customer);
        
        return RedirectToAction("Index");
    }
    
    
    
    
    
    
}