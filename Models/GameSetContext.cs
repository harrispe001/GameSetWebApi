using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameSetWebApi.Models
{
    public class GameSetContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public GameSetContext(DbContextOptions<GameSetContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Person> person { get; set; }
        public DbSet<Team> team { get; set; }
        public DbSet<TeamPerson> team_person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamPerson>()
                .HasKey(tp => new { tp.PersonId, tp.TeamId });

            modelBuilder.Entity<TeamPerson>()
                .HasOne(tp => tp.Person)
                .WithMany(p => p.TeamPerson)
                .HasForeignKey(tp => tp.PersonId);

            modelBuilder.Entity<TeamPerson>()
                .HasOne(tp => tp.Team)
                .WithMany(t => t.TeamPerson)
                .HasForeignKey(tp => tp.TeamId);
        }
    }
}
