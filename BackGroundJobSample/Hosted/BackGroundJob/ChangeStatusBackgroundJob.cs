using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundService.BackGroundJob;

public class ChangeStatusBackgroundJob : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly DatabaseContext _context;

    public ChangeStatusBackgroundJob(IServiceScopeFactory serviceScopeFactory)
    {
        _context = serviceScopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>()
                   ?? throw new InvalidOperationException();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var expiredProductList = _context.Products
                .Where(product => product.ExpirationDate >= DateTime.Now)
                .ToList();

            foreach (var expiredProduct in expiredProductList)
            {
                expiredProduct.Status = "expired";
                _context.Products.Update(expiredProduct);
            }

            await _context.SaveChangesAsync(stoppingToken);

            await Task.Delay(5000, stoppingToken);
        }
    }
}