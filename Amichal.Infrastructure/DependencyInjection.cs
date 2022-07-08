using Amichal.Application.Common.Interfaces.Authentication;
using Amichal.Application.Common.Interfaces.Services;
using Amichal.Application.Common.Interfaces.Services.Persistence;
using Amichal.Application.Common.Interfaces.Services.Persistence.Users;
using Amichal.Domain.Entities.UserRoles;
using Amichal.Infrastructure.Authentication;
using Amichal.Infrastructure.Persistence;
using Amichal.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amichal.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DBConnString"),
            x => x.MigrationsAssembly("Amichal.Api"));
        });
        return services;
    }
}
