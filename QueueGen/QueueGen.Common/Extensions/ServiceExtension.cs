
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueGen.Common.Options;
using QueueGen.Common.Services;
using QueueGen.Common.Services.Abstractions;

namespace QueueGen.Common.Extensions;

public static class ServiceExtension
{
    public static void AddCommonServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Path));
        services.AddTransient<ITokenService, TokenService>();
    }
}