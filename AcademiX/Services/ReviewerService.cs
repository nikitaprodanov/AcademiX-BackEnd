using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;

namespace AcademiX.Services
{
    public class ReviewerService : IReviewerService
    {
        private readonly IReviewerRepository _reviewerRepository;

        public ReviewerService(IReviewerRepository reviewerRepository)
        {
            _reviewerRepository = reviewerRepository;
        }

        public Reviewer GetReviewerById(int id)
        {
            return _reviewerRepository.GetReviewerById(id);
		}

        public IEnumerable<Reviewer> GetAllReviewers()
        {
            return _reviewerRepository.GetAllReviewers();
		}

        public void CreateReviewer(Reviewer reviewer)
        {
            _reviewerRepository.CreateReviewer(reviewer);
		}

        public int UpdateReviewer(Reviewer reviewer)
        {
            return _reviewerRepository.UpdateReviewer(reviewer);
        }

        public int DeleteReviewer(int reviewerId)
        {
            return _reviewerRepository.DeleteReviewer(reviewerId);
        }

        int IReviewerService.GetDefaultReviewerId(IEnumerable<Reviewer> availableReviewers)
        {
            var defaultReviewer = availableReviewers.FirstOrDefault();
            return defaultReviewer?.Id ?? 1;
        }
    }
}
