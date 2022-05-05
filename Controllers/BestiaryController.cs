using BestiaryApi.Models;
using BestiaryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestiaryApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class BestiaryController : ControllerBase
{
    BestiaryServices _bestiaryServices;

    public BestiaryController(BestiaryServices bestiaryServices)
    {
        _bestiaryServices = bestiaryServices;
    }

    [HttpGet]
    public IEnumerable<Beast> Get()
       => _bestiaryServices.GetAll();
    
    [HttpGet("{id}")]
    public ActionResult<Beast> GetById(int id)
    {
        var beast = _bestiaryServices.GetById(id);

        if(beast is not null)
            return beast;
        else
            return NotFound();
    }

    [HttpPost]
    public IActionResult Create(Beast newBeast)
    {
        var beast = _bestiaryServices.Create(newBeast);
        return CreatedAtAction(nameof(GetById), new { id = beast!.Id }, beast);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Beast beast)
    {
        var beastToUpdate = _bestiaryServices.GetById(id);

        if(beastToUpdate is not null)
        {
            _bestiaryServices.Update(id, beast);
            return NoContent();
        }
        else
            return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var beastToDelete = _bestiaryServices.GetById(id);

        if(beastToDelete is not null)
        {
            _bestiaryServices.Delete(id);
            return NoContent();
        }
        else
            return NotFound();
    }
}