using System.ComponentModel.DataAnnotations;

namespace KitKart.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(20)]
        [MaxLength(50)]
        [Display(Name ="User Name")]
        public string username { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Email")]
        public string email { get; set; }
        [Display(Name = "User Password")]
        public string password { get; set; }

        public bool isActive { get; set; }
    }
}
