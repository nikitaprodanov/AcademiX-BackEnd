using System.ComponentModel.DataAnnotations;

namespace AcademiX.Models
{
    public class Specialty
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
        public Specialty() {
            Id = -1;
            Name = string.Empty;
            Description = string.Empty;
        }

        public Specialty(int id)
        {
            Id = id;
            Name = string.Empty;
            Description = string.Empty;
        }

        public Specialty(int id, string name, string description = "") : this(id)
        {
            Name = name;
            Description = description;
        }

		public ICollection<ThesisSupervisorsSpecialties> ThesisSupervisorsSpecialties { get; set; } = null!;
    }
}
