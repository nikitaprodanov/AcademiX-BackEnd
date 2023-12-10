﻿using AcademiX.Data;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;

namespace AcademiX.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {

        private readonly ApplicationDbContext _context;

        public SpecialtyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Specialty> GetAllSpecialties()
        {
            return _context.Specialties.ToList();
        }

        public Specialty GetSpecialtyById(int id)
        {
            return _context.Specialties.Find(id);
        }

        public Specialty GetSpecialtyByName(string name)
        {
            return _context.Specialties.ToList().Where(specialty => specialty.Name == name).FirstOrDefault();
        }

        public void CreateSpecialty(Specialty specialty)
        {
            _context.Specialties.Add(specialty);
            _context.SaveChanges();
        }

        public int UpdateSpecialty(Specialty specialty)
        {
            _context.Specialties.Update(specialty);
            var success = _context.SaveChanges();
            return success;
        }

        public int DeleteSpecialty(int id)
        {
            Specialty specialtyToDelete = this.GetSpecialtyById(id);
            _context.Specialties.Remove(specialtyToDelete);
            var success = _context.SaveChanges();
            return success;
        }
    }
}
