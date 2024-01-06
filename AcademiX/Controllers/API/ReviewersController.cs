using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewersController : ControllerBase
    {

        private readonly IReviewerService _reviewerService;

        public ReviewersController(IReviewerService reviewerService)
        {
            _reviewerService = reviewerService;
        }

        [HttpGet("")]
        public IActionResult GetAllReviewers()
        {
            var specialties = _reviewerService.GetAllReviewers();

            return this.StatusCode(StatusCodes.Status200OK, specialties);
        }

        [HttpGet("{id}")]
        public IActionResult GetReviewerById(int id)
        {
            try
            {
                var Reviewer = _reviewerService.GetReviewerById(id);

                return this.StatusCode(StatusCodes.Status200OK, Reviewer);
            }
            catch (EntityNotFoundException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost("")]
        public ActionResult<Reviewer> CreateReviewer(Reviewer Reviewer)
        {
            try
            {
                _reviewerService.CreateReviewer(Reviewer);

                return this.StatusCode(StatusCodes.Status201Created, Reviewer);
            }

            catch (DuplicateEntityException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateReviewer([FromBody] Reviewer Reviewer)
        {
            try
            {
                var success = _reviewerService.UpdateReviewer(Reviewer);

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
        public IActionResult DeleteReviewer([FromRoute] int id)
        {
            var success = _reviewerService.DeleteReviewer(id);

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