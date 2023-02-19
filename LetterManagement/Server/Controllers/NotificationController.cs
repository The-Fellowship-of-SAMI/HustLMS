using LetterManagement.Server.Models;
using LetterManagement.Server.Services;
using LetterManagement.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LetterManagement.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetNotificationByUserId(string userId)
    {
        try
        {
            var notifications = await this._notificationService.GetAllNotificationByUserId(userId);
            return Ok(notifications);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpPost("{userId}")]
    public async Task<ActionResult> CreateNotificationByUserId(string userId, [FromBody] NotificationDto notificationDto)
    {
        try
        {
            await this._notificationService.CreateNotificationByUserId(notificationDto, userId);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}