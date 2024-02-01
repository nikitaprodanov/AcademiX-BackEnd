using AcademiX.Models;

namespace AcademiX.Services.Contracts
{
    public interface IReviewerService
    {
        Reviewer GetReviewerById(int id);
        IEnumerable<Reviewer> GetAllReviewers();
        void CreateReviewer(Reviewer reviewer);
        int UpdateReviewer(Reviewer reviewer);
        int DeleteReviewer(int reviewerId);
        int GetDefaultReviewerId(IEnumerable<Reviewer> availableReviewers);
    }
}
