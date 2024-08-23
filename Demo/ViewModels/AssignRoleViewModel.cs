using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModels
{
    public class AssignRoleViewModel
    {
        [Required]
        public string UserName { get; set; }

        public string RoleName { get; set; }
    }
}
