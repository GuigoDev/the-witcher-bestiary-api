using BestiaryApi.Models;
using BestiaryApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize(Roles = "root")]
    public IEnumerable<User> Get()
        => _userServices.GetAll();

    [HttpGet("{id}")]
    [Authorize(Roles = "root")]
    public ActionResult<User> GetById(int id)
    {
        var user = _userServices.GetById(id);

        if(user is not null)
            return user;
        else
            return NotFound();
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Create(User newUser)
    {
        var user = _userServices.Create(newUser);
        return CreatedAtAction(nameof(GetById), new { id = user!.Id }, user);
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User user)
    {
        var usertToAuth = _userServices.GetUser(user.Name, user.Password);

        if(usertToAuth is null)
            return NotFound(new { message = "Usuário ou senha inválidos!" });
        
        // Generate token.
        var token = TokenServices.GenerateToken(usertToAuth);

        // Hide user password.
        usertToAuth.Password = "";

        return new 
        {
            user = usertToAuth,
            token = token
        };
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "root")]
    public IActionResult UpdateUser(int id, User user)
    {
        var userToUpdate = _userServices.GetById(id);

        if(userToUpdate is not null)
        {
            _userServices.UpdateUser(id, user);
            return NoContent();
        }
        else
            return NotFound();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "root")]
    public IActionResult DeleteUser(int id)
    {
        var userToDelete = _userServices.GetById(id);

        if(userToDelete is not null)
        {
            _userServices.DeleteUser(id);
            return NoContent();
        }

        return NotFound();
    }
}