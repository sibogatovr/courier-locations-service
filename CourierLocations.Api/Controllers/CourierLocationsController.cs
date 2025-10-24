using CourierLocations.Domain.Entities;
using CourierLocations.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourierLocations.Controllers;

[ApiController]
[Route("api/couriers/{courierId}/locations")]
public class CourierLocationsController(
    IDbContextFactory<CourierLocationsDbContext> dbContextFactory)
    : Controller
{
    [HttpPost]
    public async Task<IActionResult> ReceiveLocations([FromBody] IEnumerable<Location> locations)
    {
        var locationsArray = locations.ToArray();
        
        var dbContext = await dbContextFactory.CreateDbContextAsync();
        dbContext.Locations.AddRange(locationsArray);
        await dbContext.SaveChangesAsync();
        return Ok("Success");
    }
}