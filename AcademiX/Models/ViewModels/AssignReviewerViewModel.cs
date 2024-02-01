namespace AcademiX.Models.ViewModels
{
    public class AssignReviewerViewModel
    {
        public int ThesisId { get; set; }
        public IEnumerable<Reviewer>? AvailableReviewers { get; set; }
        public int SelectedReviewerId { get; set; }
    }
}
