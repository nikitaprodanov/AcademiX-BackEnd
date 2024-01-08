using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiX.Models
{
	public class ThesisSupervisorsSpecialties
	{
		public ThesisSupervisor ThesisSupervisor { get; set; }
		public Specialty Specialty { get; set; }

		[ForeignKey("ThesisSupervisor")]
		public int ThesisSupervisorId { get; set; }

		[ForeignKey("Specialty")]
		public int SpecialtyId { get; set; }
	}
}
