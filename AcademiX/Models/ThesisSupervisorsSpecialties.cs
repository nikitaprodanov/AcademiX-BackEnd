using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiX.Models
{
	public class ThesisSupervisorsSpecialties
	{
        public int ThesisSupervisorId { get; set; }
        public ThesisSupervisor? ThesisSupervisor { get; set; }
		public int SpecialtyId { get; set; }
        public Specialty? Specialty { get; set; }
    }
}
