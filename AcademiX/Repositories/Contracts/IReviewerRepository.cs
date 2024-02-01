using AcademiX.Models;

namespace AcademiX.Repositories.Contracts
{
    public interface IReviewerRepository
    {
        Reviewer GetReviewerById(int reviewerId);
        IEnumerable<Reviewer> GetAllReviewers();
        void CreateReviewer(Reviewer reviewer);
        int UpdateReviewer(Reviewer reviewer);
        int DeleteReviewer(int reviewerId);
    }
}
