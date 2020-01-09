using KarthikTechBlog.Shopping.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarthikTechBlog.Shopping.Service
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int productId);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int productId);
    }
}
