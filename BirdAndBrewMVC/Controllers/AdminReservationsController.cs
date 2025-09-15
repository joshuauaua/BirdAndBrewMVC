using BirdAndBrewMVC.Models;
using BirdAndBrewMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;

public class AdminReservationsController : Controller
{

    private readonly HttpClient _client;

    public AdminReservationsController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }
    
    
    //GET ALL BOOKINGS
    public async Task<IActionResult> Index()
    {
        var reservation = await _client.GetFromJsonAsync<List<ReadReservationVM>> ("reservations");
        
        return View(reservation);
    }
    
    
    //CREATE A BOOKING
    //Get first
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    //POST
    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationVM reservationVM)
    {

        if (!ModelState.IsValid)
            return View(reservationVM);
        
        await _client.PostAsJsonAsync("reservations", reservationVM);
        
        return RedirectToAction("Index");
    }
    
    
    
    
    //DELETE BOOKING
    
    //GET FIRST
    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        var reservation = await _client.GetFromJsonAsync<Reservation>($"reservations/{Id}"); 
        
        return View(reservation);
    }

    //Delete 
    [HttpPost]
    public async Task<IActionResult> DeletePost(int Id)
    {
        var response = await _client.DeleteAsync($"reservations?id={Id}");
        
        if (!response.IsSuccessStatusCode)
        {
            // Optional: handle failure
            ModelState.AddModelError(string.Empty, "Failed to delete the reservation.");
            return RedirectToAction("Index");
        }
        
        return RedirectToAction("Index");  
    }



    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var reservation = await _client.GetFromJsonAsync<Reservation>($"reservations/{id}");
        
        return View(reservation);

    }

    [HttpPost]
    public async Task<IActionResult> UpdatePost(int id, CreateReservationVM reservationVM)
    {
        var response = await _client.PutAsJsonAsync($"reservations/{id}", reservationVM);
        
        if (!response.IsSuccessStatusCode)
        {
            // Optional: handle failure
            ModelState.AddModelError(string.Empty, "Failed to edit the reservation.");
            return RedirectToAction("Index");
        }
        
        return RedirectToAction("Index");
        
    }

    
    
    
}