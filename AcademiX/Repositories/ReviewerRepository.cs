using AcademiX.Data;
using AcademiX.Exceptions;
using AcademiX.Migrations;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Repositories
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Reviewer GetReviewerById(int reviewerId)
        {
            return _context.Reviewers.Find(reviewerId) ?? throw new Exception("No such reviewer exists!");
        }

        public IEnumerable<Reviewer> GetAllReviewers()
        {
			return _context.Reviewers.ToList();
        }

        public void CreateReviewer(Reviewer reviewer)
        {
			_context.Reviewers.Add(reviewer);
            _context.SaveChanges();
        }

        public int UpdateReviewer(Reviewer reviewer)
        {
            _context.Entry(reviewer).State = EntityState.Modified;
            _context.SaveChanges();

            return reviewer.UserId;
        }

        public int DeleteReviewer(int reviewerId)
        {
            var reviewerToDelete = _context.Reviewers.Find(reviewerId);

            if (reviewerToDelete != null)
            {
                _context.Reviewers.Remove(reviewerToDelete);
                _context.SaveChanges();
            }

            return reviewerToDelete?.UserId ?? 0;
        }
    }
}
