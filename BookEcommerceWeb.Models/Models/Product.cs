using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.Models.Models
{
    public class Product : BaseModel
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Price50 { get; set; }
        [Required]
        public double Price100 { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
