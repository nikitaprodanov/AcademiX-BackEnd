using AcademiX.Data;
using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Repositories
{
	public class ThesisSupervisorRepository : IThesisSupervisorRepository
	{
		private readonly ApplicationDbContext _context;

		public ThesisSupervisorRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void CreateThesisSupervisor(ThesisSupervisor thesisSupervisor)
		{
			_context.ThesisSupervisors.Add(thesisSupervisor);
			_context.SaveChanges();
		}

		public IEnumerable<ThesisSupervisor> GetAllThesisSupervisors()
		{
			return _context.ThesisSupervisors.ToList();
		}

		public ThesisSupervisor GetThesisSupervisorById(int id)
		{
			return _context.ThesisSupervisors.Find(id) ?? throw new EntityNotFoundException();
		}

		/*public ThesisSupervisor GetThesisSupervisorByUsername(string username)
		{
			return _context.ThesisSupervisors.ToList().Where(thesisSupervisor => thesisSupervisor.Username == username).FirstOrDefault();
		}*/

		public int DeleteThesisSupervisor(int id)
		{
			ThesisSupervisor thesisSupervisorToDelete = this.GetThesisSupervisorById(id);
			_context.ThesisSupervisors.Remove(thesisSupervisorToDelete);
			var success = _context.SaveChanges();
			return success;
		}

		public int UpdateThesisSupervisor(ThesisSupervisor thesisSupervisorToChange, ThesisSupervisor thesisSupervisor)
		{
			_context.Entry(thesisSupervisorToChange).CurrentValues.SetValues(thesisSupervisor);
			var success = _context.SaveChanges();
			return success;
		}
		public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyId(int specialtyId)
		{
			return _context.ThesisSupervisors
				.Where(ts => ts.ThesisSupervisorsSpecialties
					.Any(tss => tss.SpecialtyId == specialtyId))
				.ToList();
		}

		public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyName(string specialtyName)
		{
			return _context.ThesisSupervisors
			.Where(ts => ts.ThesisSupervisorsSpecialties
				.Any(tss => tss.Specialty.Name == specialtyName))
			.ToList();
		}
	}
}
