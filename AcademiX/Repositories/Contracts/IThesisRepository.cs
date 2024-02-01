using AcademiX.Models;

namespace AcademiX.Repositories.Contracts
{
    public interface IThesisRepository
    {
        Thesis GetThesisById(int thesisId);
        IEnumerable<Thesis> GetAllTheses();
        void AddThesis(Thesis thesis);
        void UpdateThesis(Thesis thesis);
        void DeleteThesis(int thesisId);
    }
}