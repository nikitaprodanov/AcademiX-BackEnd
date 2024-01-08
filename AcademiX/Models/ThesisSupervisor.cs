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
		public string Email { get; set; }
		public int Cabinet { get; set; }
		public string WorkingTime { get; set; }
		public bool IsReviewer { get; set; }

		[Required]
		public int UserId { get; set; }

		public User User { get; set; }

		public ICollection<Specialty> Specialties { get; set; }
	}
}
