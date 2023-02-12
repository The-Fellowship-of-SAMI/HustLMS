using LetterManagement.Server.Repositories;
using LetterManagement.Server.Services;
using Microsoft.EntityFrameworkCore;

namespace LetterManagement.Server.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            }));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILetterTemplateService, LetterTemplateService>();
            services.AddScoped<ILetterService, LetterService>();
            services.AddScoped<IManagerService, ManagerService>();
            return services;
        }
    }
}
