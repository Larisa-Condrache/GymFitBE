using GymFitBE.Models;
using Microsoft.EntityFrameworkCore;

namespace GymFitBE
{
    public class GymFitContext : DbContext
    {
        public GymFitContext(DbContextOptions<GymFitContext> options) : base(options)
        {
        }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
