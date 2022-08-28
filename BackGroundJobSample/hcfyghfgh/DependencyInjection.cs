using Infrastructure.Quartz;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddQuartzService(this IServiceCollection service)
    {
        /*service.AddQuartz
        (
            options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
                var jobKey = new JobKey(nameof(Job));
                options.AddJob<Job>
                (
                    op => op.WithIdentity(jobKey)
                );

                options.AddTrigger
                (
                    trigger => trigger.ForJob(jobKey)
                        .WithIdentity("Job-Trigger")
                        .WithSimpleSchedule
                        (
                            timeSpan =>
                                timeSpan
                                    .WithIntervalInSeconds(5)
                                    .RepeatForever()
                        )
                );
            }
        );*/

        /*service.AddQuartzServer
        (
            options =>
                options.WaitForJobsToComplete = true
        );*/
    }
}