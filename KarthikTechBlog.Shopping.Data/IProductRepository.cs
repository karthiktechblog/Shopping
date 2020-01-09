using KarthikTechBlog.Shopping.Core;
using System.Threading.Tasks;

namespace KarthikTechBlog.Shopping.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> CommitAsync();
    }
}
