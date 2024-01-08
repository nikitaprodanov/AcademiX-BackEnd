using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiX.Models
{
	public class ThesisSupervisorsSpecialties
	{
		public ThesisSupervisor ThesisSupervisor { get; set; }
		public Specialty Specialty { get; set; }

		[Key]
		[Column(Order = 0)]
		[ForeignKey("ThesisSupervisor")]
		public int ThesisSupervisorId { get; set; }

		[Key]
		[Column(Order = 1)]
		[ForeignKey("Specialty")]
		public int SpecialtyId { get; set; }
	}
}
