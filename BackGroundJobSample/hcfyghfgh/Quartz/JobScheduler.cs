using Quartz;
using Quartz.Impl;

namespace Infrastructure.Quartz;

public class JobScheduler
{
    public void Start()
    {
        Task<IScheduler> scheduler = StdSchedulerFactory.GetDefaultScheduler();

        scheduler.Start();

        IJobDetail job = JobBuilder.Create<IJob>().Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("IDGJob", "IDG")
            .WithSimpleSchedule
            (s => s
                .WithIntervalInSeconds(5)
                .RepeatForever()
            )
            .StartAt(DateTime.UtcNow)
            .WithPriority(1)
            .Build();
    }
}