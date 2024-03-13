using System.ComponentModel.DataAnnotations;

namespace electroMVC.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string? BrandName { get; set; }
    }
}
