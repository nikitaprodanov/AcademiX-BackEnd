﻿using AcademiX.Models;

namespace AcademiX.Services.Contracts
{
	public interface IThesisSupervisorService
	{

		// GetAll
		public IEnumerable<ThesisSupervisor> GetAllThesisSupervisors();

		// GetById
		public ThesisSupervisor GetThesisSupervisorById(int id);

		// Create
		public void CreateThesisSupervisor(ThesisSupervisor thesisSupervisor);

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
