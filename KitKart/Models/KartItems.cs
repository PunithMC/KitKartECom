using System.ComponentModel.DataAnnotations;

namespace KitKart.Models
{
    public class KartItems
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Item Name is Required")]
        [StringLength(50)]
        public  String itemName { get; set; }
        [Required(ErrorMessage = "Category is required")]

        public int CategoryId { get; set; }

        [Display(Name ="Category name")]
        public Category category { get; set; }
        [Required(ErrorMessage = "Please enter the Quantity")]
        public int quantity { get; set; }
        [Required(ErrorMessage = "Enter Price")]
        public decimal price { get; set; }

        public  String description { get; set; }
    }
}
