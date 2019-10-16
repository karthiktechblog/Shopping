using System.ComponentModel.DataAnnotations;

namespace KarthikTechBlog.Shopping.Core
{
    public class ProductImages
    {
        public int Id { get; set; }
        [Required]
        [MinLength(128), MaxLength(128)]
        public string ImageId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Status Status { get; set; }
    }
}
