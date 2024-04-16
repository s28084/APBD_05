using Cw_05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw_05.Controllers;

[Route("api/pets")]
[ApiController]
public class PetsController : ControllerBase
{

    private static readonly List<Pet> _pets = new()
    {
        new Pet { Id = 1, Name = "Abby", Category = "Cat", Weight = 3.21, Color = "Black"},
        new Pet { Id = 2, Name = "Baxter", Category = "Dog", Weight = 12.5, Color = "Brown"},
        new Pet { Id = 3, Name = "Cleo", Category = "Parrot", Weight = 0.85, Color = "Green"},
        new Pet { Id = 4, Name = "Daisy", Category = "Rabbit", Weight = 2.2, Color = "White"},
        new Pet { Id = 5, Name = "Eli", Category = "Fish", Weight = 0.1, Color = "Gold"}
    };
    
    [HttpGet]
    public IActionResult GetPets()
    {
        return Ok(_pets);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetPet(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        if (pet == null)
        {
            return NotFound($"Pet with id {id} was not found");
        }

        return Ok(pet);
    }
    
    [HttpPost]
    
}