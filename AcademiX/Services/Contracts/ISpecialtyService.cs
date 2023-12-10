using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Services.Contracts
{
    public interface ISpecialtyService
    {
        public IEnumerable<Specialty> GetAllSpecialties();

        public Specialty GetSpecialtyById(int id);

        public Specialty GetSpecialtyByName(string name);

        public void CreateSpecialty(Specialty specialty);

        public int UpdateSpecialty(Specialty specialty);

        public int DeleteSpecialty(int id);

    }
}
