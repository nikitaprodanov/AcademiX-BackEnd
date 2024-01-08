using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;


namespace AcademiX.Services
{
	public class ThesisSupervisorService : IThesisSupervisorService
	{
		private readonly IThesisSupervisorRepository _repository;
		//private readonly ISpecialtyService _service;

		public ThesisSupervisorService(IThesisSupervisorRepository repository)
		{
			_repository = repository;
		}

		/*public ThesisSupervisorService(ISpecialtyService service)
		{
			_service = service;
		}*/

		public IEnumerable<ThesisSupervisor> GetAllThesisSupervisors()
		{
			return _repository.GetAllThesisSupervisors();
		}

		/*public ThesisSupervisor GetThesisSupervisorByUsername(string username)
		{
			return _repository.GetThesisSupervisorByUsername(username);
		}*/

		public void CreateThesisSupervisor(ThesisSupervisor thesisSupervisor)
		{
			try
			{
				var id = _repository.GetAllThesisSupervisors()
					.OrderByDescending(sp => sp.Id)
					.Select(sp => sp.Id)
					.FirstOrDefault();

				thesisSupervisor.Id = ++id;

				_repository.CreateThesisSupervisor(thesisSupervisor);
			}

			catch (Exception)
			{
				throw new Exception();
			}
		}

		public ThesisSupervisor GetThesisSupervisorById(int id)
		{
			try
			{
				return _repository.GetThesisSupervisorById(id);
			}
			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException("Thesis supervisor with this id was not found.");

			}
		}

		// GetBySpecialtyId
		public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyId(int specialtyId)
		{
			return _repository.GetThesisSupervisorsBySpecialtyId(specialtyId);
		}

		// GetBySpecialtyName
		public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyName(string specialtyName)
		{
			return _repository.GetThesisSupervisorsBySpecialtyName(specialtyName);
		}

		public int DeleteThesisSupervisor(int id)
		{
			try
			{
				_repository.GetThesisSupervisorById(id);

				return _repository.DeleteThesisSupervisor(id);
			}

			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException();
			}
		}

		// Update
		public int UpdateThesisSupervisor(ThesisSupervisor thesisSupervisor)
		{
			try
			{
				var thesisSupervisorToChange = _repository.GetThesisSupervisorById(thesisSupervisor.Id);

				return _repository.UpdateThesisSupervisor(thesisSupervisorToChange, thesisSupervisor);

			}
			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException("Thesis supervisor with this id was not found.");

			}
		}
	}
}
