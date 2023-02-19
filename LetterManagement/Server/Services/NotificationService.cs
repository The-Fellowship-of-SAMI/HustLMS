using AutoMapper;
using LetterManagement.Server.Models;
using LetterManagement.Server.Repositories;
using LetterManagement.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LetterManagement.Server.Services;

public class NotificationService:INotificationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public NotificationService(UserManager<ApplicationUser> userManager,DataContext context, IMapper mapper)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<NotificationDto>> GetAllNotificationByUserId(string userId)
    {
        var user = await this._userManager.Users.Include(x=>x.Notifications).SingleOrDefaultAsync(x => x.Id == userId);
        return _mapper.Map<IEnumerable<NotificationDto>>(user?.Notifications);
    }

    public async Task CreateNotificationByUserId(NotificationDto notificationDto, string userId)
    {
        var user = await this._userManager.FindByIdAsync(userId);
        user.Notifications.Add(_mapper.Map<Notification>(notificationDto));
        await this._userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
    }
}