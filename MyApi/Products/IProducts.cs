namespace MyApi.Products;

public interface IProducts
{
    IEnumerable<Product> GetAll();
}
