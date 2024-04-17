using Cw_05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw_05.Controllers;

[Route("api/appointments")]
[ApiController]

public class AppointmentsController : ControllerBase
{
    private static readonly List<Appointment> _appointments = new()
    {
        new Appointment { Date = "16-04-2024 16:00", PetId = 1, Description = "vaccination", Price = 155.60 },
        new Appointment { Date = "17-04-2024 10:30", PetId = 1, Description = "annual check-up", Price = 120.00 },
        new Appointment { Date = "18-04-2024 14:15", PetId = 3, Description = "annual check-up", Price = 30.50 },
        new Appointment { Date = "19-04-2024 08:00", PetId = 1, Description = "vaccination", Price = 90.75 },
        new Appointment { Date = "20-04-2024 11:00", PetId = 4, Description = "health screening", Price = 210.00 }
    };

    [HttpGet]
    public IActionResult GetAppointment()
    {
        return Ok(_appointments);
    }

    [HttpGet("{petId:int}")]
    public IActionResult GetAppointment(int petId)
    {
        
        var appointment = _appointments.Where(a => a.PetId == petId).ToList();
        var pet = _appointments.FirstOrDefault(p => p.PetId == petId);
        if ((appointment.Any() == false) || (pet == null))
        {
            return NotFound($"Pet with id {petId} has no appointments");
        }

        return Ok(appointment);
    }

    [HttpPost]
    public IActionResult CreateAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{date:string}/{petId:int}")]
    public IActionResult UpdateAppointment(string date, int petId, Appointment appointment)
    {
        var appointmentToEdit = _appointments.FirstOrDefault(a => ((a.PetId == petId) && (a.Date == date)));
        if (appointmentToEdit == null)
        {
            return NotFound($"No Appointment found on {date} for pet with id {petId}");
        }

        _appointments.Remove(appointmentToEdit);
        _appointments.Add(appointment);
        return NoContent();

    }

    [HttpDelete("{date:string}/{petId:int}")]
    public IActionResult DeleteAppointment(string date, int petId)
    {
        var appointmentToDelete = _appointments.FirstOrDefault(a => ((a.PetId == petId) && (a.Date == date)));
        if (appointmentToDelete == null)
        {
            return NotFound($"No Appointment found on {date} for pet with id {petId}");
        }

        _appointments.Remove(appointmentToDelete);
        return NoContent();
    }
    
    
    
    
}