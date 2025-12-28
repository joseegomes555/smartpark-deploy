using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartPark.Data;

namespace SmartPark.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpotsController : ControllerBase
{
    private readonly SmartParkDbContext _db;
    public SpotsController(SmartParkDbContext db) => _db = db;

    // GET: /api/Spots
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _db.Spots.ToListAsync());

    // PUT: /api/Spots/1/status  body: "occupied"
    [HttpPut("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
    {
        var spot = await _db.Spots.FindAsync(id);
        if (spot is null) return NotFound();

        var allowed = new[] { "free", "occupied", "unknown" };
        if (!allowed.Contains(status))
            return BadRequest("Status must be: free | occupied | unknown");

        spot.Status = status;
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
