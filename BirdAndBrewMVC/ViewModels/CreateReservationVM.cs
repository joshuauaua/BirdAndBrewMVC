using System.ComponentModel.DataAnnotations;

namespace BirdAndBrewMVC.ViewModels;

public class CreateReservationVM
{
    
    [Required]
    [Display(Name ="Number of Guests")]
    public int NumberOfGuests { get; set; }
    
    [Required]
    [Display(Name ="Reservation Date")]
    public DateTime ReservationDate { get; set; }
    
    [Required]
    [Display(Name ="Reservation Time")]
    public DateTime ReservationStartTime { get; set; }
    
    [Required]
    [Display(Name ="Customer ID")]
    public int FK_CustomerId { get; set; }
    
    [Required]
    [Display(Name ="Table ID")]
    public int Fk_TableId { get; set; }
}