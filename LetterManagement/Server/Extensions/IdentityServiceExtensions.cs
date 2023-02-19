using System.Text;
using LetterManagement.Server.Models;
using LetterManagement.Server.Repositories;
using LetterManagement.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this-is-a-secret-key"));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        services.AddScoped<TokenService>();
        return services;
    }
}