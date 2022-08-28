using Hangfire;
using HangfireService.Wrapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace HangfireService;

public static class DependencyInjection
{
    public static void AddHangfireService(this IServiceCollection services)
    {
        services.AddScoped<IBackgroundJob, BackgroundJobWrapper>();
        services.AddHangfire((serviceProvider, configuration) =>
        {
            configuration.UseSerializerSettings
            (
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        });
        
        services.AddHangfireServer();
        GlobalConfiguration.Configuration.UseSqlServerStorage(
            "yourConnectionString");
        
        GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute {Attempts = 5});
       
    }
}