using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using BirdAndBrewMVC.Models;
using BirdAndBrewMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BirdAndBrewMVC.Controllers;

public class AccountController : Controller
{

    private readonly HttpClient _client;

    public AccountController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("BirdAndBrewApi");
    }
    
    // GET
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginUser)
    {
        var response = await _client.PostAsJsonAsync("auth/Login", loginUser);

        if (!response.IsSuccessStatusCode)
        {
            return View(loginUser);
        }
        
        var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
        var jwt = tokenResponse.Token;
        
        var handler = new JwtSecurityTokenHandler();
        var jwtObject = handler.ReadJwtToken(jwt);

        HttpContext.Response.Cookies.Append("jwtToken", jwt, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = jwtObject.ValidTo
        });
        
        return RedirectToAction("Dashboard", "Admin");
    }



    public async Task<IActionResult> Logout()
    {
        HttpContext.Response.Cookies.Delete("jwtToken");
        return RedirectToAction("Login", "Account");

    }
    
    
}