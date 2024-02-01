using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcademiX.Models
{
	public class ThesisSupervisor
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[EmailAddress]
		public string Email { get; set; } = null!;
        public int Cabinet { get; set; }
		public string WorkingTime { get; set; } = null!;
        public bool IsReviewer { get; set; }

		[Required]
		public int UserId { get; set; }

		public User User { get; set; } = null!;

        public ICollection<Specialty> Specialties { get; set; } = null!;
    }
}
