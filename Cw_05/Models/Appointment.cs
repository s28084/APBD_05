namespace Cw_05.Models;

public class Appointment
{
    public string Date { get; set; }
    public Pet Pet { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}