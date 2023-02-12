using LetterManagement.Server.Services;
using LetterManagement.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetterManagement.Server.Controllers;

[ApiController]
[Route("api/{controller}")]
public class ManagerController : ControllerBase
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetByManagerId(string id)
    {
        var manager = await this._managerService.GetByManagerId(new Guid(id));
        if (manager is not null) return Ok(manager);
        return NotFound();
    }
}