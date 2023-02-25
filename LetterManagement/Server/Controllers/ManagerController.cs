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
    public async Task<ActionResult<Manager>> GetByManagerId(string id)
    {
        var manager = await this._managerService.GetByManagerId(new Guid(id));
        if (manager is not null) return Ok(manager);
        return NotFound();
    }

    [HttpGet("department/{id}")]
    public async Task<ActionResult<Manager>> GetManagersByDepartmentId(string id)
    {
        try
        {
            var managers = await this._managerService.GetManagersByDepartmentId(new Guid(id));
            return Ok(managers);
        }
        catch
        {
            return NotFound();
        }
    }
}