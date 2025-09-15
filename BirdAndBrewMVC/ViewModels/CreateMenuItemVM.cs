using System.ComponentModel.DataAnnotations;

namespace BirdAndBrewMVC.ViewModels;

public class CreateMenuItemVM
{
    
    [Display(Name ="Menu Item Name")]
    [Required, StringLength(100)]
    public string Name { get; set; }
    
    [Required, StringLength(500)]
    public string Description { get; set; }
   
    [Required]
    [Range(0 , 5000, ErrorMessage = "Illegal number")]
    public int Price { get; set; }
    
    [Display(Name ="Link to image")]
    public string? Image { get; set; }
    
    [Display(Name="Popular Dish?")]
    public bool IsPopular { get; set; }
    
}