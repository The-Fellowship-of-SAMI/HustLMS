using LetterManagement.Server.Models;
using LetterManagement.Server.Repositories;
using LetterManagement.Server.Services;

namespace LetterManagement.Server.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityCore<ApplicationUser>(opt =>
        {
            opt.SignIn.RequireConfirmedEmail = false;
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequireDigit = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireLowercase = false;

        }).AddEntityFrameworkStores<DataContext>();
        services.AddAuthentication();
        services.AddScoped<TokenService>();
        return services;
    }
}