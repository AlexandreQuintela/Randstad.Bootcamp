using Domain.Interfaces.Repository.Bootcamp;
using Microsoft.Extensions.DependencyInjection;
using Repository.Bootcamp;

namespace Repository;

public static class IoC
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkBootcamp, UnitOfWorkBootcamp>();
        return services;
    }
}
