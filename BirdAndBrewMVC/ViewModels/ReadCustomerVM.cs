using System.ComponentModel.DataAnnotations;

namespace BirdAndBrewMVC.ViewModels;

public class ReadCustomerVM
{
    [Required]
    public int Id { get; set; }
    
    [Required, StringLength(30)]
    [Display(Name ="First Name")]
    public string FirstName { get; set; }
    
    [Required, StringLength(30)]
    [Display(Name ="Last Name")]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name ="Email Address")]
    public string EmailAddress { get; set; }
    
    [Required]
    [Phone]
    [Display(Name ="Phone Number")]
    public string PhoneNumber { get; set; }
}