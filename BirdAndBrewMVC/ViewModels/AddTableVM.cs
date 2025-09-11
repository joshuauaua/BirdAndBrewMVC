using System.ComponentModel.DataAnnotations;

namespace BirdAndBrewMVC.ViewModels;

public class AddTableVM
{
    
    public int Id { get; set; }
    
    [Required]
    [Range(0,100, ErrorMessage = "Illegal number")]
    public int TableNumber { get; set; }
    
    [Required]
    [Range(0,100, ErrorMessage = "Illegal number")]
    public int Capacity { get; set; }
}