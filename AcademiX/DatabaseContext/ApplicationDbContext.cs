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
    }
}