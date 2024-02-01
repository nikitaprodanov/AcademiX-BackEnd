using AcademiX.Models;

namespace AcademiX.Services.Contracts
{
    public interface IThesisService
    {
        Thesis GetThesisById(int thesisId);
        IEnumerable<Thesis> GetAllTheses();
        void AddThesis(Thesis thesis);
        void UpdateThesis(Thesis thesis);
        void DeleteThesis(int thesisId);
    }

}
