using AcademiX.Models;

namespace AcademiX.Services.Contracts
{
	public interface IThesisSupervisorService
	{
		// Create
		public void CreateThesisSupervisor(ThesisSupervisor thesisSupervisor);

		// GetAll
		public IEnumerable<ThesisSupervisor> GetAllThesisSupervisors();

		// GetById
		public ThesisSupervisor GetThesisSupervisorById(int id);

		//public ThesisSupervisor GetThesisSupervisorByUsername(string username);

		// Update 
		public int UpdateThesisSupervisor(ThesisSupervisor thesisSupervisor);

		// Delete
		public int DeleteThesisSupervisor(int id);

		//// GetBySpecialtyId
		//public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyId(int specialtyId);

		//// GetBySpecialtyName
		//public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyName(string specialtyName);
	}
}
