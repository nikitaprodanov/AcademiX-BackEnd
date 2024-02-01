namespace AcademiX.Models
{
    public class Thesis
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public int ThesisSupervisorId { get; set; }
        public virtual ThesisSupervisor ThesisSupervisor { get; set; } = null!;

        public int? ReviewerId { get; set; }
        public virtual Reviewer AssignedReviewer { get; set; } = null!;
    }

}
