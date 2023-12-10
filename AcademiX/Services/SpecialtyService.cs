using AcademiX.Models;
using AcademiX.Repositories;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;

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
            return _repository.GetSpecialtyById(id);
        }

        public Specialty GetSpecialtyByName(string name)
        {
            return _repository.GetSpecialtyByName(name);
        }

        public void CreateSpecialty(Specialty specialty)
        {
             _repository.CreateSpecialty(specialty);
        }

        public int UpdateSpecialty(Specialty specialty)
        {
            return _repository.UpdateSpecialty(specialty);
        }

        public int DeleteSpecialty(int id)
        {
            return _repository.DeleteSpecialty(id);
        }
        
    }
}
