using BPKB_API.Data;
using BPKB_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPKB_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly DataContext _dataContext;

    private readonly ILogger<LocationController> _logger;

    public LocationController(ILogger<LocationController> logger, DataContext context)
    {
        _logger = logger;
        _dataContext = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Location>>> Get()
    {
        var locationList = await _dataContext.ms_storage_location.ToListAsync();

        if (locationList == null)
        {
            return BadRequest("No Location Data");
        }

        return Ok(locationList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Location>> Get(string id)
    {
        var location = await _dataContext.ms_storage_location.Where(x => x.location_id.Equals(id)).FirstOrDefaultAsync();

        if (location == null)
        {
            return BadRequest("No Location Data");
        }

        return Ok(location);
    }

    [HttpPost]
    public async Task<ActionResult<Location>> Add(Location location)
    {
        _dataContext.ms_storage_location.Add(location);
        await _dataContext.SaveChangesAsync();

        return Ok(location);
    }

    [HttpPut]
    public async Task<ActionResult<Location>> Update(Location location)
    {
        var locationList = await _dataContext.ms_storage_location.Where(x => x.location_id.Equals(location.location_id)).FirstOrDefaultAsync();

        if (locationList == null)
        {
            return BadRequest("No Location Data");
        }
        locationList.location_id = location.location_id;
        locationList.location_name = location.location_name;

        await _dataContext.SaveChangesAsync();

        return Ok(location);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(string id)
    {
        var locationList = await _dataContext.ms_storage_location.Where(x => x.location_id.Equals(id)).FirstOrDefaultAsync();

        if (locationList == null)
        {
            return BadRequest("No Location Data");
        }

        _dataContext.ms_storage_location.Remove(locationList);
        await _dataContext.SaveChangesAsync();

        return Ok(locationList);
    }
}
