using AcademiX.Data;
using AcademiX.Exceptions;
using AcademiX.Migrations;
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
			var supervisors = _context.ThesisSupervisors
                .Include(ts => ts.User)
                .ToList();
			var specialties = (from tss in _context.ThesisSupervisorsSpecialties
							   join s in _context.Specialties on tss.SpecialtyId equals s.Id
							   select new
							   {
								   thesisSupervisorId = tss.ThesisSupervisorId,
								   Specialty = new Specialty
								   {
									   Id = s.Id,
									   Name = s.Name,
									   Description = s.Description
								   }
							   }
							   ).ToList();

			foreach (var supervisor in supervisors)
			{
				var supervisorSpecialties = (from specialty in specialties
											where specialty.thesisSupervisorId == supervisor.Id
											select specialty.Specialty).ToList();
				supervisor.Specialties = supervisorSpecialties;
			}

            return supervisors;
        }

		public ThesisSupervisor GetThesisSupervisorById(int id)
		{
			var thesisSupervisor = _context.ThesisSupervisors.Find(id);

			if (thesisSupervisor == null) throw new EntityNotFoundException();

            var specialties = (from tss in _context.ThesisSupervisorsSpecialties
                               join s in _context.Specialties on tss.SpecialtyId equals s.Id
							   where tss.ThesisSupervisorId == thesisSupervisor.Id
                               select new
                               {
                                   thesisSupervisorId = tss.ThesisSupervisorId,
                                   Specialty = new Specialty
                                   {
                                       Id = s.Id,
                                       Name = s.Name,
                                       Description = s.Description
                                   }
                               }
                               ).ToList();

			thesisSupervisor.Specialties = (from specialty in specialties
                                            where specialty.thesisSupervisorId == thesisSupervisor.Id
                                            select specialty.Specialty).ToList();

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
		//public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyId(int specialtyId)
		//{
		//	return _context.ThesisSupervisors
		//		.Where(ts => ts.ThesisSupervisorsSpecialties
		//			.Any(tss => tss.SpecialtyId == specialtyId))
		//		.ToList();
		//}

		//public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyName(string specialtyName)
		//{
		//	return _context.ThesisSupervisors
		//		.Where(ts => ts.ThesisSupervisorsSpecialties
		//			.Any(tss => tss.Specialty.Name == specialtyName))
		//		.ToList();
		//}
	}
}
