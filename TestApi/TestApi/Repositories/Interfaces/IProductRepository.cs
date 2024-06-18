using TestApi.Models;

namespace TestApi.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByCategoryNameAsync(string categoryName);
    }
}
