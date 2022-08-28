namespace HangfireService.Wrapper;

public interface IBackgroundJob
{
    void ExpireStatus(long productId);
    void Scheduler(int timeSpan,long productId);
}