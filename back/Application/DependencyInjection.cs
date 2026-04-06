using Application.Services;
using Microsoft.Extensions.DependencyInjection;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IClassmateService, ClassmateService>();
        return services;
    }
}