using System.ComponentModel.DataAnnotations;

namespace AcademiX.Models
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
