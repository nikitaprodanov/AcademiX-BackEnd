using AcademiX.Data;
using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;

namespace AcademiX.Repositories
{
    public class ReviewerRepository : IReviewerRepository
    {

        private readonly ApplicationDbContext _context;

        public ReviewerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reviewer> GetAllReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public Reviewer GetReviewerById(int id)
        {
            return _context.Reviewers.Find(id) ?? throw new EntityNotFoundException();
        }

        public void CreateReviewer(Reviewer Reviewer)
        {
            _context.Reviewers.Add(Reviewer);
            _context.SaveChanges();
        }

        public int UpdateReviewer(Reviewer reviewerToChange, Reviewer Reviewer)
        {
            _context.Entry(reviewerToChange).CurrentValues.SetValues(Reviewer);
            var success = _context.SaveChanges();
            return success;
        }

        public int DeleteReviewer(int id)
        {
            Reviewer ReviewerToDelete = this.GetReviewerById(id);
            _context.Reviewers.Remove(ReviewerToDelete);
            var success = _context.SaveChanges();
            return success;
        }
    }
}
