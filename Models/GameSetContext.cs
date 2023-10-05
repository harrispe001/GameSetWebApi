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

        public DbSet<Person> Person { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPerson> Team_Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamPerson>()
                .HasKey(tp => new { tp.TeamId, tp.PersonId });
        }
    }
}
