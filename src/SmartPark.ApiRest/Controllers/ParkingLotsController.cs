using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartPark.Data;
using SmartPark.Data.Entities;

namespace SmartPark.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkingLotsController : ControllerBase
{
    private readonly SmartParkDbContext _db;
    public ParkingLotsController(SmartParkDbContext db) => _db = db;

    // GET: /api/ParkingLots
    [HttpGet]
    public async Task<ActionResult<List<ParkingLot>>> GetAll()
        => await _db.ParkingLots.Include(p => p.Spots).ToListAsync();

    // GET: /api/ParkingLots/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ParkingLot>> GetById(int id)
    {
        var item = await _db.ParkingLots
            .Include(p => p.Spots)
            .FirstOrDefaultAsync(p => p.ParkingLotId == id);

        return item is null ? NotFound() : item;
    }

    // POST: /api/ParkingLots
    [HttpPost]
    public async Task<ActionResult<ParkingLot>> Create(ParkingLot input)
    {
        _db.ParkingLots.Add(input);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = input.ParkingLotId }, input);
    }

    // PUT: /api/ParkingLots/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ParkingLot input)
    {
        var item = await _db.ParkingLots.FindAsync(id);
        if (item is null) return NotFound();

        item.Name = input.Name;
        item.Address = input.Address;
        item.Capacity = input.Capacity;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: /api/ParkingLots/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.ParkingLots.FindAsync(id);
        if (item is null) return NotFound();

        _db.ParkingLots.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
