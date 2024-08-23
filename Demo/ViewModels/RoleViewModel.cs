using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
