namespace mydotnet.Controllers;

using Microsoft.AspNetCore.Mvc;
using mydotnet.Models;
using mydotnet.Services;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // [HttpGet]
    // public string Home()
    // {
    //     return "Hello World";
    // }

    [HttpPost]
    public IActionResult Create(Dto model)
    {
        _userService.Create(model);
        return Ok(new {msg = " User Created"});
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_userService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_userService.GetById(id));
    }

    [HttpPut("{id}")]
    public IActionResult Update(Dto model, int id)
    {
        _userService.Update(model, id);
        return Ok(new {msg = " User Updated"});
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new {msg = " User Deleted"});
    }

}