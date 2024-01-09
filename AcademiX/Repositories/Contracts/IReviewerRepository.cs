using AcademiX.Models;

namespace AcademiX.Repositories.Contracts
{
    public interface IReviewerRepository
    {
        public IEnumerable<Reviewer> GetAllReviewers();

        public Reviewer GetReviewerById(int id);

        public Reviewer CreateReviewer(Reviewer reviewer);

        public int UpdateReviewer(Reviewer reviewerToChange, Reviewer reviewer);

        public int DeleteReviewer(int id);
    }
}
