using AcademiX.Models;

namespace AcademiX.Repositories.Contracts
{
    public interface ISpecialtyRepository
    {
        public IEnumerable<Specialty> GetAllSpecialties();

        public Specialty GetSpecialtyById(int id);

        public Specialty GetSpecialtyByName(string name);

        public void CreateSpecialty(Specialty specialty);

        public int UpdateSpecialty(Specialty SpecialtyToChange, Specialty specialty);

        public int DeleteSpecialty(int id);
    }
}
