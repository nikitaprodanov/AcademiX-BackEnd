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

        public IEnumerable<Reviewer> GetAllReviewers()
        {
            return _context.Reviewers
                .Include(reviewer => reviewer.User)
                .ToList();
        }

        public Reviewer GetReviewerById(int id)
        {
            return _context.Reviewers
                .Include(reviewer => reviewer.User)
                .Where(reviewer => reviewer.Id == id)
                .FirstOrDefault() ?? throw new EntityNotFoundException();
        }

        public Reviewer CreateReviewer(Reviewer Reviewer)
        {
            _context.Reviewers.Add(Reviewer);
            _context.SaveChanges();
            return Reviewer;
        }

        public int UpdateReviewer(Reviewer reviewerToChange, Reviewer reviewer)
        {
            _context.Entry(reviewerToChange).CurrentValues.SetValues(reviewer);
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
