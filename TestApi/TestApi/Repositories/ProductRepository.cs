using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using TestApi.Models;
using TestApi.Repositories.Interfaces;
using System.Text.Json;
namespace TestApi.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context) : base(context)
        {
            _context = context;
        }
 
        public async Task<IEnumerable<Product>> GetProductByCategoryNameAsync(string categoryName)
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Where(p => p.Category.Name == categoryName)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Product>> FindByNameAsync(string name)
        {
            return await _context.Products
                                 .Where(p => p.Name.Contains(name))
                                 .ToListAsync();
        }
    }
}
