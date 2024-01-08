using AcademiX.Models;

namespace AcademiX.Repositories.Contracts
{
	public interface IThesisSupervisorRepository
	{
		public void CreateThesisSupervisor(ThesisSupervisor thesisSupervisor);

		public IEnumerable<ThesisSupervisor> GetAllThesisSupervisors();

		public ThesisSupervisor GetThesisSupervisorById(int id);

		//public ThesisSupervisor GetThesisSupervisorByUsername(string username);

		public int UpdateThesisSupervisor(ThesisSupervisor thesisSupervisorToChange, ThesisSupervisor thesisSupervisor);

		public int DeleteThesisSupervisor(int id);

		//public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyId(int specialtyId);

		//public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyName(string specialtyName);
	}
}
