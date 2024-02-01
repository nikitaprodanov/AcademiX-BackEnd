using AcademiX.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Thesis> Theses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Specialty> Specialties { get; set; } = null!;
        public DbSet<Reviewer> Reviewers { get; set; } = null!;
        public DbSet<ThesisSupervisor> ThesisSupervisors { get; set; } = null!;
        public DbSet<ThesisSupervisorsSpecialties> ThesisSupervisorsSpecialties { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ThesisSupervisorsSpecialties>()
				.HasKey(t => new { t.ThesisSupervisorId, t.SpecialtyId });

            modelBuilder.Entity<Thesis>()
                .HasOne(t => t.AssignedReviewer)
                .WithMany()
                .HasForeignKey(t => t.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);
		}
    }
}