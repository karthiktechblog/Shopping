using KarthikTechBlog.Shopping.Core;
using KarthikTechBlog.Shopping.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarthikTechBlog.Shopping.Service
{
    public class ProductService: IProductService
    {
        public ProductService(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await ProductRepository.InsertAsync(product);
            return await ProductRepository.CommitAsync();
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            ProductRepository.Delete(productId);
            return await ProductRepository.CommitAsync();
        }

        public Task<Product> GetProductAsync(int productId)
        {
            return ProductRepository.GetByIdAsync(productId);
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return ProductRepository.GetAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            ProductRepository.Update(product);
            return await ProductRepository.CommitAsync();
        }
    }
}
