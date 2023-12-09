namespace AcademiX.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
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

        public Specialty(int id, string name, string description) : this(id)
        {
            Name = name;
            Description = description;
        }
    }
}
