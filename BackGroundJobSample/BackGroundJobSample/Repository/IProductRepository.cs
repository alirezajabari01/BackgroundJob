using Domain;

namespace BackGroundJobSample.Repository;

public interface IProductRepository
{
    int CreateProduct(Product product);
    List<Product> GetAll();
}