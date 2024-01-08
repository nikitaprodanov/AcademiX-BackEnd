using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Services;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class ThesisSupervisorController : ControllerBase
	{
		private readonly IThesisSupervisorService _thesisSupervisorService;

		public ThesisSupervisorController(IThesisSupervisorService thesisSupervisorService)
		{
			_thesisSupervisorService = thesisSupervisorService;
		}

		[HttpGet("")]
		public IActionResult GetAllThesisSupervisors()
		{
			var thesisSupervisors = _thesisSupervisorService.GetAllThesisSupervisors();

			return this.StatusCode(StatusCodes.Status200OK, thesisSupervisors);
		}

		[HttpGet("{id}")]
		public IActionResult GetThesisSupervisorById(int id)
		{
			try
			{
				var thesisSupervisor = _thesisSupervisorService.GetThesisSupervisorById(id);

				return this.StatusCode(StatusCodes.Status200OK, thesisSupervisor);
			}
			catch (EntityNotFoundException ex)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
			}
		}

		[HttpGet("byspecialty/{specialtyId}")]
		public IActionResult GetThesisSupervisorsBySpecialtyId(int specialtyId)
		{
			var thesisSupervisor = _thesisSupervisorService.GetThesisSupervisorsBySpecialtyId(specialtyId);

			return this.StatusCode(StatusCodes.Status200OK, thesisSupervisor);
		}

		[HttpGet("byspecialty/{specialtyName}")]
		public IActionResult GetThesisSupervisorsBySpecialtyName(string specialtyName)
		{
			var thesisSupervisor = _thesisSupervisorService.GetThesisSupervisorsBySpecialtyName(specialtyName);

			return this.StatusCode(StatusCodes.Status200OK, thesisSupervisor);
		}


		[HttpPost("")]
		public ActionResult<ThesisSupervisor> CreateThesisSupervisor(ThesisSupervisor thesisSupervisor)
		{
			try
			{
				_thesisSupervisorService.CreateThesisSupervisor(thesisSupervisor);

				return this.StatusCode(StatusCodes.Status201Created, thesisSupervisor);
			}

			catch (DuplicateEntityException ex)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
			}
		}


		[HttpPut("")]
		public IActionResult UpdateThesisSupervisor([FromBody] ThesisSupervisor thesisSupervisor)
		{
			try
			{
				var success = _thesisSupervisorService.UpdateThesisSupervisor(thesisSupervisor);

				if (success != 0)
				{
					return Ok();
				}
				else
				{
					return BadRequest();
				}
			}
			catch (EntityNotFoundException ex)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);

			}
			catch (DuplicateEntityException ex)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
			}
		}


		[HttpDelete("{id}")]
		public IActionResult DeleteThesisSupervisor([FromRoute] int id)
		{
			var success = _thesisSupervisorService.DeleteThesisSupervisor(id);

			if (success != 0)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
