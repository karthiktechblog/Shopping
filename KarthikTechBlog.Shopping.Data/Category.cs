using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KarthikTechBlog.Shopping.Data
{    
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(200)]
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
