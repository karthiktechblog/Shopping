using KarthikTechBlog.Shopping.Core;
using System.Threading.Tasks;

namespace KarthikTechBlog.Shopping.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ShoppingDbContext _context;
        public ProductRepository(ShoppingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
