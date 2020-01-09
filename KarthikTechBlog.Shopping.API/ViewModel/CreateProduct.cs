using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KarthikTechBlog.Shopping.API.ViewModel
{
    public class CreateProduct
    {        
        [Required]
        [MinLength(5), MaxLength(200)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? AvailableSince { get; set; }
        public int StockCount { get; set; }
        public int CategoryId { get; set; }      
    }
}
