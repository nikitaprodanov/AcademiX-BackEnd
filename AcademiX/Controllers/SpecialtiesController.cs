using AcademiX.Data;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using AcademiX.Services;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtiesController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        public ActionResult<IEnumerable<Specialty>> GetAllSpecialties()
        {
            var specialties = _specialtyService.GetAllSpecialties();

            return View(specialties);
        }

        public ActionResult<Specialty> GetSpecialtyById(int id)
        {
           var specialty = _specialtyService.GetSpecialtyById(id);
            if(specialty == null)
            {
                return BadRequest();
            }

            return specialty;
        }

        public ActionResult<Specialty> CreateSpecialty(Specialty specialty)
        {
            _specialtyService.CreateSpecialty(specialty);

            return CreatedAtAction(nameof(specialty), new { id = specialty.Id }, specialty);
        }

        public ActionResult UpdateSpecialty(Specialty specialty)
        {
            if(specialty == null)
            {
                return BadRequest();
            }
         
            var success = _specialtyService.UpdateSpecialty(specialty);

            if (success != 0)
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
            var success = _specialtyService.DeleteSpecialty(id);

            if (success != 0)
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








        //This controllers seem to be redundant because these operations can be done directly by UpdateSpecialty controller

        //public ActionResult EditSpecialtyName(int id, string name)
        //{
        //    var specialty = GetSpecialtyById(id).Value;
        //    if(specialty == null)
        //    {
        //        return BadRequest();
        //    }

        //    specialty.Name = name;

        //    return UpdateSpecialty(specialty);
        //}

        //public ActionResult EditSpecialtyDescription(int id, string description)
        //{
        //    var specialty = GetSpecialtyById(id).Value;
        //    if (specialty == null)
        //    {
        //        return BadRequest();
        //    }

        //    specialty.Description = description;

        //    return UpdateSpecialty(specialty);
        //}


        //No need for now
        //public ActionResult<Specialty> GetSpecialtyByName(string name)
        //{
        //    var specialty = _specialtyService.GetSpecialtyByName(name);
        //    if (specialty == null)
        //    {
        //        return BadRequest();
        //    }

        //    return specialty;
        //}
    }
}
