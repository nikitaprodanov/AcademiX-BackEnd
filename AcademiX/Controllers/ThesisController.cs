using AcademiX.Models;
using AcademiX.Models.ViewModels;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AcademiX.Controllers
{
    // [Authorize(Roles = "ThesisSupervisor")]
    public class ThesisController : Controller
    {
        private readonly IThesisService _thesisService;
        private readonly IReviewerService _reviewerService;

        public ThesisController(IThesisService thesisService, IReviewerService reviewerService)
        {
            _thesisService = thesisService;
            _reviewerService = reviewerService;
        }

        public IActionResult Index()
        {
            var theses = _thesisService.GetAllTheses();
            return View(theses);
        }

        public IActionResult Details(int id)
        {
            var thesis = _thesisService.GetThesisById(id);
            return View(thesis);
        }

        public IActionResult Create()
        {
            // Action logic
            return View();
        }

        [HttpPost]
        public IActionResult Create(Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                _thesisService.AddThesis(thesis);
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, redisplay the form with errors
            return View(thesis);
        }

        public IActionResult Edit(int id)
        {
            var thesis = _thesisService.GetThesisById(id);
            return View(thesis);
        }

        [HttpPost]
        public IActionResult Edit(Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                _thesisService.UpdateThesis(thesis);
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, redisplay the form with errors
            return View(thesis);
        }

        public IActionResult Delete(int id)
        {
            var thesis = _thesisService.GetThesisById(id);
            return View(thesis);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _thesisService.DeleteThesis(id);
            return RedirectToAction("Index");
        }

        /*public IActionResult AssignReviewer(int id)
        {
            var thesis = _thesisService.GetThesisById(id);
            var availableReviewers = _reviewerService.GetAllReviewers();

            var viewModel = new AssignReviewerViewModel
            {
                ThesisId = thesis.Id,
                AvailableReviewers = availableReviewers
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AssignReviewer(AssignReviewerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var thesis = _thesisService.GetThesisById(viewModel.ThesisId);
                var reviewer = _reviewerService.GetReviewerById(viewModel.SelectedReviewerId);

                thesis.ReviewerId = reviewer.Id;
                thesis.AssignedReviewer = reviewer;

                _thesisService.UpdateThesis(thesis);

                return RedirectToAction("Index");
            }

            // If ModelState is not valid, redisplay form with errors
            return View(viewModel);
        }*/

        // [Authorize(Roles = "ThesisSupervisor")]
        [HttpGet]
        public IActionResult AssignReviewer(int thesisId)
        {
            //if (!User.IsInRole("ThesisSupervisor"))
            //{
            //    return Forbid();
            //}

            var availableReviewers = _reviewerService.GetAllReviewers();

            var viewModel = new AssignReviewerViewModel
            {
                ThesisId = thesisId,
                AvailableReviewers = availableReviewers,
                SelectedReviewerId = _reviewerService.GetDefaultReviewerId(availableReviewers)
            };

            return View(viewModel);
        }

        // [Authorize(Roles = "ThesisSupervisor")]
        [HttpPost]
        public IActionResult AssignReviewer(AssignReviewerViewModel viewModel)
        {
            //if (!User.IsInRole("ThesisSupervisor"))
            //{
            //    return Forbid();
            //}

            if (ModelState.IsValid)
            {
                var thesis = _thesisService.GetThesisById(viewModel.ThesisId);
                var reviewer = _reviewerService.GetReviewerById(viewModel.SelectedReviewerId);

                if (thesis != null && reviewer != null)
                {
                    thesis.ReviewerId = reviewer.Id;
                    thesis.AssignedReviewer = reviewer;

                    _thesisService.UpdateThesis(thesis);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Thesis or Reviewer not found.");
                }
            }

            viewModel.AvailableReviewers = _reviewerService.GetAllReviewers();
            return View(viewModel);
        }
    }
}
