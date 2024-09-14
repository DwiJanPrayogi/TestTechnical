using BPKB_API.Data;
using BPKB_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPKB_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BpkbController : ControllerBase
{
    private readonly DataContext _dataContext;

    private readonly ILogger<BpkbController> _logger;

    public BpkbController(ILogger<BpkbController> logger, DataContext context)
    {
        _logger = logger;
        _dataContext = context;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<Bpkb>>> Get()
    {
        var bpkbList = await _dataContext.tr_bpkb.Include(x => x.location).ToListAsync();

        if (bpkbList == null) {
            return BadRequest("No BPKB Data");
        }

        return Ok(bpkbList);
    }

        [HttpGet("{id}")]
    public async Task<ActionResult<Bpkb>> Get(string id)
    {
        var bpkb = await _dataContext.tr_bpkb.Include(x => x.location).Where(x => x.agreement_number.Equals(id)).FirstOrDefaultAsync();

        if (bpkb == null)
        {
            return BadRequest("No Bpkb Data");
        }

        return Ok(bpkb);
    }

    [HttpPost]
    public async Task<ActionResult<Bpkb>> Add(Bpkb bpkb)
    {
        _dataContext.tr_bpkb.Add(bpkb);
        await _dataContext.SaveChangesAsync();

        return Ok(bpkb);
    }

    [HttpPut]
    public async Task<ActionResult<Bpkb>> Update(Bpkb bpkb)
    {
        var bpkb_Data = await _dataContext.tr_bpkb.Where(x => x.agreement_number.Equals(bpkb.agreement_number)).FirstOrDefaultAsync();

        if (bpkb_Data == null)
        {
            return BadRequest("No Bpkb Data");
        }
        bpkb_Data.agreement_number = bpkb.agreement_number;

        await _dataContext.SaveChangesAsync();

        return Ok(bpkb);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(string id)
    {
        var bpkb_Data = await _dataContext.tr_bpkb.Where(x => x.agreement_number.Equals(id)).FirstOrDefaultAsync();

        if (bpkb_Data == null)
        {
            return BadRequest("No Bpkb Data");
        }

        _dataContext.tr_bpkb.Remove(bpkb_Data);
        await _dataContext.SaveChangesAsync();

        return Ok(bpkb_Data);
    }
}
