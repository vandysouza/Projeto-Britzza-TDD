using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Britzza___v6.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Por favor entre com seu usuario.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Por favor entre com sua senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
