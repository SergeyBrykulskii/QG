using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace QueueGen.Core.Extensions;

public static class ServiceExtension
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}