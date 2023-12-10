using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AspNetCoreDemo.Controllers.Api
{
	[ApiController]
	[Route("api/[controller]")]
	public class SpecialtiesController : ControllerBase
	{

        private readonly ISpecialtyService _specialtyService;

        public SpecialtiesController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        [HttpGet("")]
        public IActionResult GetAllSpecialties()
        {
            var specialties = _specialtyService.GetAllSpecialties();

            return this.StatusCode(StatusCodes.Status200OK, specialties);
        }

        [HttpGet("{id}")]
        public IActionResult GetSpecialtyById(int id)
        {
            try
            {
                var specialty = _specialtyService.GetSpecialtyById(id);

                return this.StatusCode(StatusCodes.Status200OK, specialty);
            }
            catch (EntityNotFoundException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound,ex.Message);
            }
        }

        [HttpPost("")]
        public ActionResult<Specialty> CreateSpecialty(Specialty specialty)
        {
            try
            {
                _specialtyService.CreateSpecialty(specialty);

                return this.StatusCode(StatusCodes.Status201Created, specialty);
            }

            catch (DuplicateEntityException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict,ex.Message);
            }
        }

        [HttpPut("")]
		public IActionResult UpdateSpecialty([FromBody] Specialty specialty)
		{
            try
            {
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
            catch(EntityNotFoundException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);

            }
            catch(DuplicateEntityException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }


        [HttpDelete("{id}")]
		public IActionResult DeleteSpecialty([FromRoute] int id)
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


        //No need for now
        //      [HttpGet("{name}")]
        //      public IActionResult GetSpecialtyByName(string name)
        //{
        //          var specialty = _specialtyService.GetSpecialtyByName(name);
        //          if (specialty == null)
        //          {
        //              return BadRequest();
        //          }

        //          return this.StatusCode(StatusCodes.Status200OK, specialty);
        //      }
    }
}
