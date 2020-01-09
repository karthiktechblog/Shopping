using System;

namespace KarthikTechBlog.Shopping.API.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? AvailableSince { get; set; }
        public int StockCount { get; set; }
        public int CategoryId { get; set; }
    }
}
