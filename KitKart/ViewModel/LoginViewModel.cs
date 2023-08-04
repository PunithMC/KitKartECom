using System.ComponentModel.DataAnnotations;

namespace KitKart.ViewModel
{
    public class LoginViewModel
    {
        

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Email")]
        public string email { get; set; }

        public string password { get; set; }
    }
}
