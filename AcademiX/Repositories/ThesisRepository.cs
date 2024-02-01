using AcademiX.Data;
using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Repositories
{
    public class ThesisRepository : IThesisRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ThesisRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Thesis GetThesisById(int thesisId)
        {
            return _dbContext.Theses.Find(thesisId) ?? throw new EntityNotFoundException();
        }

        public IEnumerable<Thesis> GetAllTheses()
        {
            return _dbContext.Theses.ToList();
        }

        public void AddThesis(Thesis thesis)
        {
            _dbContext.Theses.Add(thesis);
            _dbContext.SaveChanges();
        }

        public void UpdateThesis(Thesis thesis)
        {
            _dbContext.Entry(thesis).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteThesis(int thesisId)
        {
            var thesisToDelete = _dbContext.Theses.Find(thesisId);

            if (thesisToDelete != null)
            {
                _dbContext.Theses.Remove(thesisToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
