using Application.Services;
using Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class IoC
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICandidateService, CandidateService>();
        services.AddScoped<IExperienceService, ExperienceService>();
        return services;
    }
}
