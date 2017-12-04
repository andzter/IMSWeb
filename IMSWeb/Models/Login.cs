using System.ComponentModel.DataAnnotations;

namespace IMSWeb.Models
{
    public class Login  
    {

        [Required(ErrorMessage = " * Required Field")]
        [RegularExpression(@"^[a-zA-Z0-9]{8}$|^[a-zA-Z0-9]{11}$", ErrorMessage = " *Invalid User Name")]
        [Display(Name = "User Name")]

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

    }

}