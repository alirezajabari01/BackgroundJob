using Domain;

namespace BackGroundJobSample.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseContext _context;

    public ProductRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public int CreateProduct(Product product)
    {
        _context.Add(product);
        return _context.SaveChanges();
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }
}