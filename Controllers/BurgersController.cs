using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodAPI2.Data;
using FoodAPI2.Models;

namespace FoodAPI2.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/burgers
public class BurgersController : ControllerBase
{
    private readonly AppDbContext _db;
    public BurgersController(AppDbContext db) => _db = db;

    [HttpGet] public async Task<IEnumerable<Burger>> Get()
        => await _db.Burgers.AsNoTracking().ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Burger>> Get(int id)
        => await _db.Burgers.FindAsync(id) is { } b ? b : NotFound();

    [HttpPost]
    public async Task<ActionResult<Burger>> Post([FromBody] Burger dto)
    {
        _db.Burgers.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Burger dto)
    {
        if (id != dto.Id) return BadRequest();
        if (!await _db.Burgers.AnyAsync(b => b.Id == id)) return NotFound();
        _db.Entry(dto).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var b = await _db.Burgers.FindAsync(id);
        if (b is null) return NotFound();
        _db.Burgers.Remove(b);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}