using Domain;
using HangfireService.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace BackGroundJobSample.Controllers;

[Route("api/[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IBackgroundJob _backgroundJob;

    public ProductController(DatabaseContext context, IBackgroundJob backgroundJob)
    {
        _context = context;
        _backgroundJob = backgroundJob;
    }

    [HttpPost]
    public IActionResult CreateProduct()
    {
        var product = new Product
        {
            Name = "x",
            ExpirationDate = DateTime.Now + TimeSpan.FromSeconds(2),
            Status = "Pending"
        };

        _context.Products.Add(product);
        _context.SaveChanges();

        var timeForExpire = product.ExpirationDate.Second - DateTime.Now.Second;
        _backgroundJob.Scheduler(timeForExpire, product.Id);

        return Ok(_context.Products.ToList());
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Products.ToList());
    }
}