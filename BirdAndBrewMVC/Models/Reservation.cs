using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirdAndBrewMVC.Models;

public class Reservation
{

    public int Id { get; set; }
    
    public int NumberOfGuests { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public DateTime ReservationStartTime { get; set; }
    
    public DateTime ReservationEndTime { get; set; }
    
    //FK Customer
    public int FK_CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    //FK Table
    public int Fk_TableId { get; set; }
    public Table Table { get; set; }

    
    
    
}