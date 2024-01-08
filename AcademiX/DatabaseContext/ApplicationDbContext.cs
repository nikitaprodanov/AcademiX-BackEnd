using AcademiX.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /* Add other Database tables as models are made*/ 
        public DbSet<User> Users { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
		public DbSet<ThesisSupervisor> ThesisSupervisors { get; set; }
		public DbSet<ThesisSupervisorsSpecialties> ThesisSupervisorsSpecialties { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ThesisSupervisorsSpecialties>()
				.HasKey(t => new { t.ThesisSupervisorId, t.SpecialtyId });
		}
	}
}