using AcademiX.Models;

namespace AcademiX.Services.Contracts
{
    public interface IReviewerService
    {
        public IEnumerable<Reviewer> GetAllReviewers();

        public Reviewer GetReviewerById(int id);

        public Reviewer CreateReviewer(Reviewer reviewer);

        public int UpdateReviewer( Reviewer reviewer);

        public int DeleteReviewer(int id);
    }
}
