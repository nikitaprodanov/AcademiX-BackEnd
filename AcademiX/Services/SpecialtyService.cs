using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace AcademiX.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository _repository;
        public SpecialtyService(ISpecialtyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Specialty> GetAllSpecialties()
        {
            return _repository.GetAllSpecialties();
        }


        public Specialty GetSpecialtyById(int id)
        {
            try
            {
                return _repository.GetSpecialtyById(id);
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Specialty with this id was not found.");

            }
        }

        public Specialty GetSpecialtyByName(string name)
        {
            return _repository.GetSpecialtyByName(name);
        }

        public void CreateSpecialty(Specialty specialty)
        {
            try
            {                             
                var id = _repository.GetAllSpecialties()
                    .OrderByDescending(sp => sp.Id)
                    .Select(sp => sp.Id)
                    .FirstOrDefault();

                specialty.Id = ++id;

                if (_repository.GetSpecialtyByName(specialty.Name) != null)
                {
                    throw new DuplicateEntityException();
                }

                _repository.CreateSpecialty(specialty);
            }
            catch (DuplicateEntityException)
            {
                throw new DuplicateEntityException("Specialty with this name is already created.");
            }
            
        }

        public int UpdateSpecialty(Specialty specialty)
        {
            try
            {

                var specialtyToChange = _repository.GetSpecialtyById(specialty.Id);

                if (_repository.GetSpecialtyByName(specialty.Name) != null)
                {
                    throw new DuplicateEntityException();
                }              

                return _repository.UpdateSpecialty(specialtyToChange,specialty);
               
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Specialty with this id was not found.");

            }
            catch (DuplicateEntityException)
            {
                throw new DuplicateEntityException("Specialty with this name is already created.");
            }           
        }

        public int DeleteSpecialty(int id)
        {
            try
            {
                _repository.GetSpecialtyById(id);

                return _repository.DeleteSpecialty(id);
            }

            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException();
            }
        }
        
    }
}
