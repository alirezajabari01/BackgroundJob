using BackGroundJobSample.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace BackGroundJobSample.Controllers;

[Route("api/[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody]Product product)
    {
        return Ok(_repository.CreateProduct(product));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repository.GetAll());
    }
}