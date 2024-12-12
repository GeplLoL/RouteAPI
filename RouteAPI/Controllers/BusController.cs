using Microsoft.AspNetCore.Mvc;
using RouteAPI.Data;
using RouteAPI.Models;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class BusController : ControllerBase
{
    private readonly AppDbContext _context;

    public BusController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddBus([FromBody] Bus bus)
    {
        if (bus == null)
        {
            return BadRequest("Invalid bus data.");
        }

        _context.Buses.Add(bus);
        await _context.SaveChangesAsync();

        return Ok(bus);
    }


    [HttpPost("{busId}/routes")]
    public async Task<IActionResult> AddRoute(int busId, [FromBody] MyRoute route)
    {
        var bus = await _context.Buses.FindAsync(busId);
        if (bus == null)
            return NotFound("Bus not found");

        route.BusId = busId;
        _context.Routes.Add(route);
        await _context.SaveChangesAsync();
        return Ok(route);
    }

    [HttpGet]
    public async Task<IActionResult> GetBuses()
    {
        var buses = await _context.Buses.Include(b => b.Routes).ToListAsync();
        return Ok(buses);
    }
}
