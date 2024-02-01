using System.ComponentModel.DataAnnotations;

namespace AcademiX.Models.DTO
{
    public class ReviewerDto
    {
        public int Id { get; set; }
        public int Cabinet { get; set; }

        [StringLength(7)] 
        public string WorkingTime { get; set; } = null!;

        public int UserId { get; set; }
    }
}
