using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KarthikTechBlog.Shopping.Core
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(200)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? AvailableSince { get; set; }
        public int StockCount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductImages> ProductImages { get; set; }
        public Status Status { get; set; }

    }
}
