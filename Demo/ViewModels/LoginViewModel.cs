using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
