using BackgroundService.BackGroundJob;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundService;

public static class DependencyInjection
{
    public static void AddHostedSample(this IServiceCollection services)
    {
        services.AddHostedService<ChangeStatusBackgroundJob>();
    }
}