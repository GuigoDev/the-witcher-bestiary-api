using Bestiary.Models;
using Bestiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bestiary.Controller;

[ApiController]
[Route("api/[controller]")]
public class BestiaryController : ControllerBase
{
    private readonly BestiaryServices _bestiaryServices;

    public BestiaryController(BestiaryServices bestiaryServices)
        => _bestiaryServices = bestiaryServices;

    [HttpGet]
    public async Task<List<Beast>> Get()
        => await _bestiaryServices.GetBeastsAsync();
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Beast>> Get(string id)
    {
        var beast = await _bestiaryServices.GetBeastAsync(id);

        if(beast is null)
            return NotFound();
        
        return beast;
    }

    [HttpPost("{id:lenght(24)}")]
    public async Task<IActionResult> Post(Beast beastToCreate)
    {
        await _bestiaryServices.CreateAsync(beastToCreate);

        return CreatedAtAction(nameof(Get), new {id = beastToCreate.Id }, beastToCreate);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, Beast beastToUpdate)
    {
        var beast = await _bestiaryServices.GetBeastAsync(id);

        if(beast is null)
            return NotFound();
        
        await _bestiaryServices.UpdateAsync(id, beastToUpdate);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Remove(string id)
    {
        var beastToDelete = await _bestiaryServices.GetBeastAsync(id);

        if(beastToDelete is null)
            return NotFound();
        
        await _bestiaryServices.RemoveAsync(id);

        return NoContent();
    }
}