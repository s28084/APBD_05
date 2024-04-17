using Cw_05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw_05.Controllers;

[Route("api/appointments")]
[ApiController]

public class AppointmentsController
{
    private static readonly List<Appointment> _appointments = new()
    {
        new Appointment { Date = "16-04-2024 16:00", PetId = 1, Description = "vaccination", Price = 155.60 },
        new Appointment { Date = "17-04-2024 10:30", PetId = 1, Description = "annual check-up", Price = 120.00 },
        new Appointment { Date = "18-04-2024 14:15", PetId = 3, Description = "annual check-up", Price = 30.50 },
        new Appointment { Date = "19-04-2024 08:00", PetId = 1, Description = "vaccination", Price = 90.75 },
        new Appointment { Date = "20-04-2024 11:00", PetId = 4, Description = "health screening", Price = 210.00 }
    };
    
    
    
    
}