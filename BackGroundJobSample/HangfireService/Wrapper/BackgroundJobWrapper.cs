using Domain;
using Hangfire;

namespace HangfireService.Wrapper;

public class BackgroundJobWrapper : IBackgroundJob
{
    private readonly DatabaseContext _context;

    public BackgroundJobWrapper(DatabaseContext context)
    {
        _context = context;
    }

    public void ExpireStatus(long productId)
    {
        var expiredProduct = _context.Products
            .First(product => product.Id == productId);

        expiredProduct.Status = "Expired";
        _context.Products.Update(expiredProduct);

        _context.SaveChanges();
    }

    public void Scheduler(int timeSpan, long productId)
    {
        BackgroundJob.Schedule(() => ExpireStatus(productId), TimeSpan.FromSeconds(timeSpan));
    }
}