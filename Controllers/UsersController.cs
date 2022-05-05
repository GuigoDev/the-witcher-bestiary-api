using BestiaryApi.Models;
using BestiaryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestiaryApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UsersController : ControllerBase
{
    UserServices _userServices;

    public UsersController(UserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet]
    public IEnumerable<User> Get()
        => _userServices.GetAll();

    [HttpGet("{id}")]
    public ActionResult<User> GetById(int id)
    {
        var user = _userServices.GetById(id);

        if(user is not null)
            return user;
        else
            return NotFound();
    }

    [HttpPost]
    public IActionResult Create(User newUser)
    {
        var user = _userServices.Create(newUser);
        return CreatedAtAction(nameof(GetById), new { id = user!.Id }, user);
    }
}