
namespace MyApi.Products
{
    public class ProductsService : IProducts
    {
        public IEnumerable<Product> GetAll()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Test", Category = "Test" },
                new Product { Id = 2 }
            };
        }
    }
}
