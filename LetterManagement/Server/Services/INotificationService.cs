using LetterManagement.Server.Models;
using LetterManagement.Shared.Dtos;

namespace LetterManagement.Server.Services;

public interface INotificationService
{
    public Task<IEnumerable<NotificationDto>> GetAllNotificationByUserId(string userId);

    public Task CreateNotificationByUserId(NotificationDto notificationDto, string userId);

}