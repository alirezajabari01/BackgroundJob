using Domain;
using Quartz;

namespace Infrastructure.Quartz;

public class Job : IJob
{
    private readonly DatabaseContext _context;

    public Job(DatabaseContext context)
    {
        _context = context;
    }
    public async Task Execute(IJobExecutionContext jobExecutionContext)
    {
        var expiredProductList = _context.Products
            .Where(product => product.ExpirationDate >= DateTime.Now)
            .ToList();

        foreach (var product in expiredProductList)
        {
            product.Status = "Expired";
            _context.Update(product);
        }

        await _context.SaveChangesAsync();
    }
}