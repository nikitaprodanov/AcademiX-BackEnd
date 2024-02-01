using AcademiX.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace AcademiX.Models
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string ConfirmPassword { get; set; } = null!;

		[Required]
		public string FirstName { get; set; } = null!;

		[Required]
		public string LastName { get; set; } = null!;
	}
}
