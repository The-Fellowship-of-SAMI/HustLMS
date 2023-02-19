using AutoMapper;
using LetterManagement.Server.Models;
using LetterManagement.Shared.Dtos;

namespace LetterManagement.Server.MapperProfiles;

public class NotificationProfile:Profile
{
    public NotificationProfile()
    {
        CreateMap<NotificationDto, Notification>();
        CreateMap<Notification, NotificationDto>();
    }
}