using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;

namespace AcademiX.Services
{
    public class ThesisService : IThesisService
    {
        private readonly IThesisRepository _thesisRepository;

        public ThesisService(IThesisRepository thesisRepository)
        {
            _thesisRepository = thesisRepository;
        }

        public Thesis GetThesisById(int thesisId)
        {
            return _thesisRepository.GetThesisById(thesisId);
        }

        public IEnumerable<Thesis> GetAllTheses()
        {
            return _thesisRepository.GetAllTheses();
        }

        public void AddThesis(Thesis thesis)
        {
            _thesisRepository.AddThesis(thesis);
        }

        public void UpdateThesis(Thesis thesis)
        {
            _thesisRepository.UpdateThesis(thesis);
        }

        public void DeleteThesis(int thesisId)
        {
            _thesisRepository.DeleteThesis(thesisId);
        }
    }

}
