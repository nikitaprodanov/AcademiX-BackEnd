using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Models.DTO;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers.API
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

            return StatusCode(StatusCodes.Status200OK, specialties);
        }

        [HttpGet("{id}")]
        public IActionResult GetReviewerById(int id)
        {
            try
            {
                var Reviewer = _reviewerService.GetReviewerById(id);

                return StatusCode(StatusCodes.Status200OK, Reviewer);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost("")]
        public ActionResult<Reviewer> CreateReviewer(ReviewerDto reviewerDto)
        {
            try
            {
                Reviewer reviewer = Convert(reviewerDto);
                _reviewerService.CreateReviewer(reviewer);

                return StatusCode(StatusCodes.Status201Created, reviewer);
            }

            catch (DuplicateEntityException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateReviewer([FromBody] ReviewerDto reviewerDto)
        {
            try
            {
                Reviewer reviewer = Convert(reviewerDto);
                var success = _reviewerService.UpdateReviewer(reviewer);

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
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);

            }
            catch (DuplicateEntityException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
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


        [NonAction]
        public Reviewer Convert(ReviewerDto dto)
        {
            return new Reviewer()
            {
                Id = dto.Id,
                Cabinet = dto.Cabinet,
                WorkingTime = dto.WorkingTime,
                UserId = dto.UserId
            };
        }
    }
}