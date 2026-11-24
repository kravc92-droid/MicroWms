
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroWms.Api.Data;
using MicroWms.Domain.Entities;

namespace MicroWms.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageLocationsController : ControllerBase
{
    private readonly WmsDbContext _dbContext;

    public StorageLocationsController(WmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StorageLocation>>> GetStorageLocations()
    {
        var locations = await _dbContext.StorageLocations
            .AsNoTracking()
            .OrderBy(x => x.Code)
            .ToListAsync();

        return Ok(locations);
    }

    [HttpPost]
    public async Task<ActionResult<StorageLocation>> CreateStorageLocation(
        StorageLocation request)
    {
        var location = new StorageLocation
        {
            Id = Guid.NewGuid(),
            Code = request.Code.Trim(),
            IsOccupied = false
        };

        _dbContext.StorageLocations.Add(location);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetStorageLocations),
            new { id = location.Id },
            location);
    }

}
