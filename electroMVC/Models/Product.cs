using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electroMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductDescription { get; set;}
        [Required]
        public string? ProductImage { get; set;}
        [Required]
        public decimal? ProductPrice { get; set;}
        [Required]
        public int ProductQuantity { get; set;}


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand? brand { get; set;}


    }
}
