using AcademiX.Models;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers
{
	public class ThesisSupervisorController : Controller
	{
		private readonly IThesisSupervisorService _thesisSupervisorService;

		public ThesisSupervisorController(IThesisSupervisorService thesisSupervisorService)
		{
			_thesisSupervisorService = thesisSupervisorService;
		}

		public ActionResult<IEnumerable<ThesisSupervisor>> GetAllThesisSupervisors()
		{
			var thesisSupervisor = _thesisSupervisorService.GetAllThesisSupervisors();

			return View(thesisSupervisor);
		}

		public ActionResult<ThesisSupervisor> GetThesisSupervisorById(int id)
		{
			var thesisSupervisor = _thesisSupervisorService.GetThesisSupervisorById(id);

			if (thesisSupervisor == null)
			{
				return NotFound();
			}

			return thesisSupervisor;
		}

		//public ActionResult<IEnumerable<ThesisSupervisor>> GetThesisSupervisorsBySpecialtyId(int specialtyId)
		//{
		//	var thesisSupervisors = _thesisSupervisorService.GetThesisSupervisorsBySpecialtyId(specialtyId);

		//	return View(thesisSupervisors);
		//}

		//public ActionResult<IEnumerable<ThesisSupervisor>> GetThesisSupervisorsBySpecialtyName(string specialtyName)
		//{
		//	var thesisSupervisors = _thesisSupervisorService.GetThesisSupervisorsBySpecialtyName(specialtyName);

		//	return View(thesisSupervisors);
		//}

		public ActionResult<ThesisSupervisor> CreateThesisSupervisor(ThesisSupervisor thesisSupervisor)
		{
			_thesisSupervisorService.CreateThesisSupervisor(thesisSupervisor);

			return CreatedAtAction(nameof(thesisSupervisor), new { id = thesisSupervisor.Id }, thesisSupervisor);
		}

		public ActionResult DeleteThesisSupervisor(int id)
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

		public IActionResult Index()
		{
			return View();
		}
	}
}
