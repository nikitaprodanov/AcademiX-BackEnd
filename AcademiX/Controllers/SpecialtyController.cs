using AcademiX.Data;
using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers
{
    public class SpecialtyController : Controller
    {
        private ApplicationDbContext _context;

        public SpecialtyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult<Specialty> CreateSpecialty(Specialty specialty)
        {
            if(specialty == null)
            {
                return BadRequest();
            }

            _context.Specialties.Add(specialty);
            _context.SaveChanges();

            return CreatedAtAction(nameof(specialty), new {id = specialty.Id}, specialty);
        }

        public ActionResult<IEnumerable<Specialty>> GetAllSpecialties()
        {
            return _context.Specialties.ToList();
        }

        public ActionResult<Specialty> GetSpecialtyById(int id)
        {
            var specialty = _context.Specialties.Find(id);
            if(specialty == null)
            {
                return BadRequest();
            }

            return specialty;
        }

        public ActionResult<Specialty> GetSpecialtyByName(string name)
        {
            return _context.Specialties.ToList().Where(specialty => specialty.Name == name).First();
        }

        public ActionResult EditSpecialtyName(int id, string name)
        {
            var specialty = GetSpecialtyById(id).Value;
            if(specialty == null)
            {
                return BadRequest();
            }

            specialty.Name = name;

            return UpdateSpecialty(specialty);
        }

        public ActionResult EditSpecialtyDescription(int id, string description)
        {
            var specialty = GetSpecialtyById(id).Value;
            if (specialty == null)
            {
                return BadRequest();
            }

            specialty.Description = description;

            return UpdateSpecialty(specialty);
        }

        public ActionResult UpdateSpecialty(Specialty specialty)
        {
            if(specialty == null)
            {
                return BadRequest();
            }

            _context.Specialties.Update(specialty);

            if (_context.SaveChanges() != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public ActionResult DeleteSpecialty(int id)
        {
            ActionResult<Specialty> specialty = GetSpecialtyById(id);

            if(specialty.Value == null)
            {
                return BadRequest();
            }

            _context.Specialties.Remove(specialty.Value);

            if (_context.SaveChanges() != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
